namespace SSD1289_Ctrl_App
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.gbRegRead = new System.Windows.Forms.GroupBox();
            this.btnReadReg = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblReadReg = new System.Windows.Forms.Label();
            this.lblReadRegValue = new System.Windows.Forms.Label();
            this.tbReadRegAddr = new System.Windows.Forms.TextBox();
            this.tbReadRegValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbRegWrite = new System.Windows.Forms.GroupBox();
            this.btnValueCalc = new System.Windows.Forms.Button();
            this.btnWriteReg = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblWriteReg = new System.Windows.Forms.Label();
            this.lblWriteRegValue = new System.Windows.Forms.Label();
            this.tbWriteRegAddr = new System.Windows.Forms.TextBox();
            this.tbWriteRegValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDrawLine = new System.Windows.Forms.Button();
            this.btnBatchWriteClear = new System.Windows.Forms.Button();
            this.btnBatchWriteStartStop = new System.Windows.Forms.Button();
            this.lbBatchWriteHistory = new System.Windows.Forms.ListBox();
            this.btnBatchWriteBrowse = new System.Windows.Forms.Button();
            this.tbBatchWriteFileName = new System.Windows.Forms.TextBox();
            this.timerGeneral = new System.Windows.Forms.Timer(this.components);
            this.lblSerialPort = new System.Windows.Forms.Label();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.gbRegRead.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbRegWrite.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Location = new System.Drawing.Point(175, 12);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(75, 23);
            this.btnOpenClose.TabIndex = 0;
            this.btnOpenClose.Text = "Open";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.BtnOpenClose_Click);
            // 
            // gbRegRead
            // 
            this.gbRegRead.Controls.Add(this.btnReadReg);
            this.gbRegRead.Controls.Add(this.tableLayoutPanel1);
            this.gbRegRead.Location = new System.Drawing.Point(13, 43);
            this.gbRegRead.Name = "gbRegRead";
            this.gbRegRead.Size = new System.Drawing.Size(260, 108);
            this.gbRegRead.TabIndex = 1;
            this.gbRegRead.TabStop = false;
            this.gbRegRead.Text = "Read";
            // 
            // btnReadReg
            // 
            this.btnReadReg.Location = new System.Drawing.Point(13, 74);
            this.btnReadReg.Name = "btnReadReg";
            this.btnReadReg.Size = new System.Drawing.Size(75, 23);
            this.btnReadReg.TabIndex = 1;
            this.btnReadReg.Text = "Read";
            this.btnReadReg.UseVisualStyleBackColor = true;
            this.btnReadReg.Click += new System.EventHandler(this.BtnReadReg_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.88991F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.11009F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.Controls.Add(this.lblReadReg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblReadRegValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbReadRegAddr, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbReadRegValue, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 48);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblReadReg
            // 
            this.lblReadReg.AutoSize = true;
            this.lblReadReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReadReg.Location = new System.Drawing.Point(3, 0);
            this.lblReadReg.Name = "lblReadReg";
            this.lblReadReg.Size = new System.Drawing.Size(60, 24);
            this.lblReadReg.TabIndex = 0;
            this.lblReadReg.Text = "Register";
            this.lblReadReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReadRegValue
            // 
            this.lblReadRegValue.AutoSize = true;
            this.lblReadRegValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReadRegValue.Location = new System.Drawing.Point(3, 24);
            this.lblReadRegValue.Name = "lblReadRegValue";
            this.lblReadRegValue.Size = new System.Drawing.Size(60, 24);
            this.lblReadRegValue.TabIndex = 1;
            this.lblReadRegValue.Text = "Value";
            this.lblReadRegValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbReadRegAddr
            // 
            this.tbReadRegAddr.Location = new System.Drawing.Point(100, 3);
            this.tbReadRegAddr.Name = "tbReadRegAddr";
            this.tbReadRegAddr.Size = new System.Drawing.Size(100, 20);
            this.tbReadRegAddr.TabIndex = 2;
            // 
            // tbReadRegValue
            // 
            this.tbReadRegValue.Location = new System.Drawing.Point(100, 27);
            this.tbReadRegValue.Name = "tbReadRegValue";
            this.tbReadRegValue.ReadOnly = true;
            this.tbReadRegValue.Size = new System.Drawing.Size(100, 20);
            this.tbReadRegValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(69, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "0x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(69, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "0x";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbRegWrite
            // 
            this.gbRegWrite.Controls.Add(this.btnValueCalc);
            this.gbRegWrite.Controls.Add(this.btnWriteReg);
            this.gbRegWrite.Controls.Add(this.tableLayoutPanel2);
            this.gbRegWrite.Location = new System.Drawing.Point(13, 157);
            this.gbRegWrite.Name = "gbRegWrite";
            this.gbRegWrite.Size = new System.Drawing.Size(260, 108);
            this.gbRegWrite.TabIndex = 2;
            this.gbRegWrite.TabStop = false;
            this.gbRegWrite.Text = "Write";
            // 
            // btnValueCalc
            // 
            this.btnValueCalc.Location = new System.Drawing.Point(94, 74);
            this.btnValueCalc.Name = "btnValueCalc";
            this.btnValueCalc.Size = new System.Drawing.Size(97, 23);
            this.btnValueCalc.TabIndex = 2;
            this.btnValueCalc.Text = "Value Calculator";
            this.btnValueCalc.UseVisualStyleBackColor = true;
            this.btnValueCalc.Click += new System.EventHandler(this.BtnValueCalc_Click);
            // 
            // btnWriteReg
            // 
            this.btnWriteReg.Location = new System.Drawing.Point(13, 74);
            this.btnWriteReg.Name = "btnWriteReg";
            this.btnWriteReg.Size = new System.Drawing.Size(75, 23);
            this.btnWriteReg.TabIndex = 1;
            this.btnWriteReg.Text = "Write";
            this.btnWriteReg.UseVisualStyleBackColor = true;
            this.btnWriteReg.Click += new System.EventHandler(this.BtnWriteReg_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.09346F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.90654F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel2.Controls.Add(this.lblWriteReg, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblWriteRegValue, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbWriteRegAddr, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbWriteRegValue, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 48);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblWriteReg
            // 
            this.lblWriteReg.AutoSize = true;
            this.lblWriteReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWriteReg.Location = new System.Drawing.Point(3, 0);
            this.lblWriteReg.Name = "lblWriteReg";
            this.lblWriteReg.Size = new System.Drawing.Size(61, 24);
            this.lblWriteReg.TabIndex = 0;
            this.lblWriteReg.Text = "Register";
            this.lblWriteReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWriteRegValue
            // 
            this.lblWriteRegValue.AutoSize = true;
            this.lblWriteRegValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWriteRegValue.Location = new System.Drawing.Point(3, 24);
            this.lblWriteRegValue.Name = "lblWriteRegValue";
            this.lblWriteRegValue.Size = new System.Drawing.Size(61, 24);
            this.lblWriteRegValue.TabIndex = 1;
            this.lblWriteRegValue.Text = "Value";
            this.lblWriteRegValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbWriteRegAddr
            // 
            this.tbWriteRegAddr.Location = new System.Drawing.Point(99, 3);
            this.tbWriteRegAddr.Name = "tbWriteRegAddr";
            this.tbWriteRegAddr.Size = new System.Drawing.Size(100, 20);
            this.tbWriteRegAddr.TabIndex = 2;
            // 
            // tbWriteRegValue
            // 
            this.tbWriteRegValue.Location = new System.Drawing.Point(99, 27);
            this.tbWriteRegValue.Name = "tbWriteRegValue";
            this.tbWriteRegValue.Size = new System.Drawing.Size(100, 20);
            this.tbWriteRegValue.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(70, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "0x";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(70, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "0x";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnDrawLine);
            this.groupBox1.Controls.Add(this.btnBatchWriteClear);
            this.groupBox1.Controls.Add(this.btnBatchWriteStartStop);
            this.groupBox1.Controls.Add(this.lbBatchWriteHistory);
            this.groupBox1.Controls.Add(this.btnBatchWriteBrowse);
            this.groupBox1.Controls.Add(this.tbBatchWriteFileName);
            this.groupBox1.Location = new System.Drawing.Point(279, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 284);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Write";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(87, 252);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnDrawLine
            // 
            this.btnDrawLine.Location = new System.Drawing.Point(6, 252);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(75, 23);
            this.btnDrawLine.TabIndex = 5;
            this.btnDrawLine.Text = "Line";
            this.btnDrawLine.UseVisualStyleBackColor = true;
            this.btnDrawLine.Click += new System.EventHandler(this.BtnDrawLine_Click);
            // 
            // btnBatchWriteClear
            // 
            this.btnBatchWriteClear.Location = new System.Drawing.Point(179, 223);
            this.btnBatchWriteClear.Name = "btnBatchWriteClear";
            this.btnBatchWriteClear.Size = new System.Drawing.Size(75, 23);
            this.btnBatchWriteClear.TabIndex = 4;
            this.btnBatchWriteClear.Text = "Clear";
            this.btnBatchWriteClear.UseVisualStyleBackColor = true;
            this.btnBatchWriteClear.Click += new System.EventHandler(this.BtnBatchWriteClear_Click);
            // 
            // btnBatchWriteStartStop
            // 
            this.btnBatchWriteStartStop.Location = new System.Drawing.Point(6, 223);
            this.btnBatchWriteStartStop.Name = "btnBatchWriteStartStop";
            this.btnBatchWriteStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnBatchWriteStartStop.TabIndex = 3;
            this.btnBatchWriteStartStop.Text = "Start";
            this.btnBatchWriteStartStop.UseVisualStyleBackColor = true;
            this.btnBatchWriteStartStop.Click += new System.EventHandler(this.BtnBatchWriteStartStop_Click);
            // 
            // lbBatchWriteHistory
            // 
            this.lbBatchWriteHistory.FormattingEnabled = true;
            this.lbBatchWriteHistory.Location = new System.Drawing.Point(6, 47);
            this.lbBatchWriteHistory.Name = "lbBatchWriteHistory";
            this.lbBatchWriteHistory.Size = new System.Drawing.Size(248, 173);
            this.lbBatchWriteHistory.TabIndex = 2;
            // 
            // btnBatchWriteBrowse
            // 
            this.btnBatchWriteBrowse.Location = new System.Drawing.Point(179, 17);
            this.btnBatchWriteBrowse.Name = "btnBatchWriteBrowse";
            this.btnBatchWriteBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBatchWriteBrowse.TabIndex = 1;
            this.btnBatchWriteBrowse.Text = "Browse";
            this.btnBatchWriteBrowse.UseVisualStyleBackColor = true;
            this.btnBatchWriteBrowse.Click += new System.EventHandler(this.BtnBatchWriteBrowse_Click);
            // 
            // tbBatchWriteFileName
            // 
            this.tbBatchWriteFileName.Location = new System.Drawing.Point(6, 20);
            this.tbBatchWriteFileName.Name = "tbBatchWriteFileName";
            this.tbBatchWriteFileName.ReadOnly = true;
            this.tbBatchWriteFileName.Size = new System.Drawing.Size(167, 20);
            this.tbBatchWriteFileName.TabIndex = 0;
            // 
            // timerGeneral
            // 
            this.timerGeneral.Tick += new System.EventHandler(this.TimerGeneral_Tick);
            // 
            // lblSerialPort
            // 
            this.lblSerialPort.AutoSize = true;
            this.lblSerialPort.Location = new System.Drawing.Point(17, 17);
            this.lblSerialPort.Name = "lblSerialPort";
            this.lblSerialPort.Size = new System.Drawing.Size(26, 13);
            this.lblSerialPort.TabIndex = 4;
            this.lblSerialPort.Text = "Port";
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(48, 12);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(121, 21);
            this.cmbSerialPort.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 313);
            this.Controls.Add(this.cmbSerialPort);
            this.Controls.Add(this.lblSerialPort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRegWrite);
            this.Controls.Add(this.gbRegRead);
            this.Controls.Add(this.btnOpenClose);
            this.Name = "FormMain";
            this.Text = "SSD1289 Control APP.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.gbRegRead.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbRegWrite.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.GroupBox gbRegRead;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblReadReg;
        private System.Windows.Forms.Label lblReadRegValue;
        private System.Windows.Forms.TextBox tbReadRegAddr;
        private System.Windows.Forms.TextBox tbReadRegValue;
        private System.Windows.Forms.Button btnReadReg;
        private System.Windows.Forms.GroupBox gbRegWrite;
        private System.Windows.Forms.Button btnWriteReg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblWriteReg;
        private System.Windows.Forms.Label lblWriteRegValue;
        private System.Windows.Forms.TextBox tbWriteRegAddr;
        private System.Windows.Forms.TextBox tbWriteRegValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBatchWriteClear;
        private System.Windows.Forms.Button btnBatchWriteStartStop;
        private System.Windows.Forms.ListBox lbBatchWriteHistory;
        private System.Windows.Forms.Button btnBatchWriteBrowse;
        private System.Windows.Forms.TextBox tbBatchWriteFileName;
        private System.Windows.Forms.Timer timerGeneral;
        private System.Windows.Forms.Button btnDrawLine;
        private System.Windows.Forms.Label lblSerialPort;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnValueCalc;
    }
}

