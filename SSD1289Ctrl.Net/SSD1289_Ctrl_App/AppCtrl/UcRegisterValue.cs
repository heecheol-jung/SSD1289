using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SSD1289.Net;
using SSD1289_Ctrl_App.AppForm;
using SSD1289_Ctrl_App.SSD1289;

namespace SSD1289_Ctrl_App.AppCtrl
{
    public partial class UcRegisterValue : UserControl
    {
        #region Private Data
        private List<SSD1289Register> _registerTemplates = null;
        private List<SSD1289BitField> _bitFields = new List<SSD1289BitField>();
        private BindingSource _bitFieldBindingSource = new BindingSource();
        private UInt32 _registerAddress;
        private UInt32 _registerValue = 0;
        private bool _addressSet = false;
        #endregion Private Data

        #region Public Properties
        public List<SSD1289Register> RegisterTemplates
        {
            set
            {
                if (_registerTemplates != value)
                {
                    _registerTemplates = value;
                    cmbAddress.DataSource = _registerTemplates;
                    cmbAddress.DisplayMember = "Address";

                    DisableAddressSelectoin();
                }
            }
        }
        public UInt32 RegisterAddress
        {
            get
            {
                if (cmbAddress.SelectedIndex >= 0)
                {
                    return ((SSD1289Register)cmbAddress.SelectedItem).Address;
                }
                else
                {
                    throw new Exception("No register selected.");
                }
            }

            set
            {
                _registerAddress = value;
                _addressSet = true;
                DisableAddressSelectoin();
            }
        }
        public UInt32 RegisterValue
        {
            get
            {
                return _registerValue;
            }
            set
            {
                _registerValue = value;
                if (_addressSet)
                {
                    SSD1289Register reg = (SSD1289Register)cmbAddress.SelectedItem;
                    reg.Value = _registerValue;
                    UpdateRegisterTemplateInfo();
                }
            }
        }
        public bool HasValue
        {
            get
            {
                if (_bitFields?.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HadAddress
        {
            get => (cmbAddress.SelectedIndex >= 0) ? true : false;
        }
        #endregion Public Properties

        #region Constructors
        public UcRegisterValue()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Private Methods
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

            if (_bitFieldBindingSource.DataSource == null)
            {
                _bitFieldBindingSource.DataSource = _bitFields;
            }
            _bitFieldBindingSource.Clear();

            if (dgvBitField.DataSource == null)
            {
                dgvBitField.DataSource = _bitFieldBindingSource;
            }

            if (regTemplate.Value.HasValue)
            {
                List<SSD1289BitField> bitFields = SSD1289BitField.CreateBitFieldsFromValue(regTemplate, regTemplate.Value.Value);
                if (bitFields?.Count > 0)
                {
                    foreach (SSD1289BitField item in bitFields)
                    {
                        _bitFieldBindingSource.Add(item);
                    }
                }
            }
        }

        private void DisableAddressSelectoin()
        {
            if (_addressSet == true && cmbAddress.Items.Count > 0)
            {
                foreach (SSD1289Register item in cmbAddress.Items)
                {
                    if (item.Address == _registerAddress)
                    {
                        cmbAddress.SelectedItem = item;
                        cmbAddress.Enabled = false;
                        break;
                    }
                }
            }
        }

        private void UpdateRegisterValueAndUi()
        {
            // Sort by Offset.
            _bitFields.Sort(delegate (SSD1289BitField x, SSD1289BitField y)
            {
                if (x.Offset == y.Offset) return 0;
                else if (x.Offset > y.Offset) return 1;
                else return -1;
            });
            
            _registerValue = SSD1289BitField.CalculateValueFromBitFields(_bitFields);
            tbValue.Text = string.Format($"{_registerValue:X4}");
        }
        #endregion Private Methods

        #region Event Handlers
        private void CmbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAddress.SelectedIndex < 0)
            {
                return;
            }

            UpdateRegisterTemplateInfo();
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
                    _bitFieldBindingSource.Add(frmBfValue.BitField);
                                        
                    UpdateRegisterValueAndUi();
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
                        _bitFieldBindingSource.ResetCurrentItem();

                        UpdateRegisterValueAndUi();
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

            _bitFieldBindingSource.RemoveAt(selectedIdx);

            UpdateRegisterValueAndUi();
        }

        private void DgvBitField_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_bitFields.Count > 0)
            {
                if (dgvBitField.Columns[e.ColumnIndex].DataPropertyName == "Value")
                {
                    SSD1289BitField bitField = (SSD1289BitField)dgvBitField.Rows[e.RowIndex].DataBoundItem;
                    e.Value = bitField.GetStringValueInHex();
                }
            }
        }

        private void BtnManualInput_Click(object sender, EventArgs e)
        {
            FormManualRegValue frmValue = new FormManualRegValue();
            if (frmValue.ShowDialog() == DialogResult.OK)
            {
                _bitFieldBindingSource.Clear();

                List<SSD1289BitField> bitFields = SSD1289BitField.CreateBitFieldsFromValue((SSD1289Register)cmbAddress.SelectedItem, frmValue.RegisterValue);
                if (bitFields?.Count > 0)
                {
                    foreach (SSD1289BitField item in bitFields)
                    {
                        _bitFieldBindingSource.Add(item);
                    }

                    UpdateRegisterValueAndUi();
                }
            }
            
        }
        #endregion Event Handlers
    }
}
