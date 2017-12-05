using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using SSD1289_Ctrl_App.SSD1289;

namespace SSD1289_Ctrl_App
{
    public partial class FormMain : Form
    {
        #region Private Data
        SerialPort _serial = new SerialPort();
        StringBuilder _sb = new StringBuilder();
        char[] _seperators = new char[] { AppConstant.DELIMITER_CMD_ARG };
        List<RegisterValuePair> _rvPairs = null;
        bool _loopWriteRegisters = false;
        bool _isWriteStarted = false;
        List<string> _registerWriteHistory = new List<string>();
        object _lock1 = new object();
        ushort[] _colors = new ushort[] { 0xFFFF, 0x001F, 0xF800, 0x07E0 };
        byte _colorIndex = 0;
        #endregion

        #region Constructors
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void UpdateControls()
        {
            bool enableControls = true;

            if (_serial.IsOpen == true)
            {
                btnOpenClose.Text = "Close";
            }
            else
            {
                btnOpenClose.Text = "Open";
                enableControls = false;
            }

            tbReadRegAddr.Enabled = enableControls;
            tbWriteRegAddr.Enabled = enableControls;
            tbWriteRegValue.Enabled = enableControls;
            btnReadReg.Enabled = enableControls;
            btnWriteReg.Enabled = enableControls;
            btnBatchWriteStartStop.Enabled = enableControls;
            btnDrawLine.Enabled = enableControls;
        }

        private void UpdateControlsWhileRegReading()
        {
            bool enableControls = true;

            if (!btnReadReg.Enabled)
            {
                enableControls = false;
            }

            tbReadRegAddr.Enabled = enableControls;
            tbWriteRegAddr.Enabled = enableControls;
            tbWriteRegValue.Enabled = enableControls;
            btnWriteReg.Enabled = enableControls;
            btnBatchWriteStartStop.Enabled = enableControls;
            btnDrawLine.Enabled = enableControls;
            btnOpenClose.Enabled = enableControls;
        }

        private void UpdateUiWhileManyRegsWriting(bool enableControls)
        {
            tbReadRegAddr.Enabled = enableControls;
            tbWriteRegAddr.Enabled = enableControls;
            tbWriteRegValue.Enabled = enableControls;
            btnWriteReg.Enabled = enableControls;
            btnBatchWriteStartStop.Enabled = enableControls;
            btnDrawLine.Enabled = enableControls;
            btnOpenClose.Enabled = enableControls;
        }

        private void SerialClose()
        {
            _serial.Close();

            UpdateControls();
        }

        private void SerialOpen()
        {
            if (cmbSerialPort.SelectedIndex >= 0)
            {
                _serial.PortName = (string)cmbSerialPort.SelectedItem;
                _serial.BaudRate = 115200;
                _serial.Parity = Parity.None;
                _serial.StopBits = StopBits.One;
                _serial.DataBits = 8;

                _serial.Open();

                UpdateControls();
            }
            else
            {
                MessageBox.Show("No serial port.");
            }
        }

        byte[] StringCommandToByteArray(string command)
        {
            byte[] byteArr = new byte[command.Length];
            int i = 0;

            foreach (char ch in command)
            {
                byteArr[i++] = (byte)ch;
            }

            return byteArr;
        }

        private int Ssd1298ReadReg(byte reg)
        {
            string command = string.Format("RD {0}{1}", reg, AppConstant.DELIMITER_CMD_END);
            byte[] packet = StringCommandToByteArray(command);
            byte byteRead = 0;
            string response = null;
            DateTime sentTime;
            byte end = (byte)AppConstant.DELIMITER_CMD_END;
            bool received = false;

            _serial.Write(packet, 0, packet.Length);
            sentTime = DateTime.UtcNow;

            // Response format : 
            // RD reg_addr reg_value\n
            _sb.Clear();
            while (true)
            {
                TimeSpan elapsedTime = DateTime.UtcNow - sentTime;
                // Check timeout.
                if (elapsedTime.TotalSeconds > AppConstant.RESPONSE_WAIT_TIME_IN_SEC)
                {
                    return AppConstant.COMMAND_FAIL;
                }

                if (_serial.BytesToRead > 0)
                {
                    int count = _serial.BytesToRead;
                    for (int i = 0; i < count; i++)
                    {
                        byteRead = (byte)_serial.ReadByte();
                        // Read unitil '\n' is met.
                        if (byteRead != end)
                        {
                            _sb.Append((char)byteRead);
                        }
                        else
                        {
                            // Response received.
                            response = _sb.ToString();
                            received = true;
                            break;
                        }
                    }
                }
                if (received == true)
                {
                    break;
                }
                Thread.Sleep(10);
            }

            if (!string.IsNullOrEmpty(response))
            {
                string[] elements = response.Split(_seperators);
                // Parse a register value.
                if (elements.Length == 3)
                {
                    if (ushort.TryParse(elements[2], out ushort regValue) == true)
                    {
                        return regValue;
                    }
                }
            }

            return AppConstant.COMMAND_FAIL;
        }

        private void Ssd1298WriteReg(byte reg, ushort regValue)
        {
            string command = string.Format("WR {0} {1}{2}", reg, regValue, AppConstant.DELIMITER_CMD_END);
            byte[] packet = StringCommandToByteArray(command);
            byte[] read = new byte[24];

            _serial.Write(packet, 0, packet.Length);
            // Read receive buffer in order to prevent receive buffer from being full.
            if (_serial.BytesToRead > 0)
            {
                _serial.Read(read, 0, read.Length);
            }
        }

        // Writing registers may take long time.
        private Task DoBatchWrite()
        {
            return Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();

                lock (_lock1)
                {
                    _isWriteStarted = true;
                }

                foreach (RegisterValuePair rvPair in _rvPairs)
                {
                    if (!_loopWriteRegisters)
                    {
                        break;
                    }

                    if (rvPair.register == "sleep")
                    {
                        // Give some time between register writes.
                        int sleepTime = int.Parse(rvPair.registerValue);
                        Thread.Sleep(sleepTime);
                    }
                    else
                    {
                        // Write a value to a register.
                        byte reg = byte.Parse(rvPair.register, NumberStyles.HexNumber);
                        ushort regValue = ushort.Parse(rvPair.registerValue, NumberStyles.HexNumber);

                        Ssd1298WriteReg(reg, regValue);
                    }

                    sb.Clear();
                    lock (_lock1)
                    {
                        // A UI control will display this register, value pairs.
                        _registerWriteHistory.Add(sb.AppendFormat($"{rvPair.register}, {rvPair.registerValue}").ToString());
                    }
                }

                // Read receive buffer in order to prevent receive buffer from being full.
                Thread.Sleep(500);
                byte[] readBuf = new byte[256];
                while (_serial.BytesToRead > 0)
                {
                    _serial.Read(readBuf, 0, readBuf.Length);
                }

                lock(_lock1)
                {
                    _isWriteStarted = false;
                }
            }
            );
        }
        #endregion Private Methods

        #region Event Handlers
        // A Window is about to be displayed.
        private void FormMain_Load(object sender, EventArgs e)
        {
            string[] portNames = SerialPort.GetPortNames();

            if (portNames?.Length > 0)
            {
                cmbSerialPort.Items.AddRange(portNames);
                cmbSerialPort.SelectedIndex = 0;
            }
            
            UpdateControls();

            timerGeneral.Enabled = true;
        }

        // The window is about to be closed.
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loopWriteRegisters = false;

            Thread.Sleep(100);
            SerialClose();

            timerGeneral.Enabled = false;
        }

        // Serial port open button clicked.
        private void BtnOpenClose_Click(object sender, EventArgs e)
        {
            if (_serial.IsOpen != true)
            {
                SerialOpen();
            }
            else
            {
                SerialClose();
            }
        }
        
        // Register read button clicked.
        private async void BtnReadReg_Click(object sender, EventArgs e)
        {
            btnReadReg.Enabled = false;
            UpdateControlsWhileRegReading();

            if (byte.TryParse(tbReadRegAddr.Text, NumberStyles.HexNumber, null,  out byte reg) == true)
            {
                //Task<int> regReadTask = ReadRegisterAsync(reg);
                Task<int> regReadTask = Task.Run(() =>
                                                {
                                                    return Ssd1298ReadReg(reg);
                                                }
                                                );
                int regValue = await regReadTask;
                if (regValue > 0)
                {
                    tbReadRegValue.Text = string.Format("{0:X4}", regValue);
                }
                else
                {
                    tbReadRegValue.Text = "Read fail";
                }
            }

            btnReadReg.Enabled = true;
            UpdateControlsWhileRegReading();
        }
        
        // Register write button clicked.
        private void BtnWriteReg_Click(object sender, EventArgs e)
        {
            if (byte.TryParse(tbWriteRegAddr.Text, NumberStyles.HexNumber, null, out byte reg) == true)
            {
                if (UInt16.TryParse(tbWriteRegValue.Text, NumberStyles.HexNumber, null, out UInt16 regValue) == true)
                {
                    Ssd1298WriteReg(reg, regValue);
                }
            }
        }

        // Register-value pair file name select dialog button.
        private void BtnBatchWriteBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbBatchWriteFileName.Text = openFileDialog1.FileName;
            }
        }
        
        // Batch write button clicked.
        private async void BtnBatchWriteStartStop_Click(object sender, EventArgs e)
        {
            // First select a register-value pair file.

            btnBatchWriteStartStop.Enabled = false;
            UpdateUiWhileManyRegsWriting(false);

            if (_serial.IsOpen == true)
            {
                // ssd1289_init_reg_value.txt : SSD1289 initialization register values.
                if (!string.IsNullOrEmpty(tbBatchWriteFileName.Text))
                {
                    _rvPairs = Ssd1289Util.LoadRegisterValue(tbBatchWriteFileName.Text);
                    _loopWriteRegisters = true;

                    await DoBatchWrite();
                    _rvPairs.Clear();
                }
                else
                {
                    MessageBox.Show("Select register value file name.");
                }
            }

            btnBatchWriteStartStop.Enabled = true;
            UpdateUiWhileManyRegsWriting(true);
        }

        // DrawLine button clicked.
        private async void BtnDrawLine_Click(object sender, EventArgs e)
        {
            btnDrawLine.Enabled = false;
            UpdateUiWhileManyRegsWriting(false);

            // Register values for a diagonal line.
            //_rvPairs = Ssd1289Util.CreateLineWithBlack();

            // Register values for clearing the LCD with white color.
            // (It will take long time(a minute or so).
            //_rvPairs = Ssd1289Util.CreateBackgroudWithWhite();
            _rvPairs = Ssd1289Util.CreateBackgroudWithColor(_colors[_colorIndex++]);
            if (_colorIndex >= _colors.Length)
            {
                _colorIndex = 0;
            }
            _loopWriteRegisters = true;

            await DoBatchWrite();
            _rvPairs.Clear();

            btnDrawLine.Enabled = true;
            UpdateUiWhileManyRegsWriting(true);
        }

        // Batch-write-history button clicked.
        private void BtnBatchWriteClear_Click(object sender, EventArgs e)
        {
            lbBatchWriteHistory.Items.Clear();
        }

        // Do something on a general timer event.
        private void TimerGeneral_Tick(object sender, EventArgs e)
        {
            string[] messages = null;

            lock (_lock1)
            {
                messages = _registerWriteHistory.ToArray();
                _registerWriteHistory.Clear();
            }

            // Display the batch-write-history.
            if (messages?.Length > 0)
            {
                lbBatchWriteHistory.BeginUpdate();
                foreach (string message in messages)
                {
                    lbBatchWriteHistory.Items.Insert(0, message);
                }
                lbBatchWriteHistory.EndUpdate();
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _loopWriteRegisters = false;
        }
        #endregion
    }
}
