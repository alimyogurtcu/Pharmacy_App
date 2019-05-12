namespace Pharmacy_App
{
    partial class AdminPanelDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanelDelete));
            this.listViewMedicines = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelMedicineAmount = new System.Windows.Forms.Label();
            this.labelMedicineName = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelMedicineBarcodeNo = new System.Windows.Forms.Label();
            this.labelBarcodeNo = new System.Windows.Forms.Label();
            this.pictureBoxMedicine = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelMedicineStatus = new System.Windows.Forms.Label();
            this.labelMedicineUploadDate = new System.Windows.Forms.Label();
            this.labelMedicineExperationDate = new System.Windows.Forms.Label();
            this.labelLastUploadDate = new System.Windows.Forms.Label();
            this.labelMedicineCategory = new System.Windows.Forms.Label();
            this.labelMg = new System.Windows.Forms.Label();
            this.labelMedicineMg = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelMedicinePrice = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelMedicineCost = new System.Windows.Forms.Label();
            this.labelExperationDate = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewMedicines
            // 
            this.listViewMedicines.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listViewMedicines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.listViewMedicines.FullRowSelect = true;
            this.listViewMedicines.GridLines = true;
            this.listViewMedicines.Location = new System.Drawing.Point(48, 45);
            this.listViewMedicines.Name = "listViewMedicines";
            this.listViewMedicines.Size = new System.Drawing.Size(1090, 311);
            this.listViewMedicines.TabIndex = 5;
            this.listViewMedicines.UseCompatibleStateImageBehavior = false;
            this.listViewMedicines.View = System.Windows.Forms.View.Details;
            this.listViewMedicines.SelectedIndexChanged += new System.EventHandler(this.listViewMedicines_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(44, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Product List";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCategory.ForeColor = System.Drawing.Color.Cyan;
            this.labelCategory.Location = new System.Drawing.Point(575, 201);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(76, 19);
            this.labelCategory.TabIndex = 18;
            this.labelCategory.Text = "Category :";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAmount.ForeColor = System.Drawing.Color.Cyan;
            this.labelAmount.Location = new System.Drawing.Point(340, 217);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(68, 19);
            this.labelAmount.TabIndex = 19;
            this.labelAmount.Text = "Amount :";
            // 
            // labelMedicineAmount
            // 
            this.labelMedicineAmount.AutoSize = true;
            this.labelMedicineAmount.Location = new System.Drawing.Point(414, 217);
            this.labelMedicineAmount.Name = "labelMedicineAmount";
            this.labelMedicineAmount.Size = new System.Drawing.Size(0, 19);
            this.labelMedicineAmount.TabIndex = 20;
            // 
            // labelMedicineName
            // 
            this.labelMedicineName.AutoSize = true;
            this.labelMedicineName.ForeColor = System.Drawing.Color.Cyan;
            this.labelMedicineName.Location = new System.Drawing.Point(248, 217);
            this.labelMedicineName.Name = "labelMedicineName";
            this.labelMedicineName.Size = new System.Drawing.Size(0, 19);
            this.labelMedicineName.TabIndex = 21;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.Color.Cyan;
            this.labelName.Location = new System.Drawing.Point(186, 217);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(56, 19);
            this.labelName.TabIndex = 22;
            this.labelName.Text = "Name :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.labelMedicineBarcodeNo);
            this.groupBox1.Controls.Add(this.labelBarcodeNo);
            this.groupBox1.Controls.Add(this.pictureBoxMedicine);
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Controls.Add(this.labelMedicineStatus);
            this.groupBox1.Controls.Add(this.labelMedicineUploadDate);
            this.groupBox1.Controls.Add(this.labelMedicineExperationDate);
            this.groupBox1.Controls.Add(this.labelLastUploadDate);
            this.groupBox1.Controls.Add(this.labelMedicineCategory);
            this.groupBox1.Controls.Add(this.labelMg);
            this.groupBox1.Controls.Add(this.labelMedicineMg);
            this.groupBox1.Controls.Add(this.labelPrice);
            this.groupBox1.Controls.Add(this.labelMedicinePrice);
            this.groupBox1.Controls.Add(this.labelCost);
            this.groupBox1.Controls.Add(this.labelMedicineCost);
            this.groupBox1.Controls.Add(this.labelExperationDate);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Controls.Add(this.labelCategory);
            this.groupBox1.Controls.Add(this.labelMedicineAmount);
            this.groupBox1.Controls.Add(this.labelMedicineName);
            this.groupBox1.Controls.Add(this.labelAmount);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Cyan;
            this.groupBox1.Location = new System.Drawing.Point(94, 362);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(975, 311);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Medicine";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDelete.ForeColor = System.Drawing.Color.Red;
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.Location = new System.Drawing.Point(904, 195);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(65, 110);
            this.buttonDelete.TabIndex = 70;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelMedicineBarcodeNo
            // 
            this.labelMedicineBarcodeNo.AutoSize = true;
            this.labelMedicineBarcodeNo.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMedicineBarcodeNo.ForeColor = System.Drawing.Color.Cyan;
            this.labelMedicineBarcodeNo.Location = new System.Drawing.Point(657, 172);
            this.labelMedicineBarcodeNo.Name = "labelMedicineBarcodeNo";
            this.labelMedicineBarcodeNo.Size = new System.Drawing.Size(0, 19);
            this.labelMedicineBarcodeNo.TabIndex = 38;
            // 
            // labelBarcodeNo
            // 
            this.labelBarcodeNo.AutoSize = true;
            this.labelBarcodeNo.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBarcodeNo.ForeColor = System.Drawing.Color.Cyan;
            this.labelBarcodeNo.Location = new System.Drawing.Point(556, 172);
            this.labelBarcodeNo.Name = "labelBarcodeNo";
            this.labelBarcodeNo.Size = new System.Drawing.Size(95, 19);
            this.labelBarcodeNo.TabIndex = 37;
            this.labelBarcodeNo.Text = "Barcode No :";
            // 
            // pictureBoxMedicine
            // 
            this.pictureBoxMedicine.Location = new System.Drawing.Point(199, 25);
            this.pictureBoxMedicine.Name = "pictureBoxMedicine";
            this.pictureBoxMedicine.Size = new System.Drawing.Size(209, 178);
            this.pictureBoxMedicine.TabIndex = 36;
            this.pictureBoxMedicine.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelStatus.ForeColor = System.Drawing.Color.Cyan;
            this.labelStatus.Location = new System.Drawing.Point(589, 267);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(62, 19);
            this.labelStatus.TabIndex = 35;
            this.labelStatus.Text = "Status :";
            // 
            // labelMedicineStatus
            // 
            this.labelMedicineStatus.AutoSize = true;
            this.labelMedicineStatus.ForeColor = System.Drawing.Color.Cyan;
            this.labelMedicineStatus.Location = new System.Drawing.Point(651, 267);
            this.labelMedicineStatus.Name = "labelMedicineStatus";
            this.labelMedicineStatus.Size = new System.Drawing.Size(0, 19);
            this.labelMedicineStatus.TabIndex = 34;
            // 
            // labelMedicineUploadDate
            // 
            this.labelMedicineUploadDate.AutoSize = true;
            this.labelMedicineUploadDate.ForeColor = System.Drawing.Color.Cyan;
            this.labelMedicineUploadDate.Location = new System.Drawing.Point(248, 281);
            this.labelMedicineUploadDate.Name = "labelMedicineUploadDate";
            this.labelMedicineUploadDate.Size = new System.Drawing.Size(0, 19);
            this.labelMedicineUploadDate.TabIndex = 33;
            // 
            // labelMedicineExperationDate
            // 
            this.labelMedicineExperationDate.AutoSize = true;
            this.labelMedicineExperationDate.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMedicineExperationDate.ForeColor = System.Drawing.Color.Cyan;
            this.labelMedicineExperationDate.Location = new System.Drawing.Point(657, 236);
            this.labelMedicineExperationDate.Name = "labelMedicineExperationDate";
            this.labelMedicineExperationDate.Size = new System.Drawing.Size(0, 19);
            this.labelMedicineExperationDate.TabIndex = 32;
            // 
            // labelLastUploadDate
            // 
            this.labelLastUploadDate.AutoSize = true;
            this.labelLastUploadDate.ForeColor = System.Drawing.Color.Cyan;
            this.labelLastUploadDate.Location = new System.Drawing.Point(111, 281);
            this.labelLastUploadDate.Name = "labelLastUploadDate";
            this.labelLastUploadDate.Size = new System.Drawing.Size(131, 19);
            this.labelLastUploadDate.TabIndex = 31;
            this.labelLastUploadDate.Text = "Last Upload Date :";
            // 
            // labelMedicineCategory
            // 
            this.labelMedicineCategory.AutoSize = true;
            this.labelMedicineCategory.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMedicineCategory.ForeColor = System.Drawing.Color.Cyan;
            this.labelMedicineCategory.Location = new System.Drawing.Point(657, 201);
            this.labelMedicineCategory.Name = "labelMedicineCategory";
            this.labelMedicineCategory.Size = new System.Drawing.Size(0, 19);
            this.labelMedicineCategory.TabIndex = 30;
            // 
            // labelMg
            // 
            this.labelMg.AutoSize = true;
            this.labelMg.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMg.ForeColor = System.Drawing.Color.Cyan;
            this.labelMg.Location = new System.Drawing.Point(779, 201);
            this.labelMg.Name = "labelMg";
            this.labelMg.Size = new System.Drawing.Size(39, 19);
            this.labelMg.TabIndex = 29;
            this.labelMg.Text = "Mg :";
            // 
            // labelMedicineMg
            // 
            this.labelMedicineMg.AutoSize = true;
            this.labelMedicineMg.Location = new System.Drawing.Point(820, 202);
            this.labelMedicineMg.Name = "labelMedicineMg";
            this.labelMedicineMg.Size = new System.Drawing.Size(0, 19);
            this.labelMedicineMg.TabIndex = 28;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.ForeColor = System.Drawing.Color.Cyan;
            this.labelPrice.Location = new System.Drawing.Point(190, 247);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(52, 19);
            this.labelPrice.TabIndex = 27;
            this.labelPrice.Text = "Price :";
            // 
            // labelMedicinePrice
            // 
            this.labelMedicinePrice.AutoSize = true;
            this.labelMedicinePrice.ForeColor = System.Drawing.Color.Cyan;
            this.labelMedicinePrice.Location = new System.Drawing.Point(248, 247);
            this.labelMedicinePrice.Name = "labelMedicinePrice";
            this.labelMedicinePrice.Size = new System.Drawing.Size(0, 19);
            this.labelMedicinePrice.TabIndex = 26;
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCost.ForeColor = System.Drawing.Color.Cyan;
            this.labelCost.Location = new System.Drawing.Point(360, 247);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(48, 19);
            this.labelCost.TabIndex = 25;
            this.labelCost.Text = "Cost :";
            // 
            // labelMedicineCost
            // 
            this.labelMedicineCost.AutoSize = true;
            this.labelMedicineCost.Location = new System.Drawing.Point(414, 247);
            this.labelMedicineCost.Name = "labelMedicineCost";
            this.labelMedicineCost.Size = new System.Drawing.Size(0, 19);
            this.labelMedicineCost.TabIndex = 24;
            // 
            // labelExperationDate
            // 
            this.labelExperationDate.AutoSize = true;
            this.labelExperationDate.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelExperationDate.ForeColor = System.Drawing.Color.Cyan;
            this.labelExperationDate.Location = new System.Drawing.Point(528, 236);
            this.labelExperationDate.Name = "labelExperationDate";
            this.labelExperationDate.Size = new System.Drawing.Size(123, 19);
            this.labelExperationDate.TabIndex = 23;
            this.labelExperationDate.Text = "Experation Date :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1296, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 64);
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AdminPanelDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewMedicines);
            this.Name = "AdminPanelDelete";
            this.Text = "AdminPanelDelete";
            this.Load += new System.EventHandler(this.AdminPanelDelete_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMedicines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelMedicineAmount;
        private System.Windows.Forms.Label labelMedicineName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelMedicineCategory;
        private System.Windows.Forms.Label labelMg;
        private System.Windows.Forms.Label labelMedicineMg;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelMedicinePrice;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelMedicineCost;
        private System.Windows.Forms.Label labelExperationDate;
        private System.Windows.Forms.Label labelMedicineUploadDate;
        private System.Windows.Forms.Label labelMedicineExperationDate;
        private System.Windows.Forms.Label labelLastUploadDate;
        private System.Windows.Forms.PictureBox pictureBoxMedicine;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelMedicineStatus;
        private System.Windows.Forms.Label labelMedicineBarcodeNo;
        private System.Windows.Forms.Label labelBarcodeNo;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button buttonDelete;
    }
}