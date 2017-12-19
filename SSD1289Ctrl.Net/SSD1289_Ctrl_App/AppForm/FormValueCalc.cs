using SSD1289.Net;
using SSD1289_Ctrl_App.SSD1289;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSD1289_Ctrl_App.AppForm
{
    public partial class FormValueCalc : Form
    {
        private UInt32? _address;
        private UInt32? _value;
        
        public UInt32 RegisterAddress
        {
            get => ucRegValue.RegisterAddress;
        }

        public UInt32 RegisterValue
        {
            get => ucRegValue.RegisterValue;
        }

        public bool HasAddress
        {
            get => ucRegValue.HadAddress;
        }

        public FormValueCalc()
        {
            InitializeComponent();
        }

        public FormValueCalc(UInt32 address)
        {
            InitializeComponent();
            _address = address;
        }

        public FormValueCalc(UInt32 address, UInt32 value)
        {
            InitializeComponent();
            _address = address;
            _value = value;
        }

        private void FormValueCalc_Load(object sender, EventArgs e)
        {
            List<SSD1289Register> regTemplates = AppUtil.LoadRegister<SSD1289Register>("ssd1289.json");

            ucRegValue.RegisterTemplates = regTemplates;
            if (_address.HasValue)
            {
                ucRegValue.RegisterAddress = _address.Value;
            }
            else
            {
                ucRegValue.RegisterTemplates = regTemplates;
            }

            if (_value.HasValue)
            {
                ucRegValue.RegisterValue = _value.Value;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!ucRegValue.HasValue)
            {
                MessageBox.Show("No value.");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
