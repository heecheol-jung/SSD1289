using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSD1289_Ctrl_App.AppForm
{
    public partial class FormManualRegValue : Form
    {
        private UInt32 _registerValue = 0;

        public UInt32 RegisterValue
        {
            get
            {
                return _registerValue;
            }
        }
        public FormManualRegValue()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbValue.Text))
            {
                MessageBox.Show("No input.");
                return;
            }

            if (UInt32.TryParse(tbValue.Text, System.Globalization.NumberStyles.HexNumber, null, out _registerValue))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No hexadecimal value.");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
