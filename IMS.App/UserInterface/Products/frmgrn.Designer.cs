namespace IMS.App
{
    partial class frmgrn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmgrn));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxWherehouseCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.ERRYourRefNo = new System.Windows.Forms.PictureBox();
            this.dateTimePickerDueDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPayables = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxYourRefNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxGrnRefNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxOurRefNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerGranDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGrnNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewGRN = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inv_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDis2 = new System.Windows.Forms.TextBox();
            this.textBoxDis1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxTaxes = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxNetValue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxGrossValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ErrLocation = new System.Windows.Forms.PictureBox();
            this.ErrSupplier = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ERRYourRefNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGRN)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location";
            // 
            // comboBoxWherehouseCombo
            // 
            this.comboBoxWherehouseCombo.FormattingEnabled = true;
            this.comboBoxWherehouseCombo.Location = new System.Drawing.Point(154, 50);
            this.comboBoxWherehouseCombo.Name = "comboBoxWherehouseCombo";
            this.comboBoxWherehouseCombo.Size = new System.Drawing.Size(247, 28);
            this.comboBoxWherehouseCombo.TabIndex = 1;
            this.comboBoxWherehouseCombo.TextChanged += new System.EventHandler(this.comboBoxWherehouseCombo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Supplier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address :-";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(154, 126);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(256, 85);
            this.textBoxAddress.TabIndex = 5;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Location = new System.Drawing.Point(154, 220);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(349, 52);
            this.textBoxRemarks.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Remarks";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.ERRYourRefNo);
            this.groupBox1.Controls.Add(this.dateTimePickerDueDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBoxPayables);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxYourRefNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxGrnRefNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxOurRefNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimePickerGranDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxGrnNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(579, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 284);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Crimson;
            this.label31.Location = new System.Drawing.Point(129, 179);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(21, 25);
            this.label31.TabIndex = 83;
            this.label31.Text = "*";
            // 
            // ERRYourRefNo
            // 
            this.ERRYourRefNo.BackColor = System.Drawing.Color.Transparent;
            this.ERRYourRefNo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ERRYourRefNo.BackgroundImage")));
            this.ERRYourRefNo.Image = ((System.Drawing.Image)(resources.GetObject("ERRYourRefNo.Image")));
            this.ERRYourRefNo.Location = new System.Drawing.Point(434, 171);
            this.ERRYourRefNo.Name = "ERRYourRefNo";
            this.ERRYourRefNo.Size = new System.Drawing.Size(35, 27);
            this.ERRYourRefNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ERRYourRefNo.TabIndex = 82;
            this.ERRYourRefNo.TabStop = false;
            // 
            // dateTimePickerDueDate
            // 
            this.dateTimePickerDueDate.Location = new System.Drawing.Point(156, 248);
            this.dateTimePickerDueDate.Name = "dateTimePickerDueDate";
            this.dateTimePickerDueDate.Size = new System.Drawing.Size(301, 26);
            this.dateTimePickerDueDate.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "Due Date";
            // 
            // textBoxPayables
            // 
            this.textBoxPayables.Location = new System.Drawing.Point(156, 210);
            this.textBoxPayables.Name = "textBoxPayables";
            this.textBoxPayables.Size = new System.Drawing.Size(256, 26);
            this.textBoxPayables.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Payables";
            // 
            // textBoxYourRefNo
            // 
            this.textBoxYourRefNo.Location = new System.Drawing.Point(156, 172);
            this.textBoxYourRefNo.Name = "textBoxYourRefNo";
            this.textBoxYourRefNo.Size = new System.Drawing.Size(256, 26);
            this.textBoxYourRefNo.TabIndex = 18;
            this.textBoxYourRefNo.TextChanged += new System.EventHandler(this.textBoxYourRefNo_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Your Ref No";
            // 
            // textBoxGrnRefNo
            // 
            this.textBoxGrnRefNo.Location = new System.Drawing.Point(156, 124);
            this.textBoxGrnRefNo.Name = "textBoxGrnRefNo";
            this.textBoxGrnRefNo.Size = new System.Drawing.Size(256, 26);
            this.textBoxGrnRefNo.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "GRN Ref";
            // 
            // textBoxOurRefNo
            // 
            this.textBoxOurRefNo.Location = new System.Drawing.Point(156, 88);
            this.textBoxOurRefNo.Name = "textBoxOurRefNo";
            this.textBoxOurRefNo.Size = new System.Drawing.Size(256, 26);
            this.textBoxOurRefNo.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Our Ref No";
            // 
            // dateTimePickerGranDate
            // 
            this.dateTimePickerGranDate.Location = new System.Drawing.Point(156, 48);
            this.dateTimePickerGranDate.Name = "dateTimePickerGranDate";
            this.dateTimePickerGranDate.Size = new System.Drawing.Size(301, 26);
            this.dateTimePickerGranDate.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "GRN Date";
            // 
            // textBoxGrnNumber
            // 
            this.textBoxGrnNumber.Location = new System.Drawing.Point(156, 8);
            this.textBoxGrnNumber.Name = "textBoxGrnNumber";
            this.textBoxGrnNumber.ReadOnly = true;
            this.textBoxGrnNumber.Size = new System.Drawing.Size(256, 26);
            this.textBoxGrnNumber.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "GRN NO";
            // 
            // dataGridViewGRN
            // 
            this.dataGridViewGRN.AllowUserToOrderColumns = true;
            this.dataGridViewGRN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGRN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Description,
            this.inv_Qty,
            this.MRP,
            this.Cost_Price,
            this.Value,
            this.Dis});
            this.dataGridViewGRN.Location = new System.Drawing.Point(44, 284);
            this.dataGridViewGRN.Name = "dataGridViewGRN";
            this.dataGridViewGRN.RowTemplate.Height = 24;
            this.dataGridViewGRN.Size = new System.Drawing.Size(1136, 257);
            this.dataGridViewGRN.TabIndex = 9;
            this.dataGridViewGRN.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewGRN_CellMouseClick);
            this.dataGridViewGRN.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGRN_CellValueChanged);
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 300;
            // 
            // inv_Qty
            // 
            this.inv_Qty.HeaderText = "inv Qty";
            this.inv_Qty.Name = "inv_Qty";
            // 
            // MRP
            // 
            this.MRP.FillWeight = 150F;
            this.MRP.HeaderText = "MRP";
            this.MRP.Name = "MRP";
            this.MRP.Width = 150;
            // 
            // Cost_Price
            // 
            this.Cost_Price.FillWeight = 150F;
            this.Cost_Price.HeaderText = "Cost_Price";
            this.Cost_Price.Name = "Cost_Price";
            this.Cost_Price.Width = 150;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Width = 150;
            // 
            // Dis
            // 
            this.Dis.HeaderText = "Dis %";
            this.Dis.Name = "Dis";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDis2);
            this.groupBox2.Controls.Add(this.textBoxDis1);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBoxTaxes);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBoxNetValue);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.textBoxGrossValue);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(36, 547);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1144, 129);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // textBoxDis2
            // 
            this.textBoxDis2.Location = new System.Drawing.Point(940, 21);
            this.textBoxDis2.Name = "textBoxDis2";
            this.textBoxDis2.ReadOnly = true;
            this.textBoxDis2.Size = new System.Drawing.Size(161, 26);
            this.textBoxDis2.TabIndex = 31;
            // 
            // textBoxDis1
            // 
            this.textBoxDis1.Location = new System.Drawing.Point(869, 21);
            this.textBoxDis1.Name = "textBoxDis1";
            this.textBoxDis1.Size = new System.Drawing.Size(52, 26);
            this.textBoxDis1.TabIndex = 30;
            this.textBoxDis1.TextChanged += new System.EventHandler(this.textBoxDis1_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(804, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "Dis %";
            // 
            // textBoxTaxes
            // 
            this.textBoxTaxes.Location = new System.Drawing.Point(521, 18);
            this.textBoxTaxes.Name = "textBoxTaxes";
            this.textBoxTaxes.ReadOnly = true;
            this.textBoxTaxes.Size = new System.Drawing.Size(256, 26);
            this.textBoxTaxes.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(437, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 20);
            this.label14.TabIndex = 27;
            this.label14.Text = "Taxes";
            // 
            // textBoxNetValue
            // 
            this.textBoxNetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNetValue.Location = new System.Drawing.Point(150, 74);
            this.textBoxNetValue.Name = "textBoxNetValue";
            this.textBoxNetValue.ReadOnly = true;
            this.textBoxNetValue.Size = new System.Drawing.Size(256, 34);
            this.textBoxNetValue.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 25);
            this.label13.TabIndex = 25;
            this.label13.Text = "Net Value";
            // 
            // textBoxGrossValue
            // 
            this.textBoxGrossValue.Location = new System.Drawing.Point(150, 18);
            this.textBoxGrossValue.Name = "textBoxGrossValue";
            this.textBoxGrossValue.ReadOnly = true;
            this.textBoxGrossValue.Size = new System.Drawing.Size(256, 26);
            this.textBoxGrossValue.TabIndex = 24;
            this.textBoxGrossValue.TextChanged += new System.EventHandler(this.textBoxGrossValue_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "Gross Value";
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(154, 92);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(247, 28);
            this.comboBoxSupplier.TabIndex = 11;
            this.comboBoxSupplier.TextChanged += new System.EventHandler(this.comboBoxSupplier_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 682);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 48);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(675, 682);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 48);
            this.button2.TabIndex = 13;
            this.button2.Text = "Clear / New";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(461, 682);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 48);
            this.button3.TabIndex = 14;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ErrLocation
            // 
            this.ErrLocation.BackColor = System.Drawing.Color.Transparent;
            this.ErrLocation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ErrLocation.BackgroundImage")));
            this.ErrLocation.Image = ((System.Drawing.Image)(resources.GetObject("ErrLocation.Image")));
            this.ErrLocation.Location = new System.Drawing.Point(424, 51);
            this.ErrLocation.Name = "ErrLocation";
            this.ErrLocation.Size = new System.Drawing.Size(35, 27);
            this.ErrLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ErrLocation.TabIndex = 84;
            this.ErrLocation.TabStop = false;
            // 
            // ErrSupplier
            // 
            this.ErrSupplier.BackColor = System.Drawing.Color.Transparent;
            this.ErrSupplier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ErrSupplier.BackgroundImage")));
            this.ErrSupplier.Image = ((System.Drawing.Image)(resources.GetObject("ErrSupplier.Image")));
            this.ErrSupplier.Location = new System.Drawing.Point(424, 88);
            this.ErrSupplier.Name = "ErrSupplier";
            this.ErrSupplier.Size = new System.Drawing.Size(35, 27);
            this.ErrSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ErrSupplier.TabIndex = 85;
            this.ErrSupplier.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Crimson;
            this.label16.Location = new System.Drawing.Point(127, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 25);
            this.label16.TabIndex = 86;
            this.label16.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(127, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 25);
            this.label17.TabIndex = 87;
            this.label17.Text = "*";
            // 
            // frmgrn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 737);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ErrSupplier);
            this.Controls.Add(this.ErrLocation);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxSupplier);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewGRN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxWherehouseCombo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmgrn";
            this.Text = "frmgrn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmgrn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ERRYourRefNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGRN)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxWherehouseCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxOurRefNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerGranDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGrnNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerDueDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxPayables;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxYourRefNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxGrnRefNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewGRN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxDis1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxTaxes;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxNetValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxGrossValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxDis2;
        private System.Windows.Forms.PictureBox ERRYourRefNo;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.PictureBox ErrLocation;
        private System.Windows.Forms.PictureBox ErrSupplier;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn inv_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dis;
    }
}