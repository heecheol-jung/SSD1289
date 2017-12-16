namespace SSD1289_Ctrl_App.AppCtrl
{
    partial class UcRegisterValue
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAddress = new System.Windows.Forms.Label();
            this.cmbAddress = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbBits = new System.Windows.Forms.TextBox();
            this.lblBits = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.tbRW = new System.Windows.Forms.TextBox();
            this.lblRW = new System.Windows.Forms.Label();
            this.tbDC = new System.Windows.Forms.TextBox();
            this.lblDC = new System.Windows.Forms.Label();
            this.btnManualInput = new System.Windows.Forms.Button();
            this.gbBitField = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEditBitField = new System.Windows.Forms.Button();
            this.btnAddBitField = new System.Windows.Forms.Button();
            this.dgvBitField = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBitField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitField)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(10, 15);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address";
            // 
            // cmbAddress
            // 
            this.cmbAddress.FormattingEnabled = true;
            this.cmbAddress.Location = new System.Drawing.Point(93, 12);
            this.cmbAddress.Name = "cmbAddress";
            this.cmbAddress.Size = new System.Drawing.Size(121, 21);
            this.cmbAddress.TabIndex = 1;
            this.cmbAddress.SelectedIndexChanged += new System.EventHandler(this.CmbAddress_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(93, 40);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 3;
            // 
            // tbBits
            // 
            this.tbBits.Location = new System.Drawing.Point(93, 67);
            this.tbBits.Name = "tbBits";
            this.tbBits.ReadOnly = true;
            this.tbBits.Size = new System.Drawing.Size(121, 20);
            this.tbBits.TabIndex = 5;
            // 
            // lblBits
            // 
            this.lblBits.AutoSize = true;
            this.lblBits.Location = new System.Drawing.Point(10, 70);
            this.lblBits.Name = "lblBits";
            this.lblBits.Size = new System.Drawing.Size(24, 13);
            this.lblBits.TabIndex = 4;
            this.lblBits.Text = "Bits";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(93, 94);
            this.tbValue.Name = "tbValue";
            this.tbValue.ReadOnly = true;
            this.tbValue.Size = new System.Drawing.Size(121, 20);
            this.tbValue.TabIndex = 7;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(10, 97);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 6;
            this.lblValue.Text = "Value";
            // 
            // tbRW
            // 
            this.tbRW.Location = new System.Drawing.Point(331, 12);
            this.tbRW.Name = "tbRW";
            this.tbRW.ReadOnly = true;
            this.tbRW.Size = new System.Drawing.Size(121, 20);
            this.tbRW.TabIndex = 9;
            // 
            // lblRW
            // 
            this.lblRW.AutoSize = true;
            this.lblRW.Location = new System.Drawing.Point(248, 15);
            this.lblRW.Name = "lblRW";
            this.lblRW.Size = new System.Drawing.Size(31, 13);
            this.lblRW.TabIndex = 8;
            this.lblRW.Text = "R/W";
            // 
            // tbDC
            // 
            this.tbDC.Location = new System.Drawing.Point(331, 40);
            this.tbDC.Name = "tbDC";
            this.tbDC.ReadOnly = true;
            this.tbDC.Size = new System.Drawing.Size(121, 20);
            this.tbDC.TabIndex = 11;
            // 
            // lblDC
            // 
            this.lblDC.AutoSize = true;
            this.lblDC.Location = new System.Drawing.Point(248, 43);
            this.lblDC.Name = "lblDC";
            this.lblDC.Size = new System.Drawing.Size(22, 13);
            this.lblDC.TabIndex = 10;
            this.lblDC.Text = "DC";
            // 
            // btnManualInput
            // 
            this.btnManualInput.Location = new System.Drawing.Point(220, 92);
            this.btnManualInput.Name = "btnManualInput";
            this.btnManualInput.Size = new System.Drawing.Size(97, 23);
            this.btnManualInput.TabIndex = 12;
            this.btnManualInput.Text = "Manual Input";
            this.btnManualInput.UseVisualStyleBackColor = true;
            // 
            // gbBitField
            // 
            this.gbBitField.Controls.Add(this.btnDelete);
            this.gbBitField.Controls.Add(this.btnEditBitField);
            this.gbBitField.Controls.Add(this.btnAddBitField);
            this.gbBitField.Controls.Add(this.dgvBitField);
            this.gbBitField.Location = new System.Drawing.Point(13, 121);
            this.gbBitField.Name = "gbBitField";
            this.gbBitField.Size = new System.Drawing.Size(439, 254);
            this.gbBitField.TabIndex = 13;
            this.gbBitField.TabStop = false;
            this.gbBitField.Text = "Bit Field";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(169, 225);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnEditBitField
            // 
            this.btnEditBitField.Location = new System.Drawing.Point(88, 225);
            this.btnEditBitField.Name = "btnEditBitField";
            this.btnEditBitField.Size = new System.Drawing.Size(75, 23);
            this.btnEditBitField.TabIndex = 2;
            this.btnEditBitField.Text = "Edit";
            this.btnEditBitField.UseVisualStyleBackColor = true;
            this.btnEditBitField.Click += new System.EventHandler(this.BtnEditBitField_Click);
            // 
            // btnAddBitField
            // 
            this.btnAddBitField.Location = new System.Drawing.Point(7, 225);
            this.btnAddBitField.Name = "btnAddBitField";
            this.btnAddBitField.Size = new System.Drawing.Size(75, 23);
            this.btnAddBitField.TabIndex = 1;
            this.btnAddBitField.Text = "Add";
            this.btnAddBitField.UseVisualStyleBackColor = true;
            this.btnAddBitField.Click += new System.EventHandler(this.BtnAddBitField_Click);
            // 
            // dgvBitField
            // 
            this.dgvBitField.AllowUserToAddRows = false;
            this.dgvBitField.AllowUserToDeleteRows = false;
            this.dgvBitField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colOffset,
            this.colBits,
            this.colValue,
            this.colDesc});
            this.dgvBitField.Location = new System.Drawing.Point(7, 20);
            this.dgvBitField.MultiSelect = false;
            this.dgvBitField.Name = "dgvBitField";
            this.dgvBitField.ReadOnly = true;
            this.dgvBitField.Size = new System.Drawing.Size(426, 199);
            this.dgvBitField.TabIndex = 0;
            this.dgvBitField.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvBitField_CellFormatting);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colOffset
            // 
            this.colOffset.DataPropertyName = "Offset";
            this.colOffset.HeaderText = "Offset";
            this.colOffset.Name = "colOffset";
            this.colOffset.ReadOnly = true;
            this.colOffset.Width = 60;
            // 
            // colBits
            // 
            this.colBits.DataPropertyName = "Bits";
            this.colBits.HeaderText = "Bits";
            this.colBits.Name = "colBits";
            this.colBits.ReadOnly = true;
            this.colBits.Width = 60;
            // 
            // colValue
            // 
            this.colValue.DataPropertyName = "Value";
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.Width = 60;
            // 
            // colDesc
            // 
            this.colDesc.DataPropertyName = "Description";
            this.colDesc.HeaderText = "Description";
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            // 
            // UcRegisterValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBitField);
            this.Controls.Add(this.btnManualInput);
            this.Controls.Add(this.tbDC);
            this.Controls.Add(this.lblDC);
            this.Controls.Add(this.tbRW);
            this.Controls.Add(this.lblRW);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.tbBits);
            this.Controls.Add(this.lblBits);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmbAddress);
            this.Controls.Add(this.lblAddress);
            this.Name = "UcRegisterValue";
            this.Size = new System.Drawing.Size(462, 386);
            this.gbBitField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cmbAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbBits;
        private System.Windows.Forms.Label lblBits;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox tbRW;
        private System.Windows.Forms.Label lblRW;
        private System.Windows.Forms.TextBox tbDC;
        private System.Windows.Forms.Label lblDC;
        private System.Windows.Forms.Button btnManualInput;
        private System.Windows.Forms.GroupBox gbBitField;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEditBitField;
        private System.Windows.Forms.Button btnAddBitField;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridView dgvBitField;
    }
}
