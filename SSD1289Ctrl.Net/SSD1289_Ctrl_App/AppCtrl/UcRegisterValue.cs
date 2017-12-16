using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSD1289.Net;
using SSD1289_Ctrl_App.AppForm;
using SSD1289_Ctrl_App.SSD1289;

namespace SSD1289_Ctrl_App.AppCtrl
{
    public partial class UcRegisterValue : UserControl
    {
        private List<SSD1289Register> _registerTemplates = null;
        private List<SSD1289BitField> _bitFields = new List<SSD1289BitField>();

        public List<SSD1289Register> RegisterTemplates
        {
            set
            {
                if (_registerTemplates != value)
                {
                    _registerTemplates = value;
                    cmbAddress.DataSource = _registerTemplates;
                    cmbAddress.DisplayMember = "Address";
                }
            }
        }
        public UInt32 RegisterAddress { get; set; }
        public UInt32 RegisterValue { get; set; }

        public UcRegisterValue()
        {
            InitializeComponent();
        }

        private void CmbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAddress.SelectedIndex < 0)
            {
                return;
            }

            UpdateRegisterTemplateInfo();
        }

        private void UpdateRegisterTemplateInfo()
        {
            SSD1289Register regTemplate = (SSD1289Register)cmbAddress.SelectedItem;

            tbName.Text = regTemplate.Name;
            tbBits.Text = "" + regTemplate.Bits;
            tbDC.Text = "" + regTemplate.DC;
            tbRW.Text = "" + regTemplate.RW;

            if (regTemplate.Value.HasValue)
            {
                tbValue.Text = string.Format($"{regTemplate.Value:X4}");
            }

            // 아래 코드는 row선택시 인덱스관련 예외 발생.
            // dgvBitField.DataSource = _bitFields;
            dgvBitField.DataSource = _bitFields.ToArray();
        }

        private void BtnAddBitField_Click(object sender, EventArgs e)
        {
            SSD1289Register regTemplate = (SSD1289Register)cmbAddress.SelectedItem;
            FormBitFieldValue frmBfValue = null;

            do
            {
                List<SSD1289BitField> bitFields = AppUtil.CreateUniqueBitFields(regTemplate.BitFields, _bitFields);
                if (bitFields == null || bitFields.Count == 0)
                {
                    MessageBox.Show("All bit fields added.");
                    return;
                }
                frmBfValue = new FormBitFieldValue(bitFields);
                if (frmBfValue.ShowDialog() == DialogResult.OK)
                {
                    _bitFields.Add(frmBfValue.BitField);
                    dgvBitField.DataSource = null;
                    dgvBitField.DataSource = _bitFields.ToArray();

                    tbValue.Text = string.Format($"{SSD1289BitField.CalculateValueFromBitFields(_bitFields):X4}");
                }
            } while (frmBfValue.Continue);
        }

        private void BtnEditBitField_Click(object sender, EventArgs e)
        {
            SSD1289BitField bitField = null;

            if (dgvBitField.SelectedCells.Count > 0)
            {
                bitField = (SSD1289BitField)dgvBitField.Rows[dgvBitField.SelectedCells[0].RowIndex].DataBoundItem;
            }
            else if (dgvBitField.SelectedRows.Count > 0)
            {
                bitField = (SSD1289BitField)dgvBitField.SelectedRows[0].DataBoundItem;
            }

            if (bitField != null)
            {               
                FormBitFieldValue frmBfValue = new FormBitFieldValue(bitField);
                if (frmBfValue.ShowDialog() == DialogResult.OK)
                {
                    if (bitField.Value != frmBfValue.BitField.Value)
                    {
                        bitField.Value = frmBfValue.BitField.Value;
                        dgvBitField.Refresh();

                        tbValue.Text = string.Format($"{SSD1289BitField.CalculateValueFromBitFields(_bitFields):X4}");
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SSD1289BitField bitField = null;
            int selectedIdx = -1;

            if (dgvBitField.SelectedCells.Count > 0)
            {
                selectedIdx = dgvBitField.SelectedCells[0].RowIndex;
                bitField = (SSD1289BitField)dgvBitField.Rows[selectedIdx].DataBoundItem;
            }
            else if (dgvBitField.SelectedRows.Count > 0)
            {
                selectedIdx = dgvBitField.SelectedRows[0].Index;
                bitField = (SSD1289BitField)dgvBitField.SelectedRows[0].DataBoundItem;
            }

            // DataSource를 array로 한상태에서 dgvBitField.Rows.RemoveAt(selectedIdx)명령은 예외 발생.
            // dgvBitField.DataSource = _bitFields.ToArray();
            // System.InvalidOperationException: Rows cannot be programmatically removed unless the DataGridView is data-bound to an IBindingList that supports change notification and allows deletion.
            dgvBitField.Rows.RemoveAt(selectedIdx);
            _bitFields.Remove(bitField);
            dgvBitField.Refresh();
        }

        private void DgvBitField_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBitField.Columns[e.ColumnIndex].Name == "Value")
            {
                SSD1289BitField bitField = (SSD1289BitField)dgvBitField.Rows[e.RowIndex].DataBoundItem;
                e.Value = bitField.GetStringValueInHex();
            }
        }
    }
}
