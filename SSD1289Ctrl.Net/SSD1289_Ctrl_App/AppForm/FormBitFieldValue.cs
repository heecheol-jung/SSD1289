using SSD1289.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSD1289_Ctrl_App.AppForm
{
    public partial class FormBitFieldValue : Form
    {
        List<SSD1289BitField> _bfTemplates = null;
        SSD1289BitField _bitField = null;
        //SSD1289BitField _bitFieldOrig = null;
        bool _continue = false;
        private BindingSource _bitFieldBinding = new BindingSource();

        public SSD1289BitField BitField
        {
            get => _bitField;
        }

        public bool Continue
        {
            get => _continue;
        }

        public FormBitFieldValue()
        {
            InitializeComponent();
        }

        public FormBitFieldValue(SSD1289BitField bitField)
        {
            InitializeComponent();
            _bitField = bitField;
        }

        public FormBitFieldValue(List<SSD1289BitField> bfTemplates)
        {
            InitializeComponent();
            _bfTemplates = bfTemplates;
        }

        private bool SetValue()
        {
            if (cmbOffset.SelectedIndex < 0)
            {
                MessageBox.Show("No bit field is selected.");
                return false;
            }
            if (string.IsNullOrEmpty(tbValue.Text))
            {
                MessageBox.Show("No value entered.");
                return false;
            }

            SSD1289BitField bitField = (SSD1289BitField)cmbOffset.SelectedItem;
            if (!UInt32.TryParse(tbValue.Text, NumberStyles.HexNumber, null, out UInt32 value))
            {
                MessageBox.Show("Value should be hexadecimal number.");
                return false;
            }

            bool outOfRange = false;
            if (bitField.Bits == 1)
            {
                if (value > 1)
                {
                    outOfRange = true;
                }
            }
            else if ((bitField.Bits > 1) && (bitField.Bits <= 8))
            {
                if (value > byte.MaxValue)
                {
                    outOfRange = true;
                }
            }
            else if ((bitField.Bits > 8) && (bitField.Bits <= 16))
            {
                if (value > UInt16.MaxValue)
                {
                    outOfRange = true;
                }
            }
            else if ((bitField.Bits > 16) && (bitField.Bits <= 32))
            {
                if (value > UInt32.MaxValue)
                {
                    outOfRange = true;
                }
            }
            else
            {
                outOfRange = true;
            }

            if (outOfRange)
            {
                MessageBox.Show("Out-of-range value.");
                return false;
            }

            _bitField = new SSD1289BitField
            {
                Bits = bitField.Bits,
                Description = bitField.Description,
                Name = bitField.Name,
                Offset = bitField.Offset,
                Value = value
            };

            return true;
        }

        private void FormBitFieldValue_Load(object sender, EventArgs e)
        {
            if (_bitField != null)
            {
                _bfTemplates = new List<SSD1289BitField>();
                _bfTemplates.Add(_bitField);
            }

            //_bitFieldBinding.DataSource = _bfTemplates;
            //cmbOffset.DataSource = _bitFieldBinding;
            cmbOffset.DataSource = _bfTemplates;
            if (cmbOffset.Items.Count > 0)
            {
                cmbOffset.SelectedIndex = 0;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            SetValue();
            DialogResult = DialogResult.OK;
        }

        private void BtnOkContinue_Click(object sender, EventArgs e)
        {
            SetValue();
            _continue = true;
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CmbOffset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOffset.SelectedIndex >= 0)
            {
                SSD1289BitField bf = (SSD1289BitField)cmbOffset.SelectedItem;
                tbName.Text = bf.Name;
                tbBits.Text = "" + bf.Bits;
                tbValue.Text = bf.GetStringValueInHex();
            }
        }
    }
}
