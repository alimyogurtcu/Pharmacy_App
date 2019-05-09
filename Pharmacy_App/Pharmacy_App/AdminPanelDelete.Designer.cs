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
            this.listViewMedicines = new System.Windows.Forms.ListView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMedicineAmount = new System.Windows.Forms.Label();
            this.labelMedicineName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxMedicine = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.labelMedicineStatus = new System.Windows.Forms.Label();
            this.labelMedicineUploadDate = new System.Windows.Forms.Label();
            this.labelMedicineExperationDate = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelMedicineCategory = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.labelMedicineMg = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelMedicinePrice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelMedicineCost = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMedicine)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewMedicines
            // 
            this.listViewMedicines.FullRowSelect = true;
            this.listViewMedicines.GridLines = true;
            this.listViewMedicines.Location = new System.Drawing.Point(12, 45);
            this.listViewMedicines.Name = "listViewMedicines";
            this.listViewMedicines.Size = new System.Drawing.Size(450, 393);
            this.listViewMedicines.TabIndex = 5;
            this.listViewMedicines.UseCompatibleStateImageBehavior = false;
            this.listViewMedicines.View = System.Windows.Forms.View.Details;
            this.listViewMedicines.SelectedIndexChanged += new System.EventHandler(this.listViewMedicines_SelectedIndexChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(556, 362);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(82, 76);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Product List";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(468, 362);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 76);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Return";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Category :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Amount :";
            // 
            // labelMedicineAmount
            // 
            this.labelMedicineAmount.AutoSize = true;
            this.labelMedicineAmount.Location = new System.Drawing.Point(208, 217);
            this.labelMedicineAmount.Name = "labelMedicineAmount";
            this.labelMedicineAmount.Size = new System.Drawing.Size(0, 13);
            this.labelMedicineAmount.TabIndex = 20;
            // 
            // labelMedicineName
            // 
            this.labelMedicineName.AutoSize = true;
            this.labelMedicineName.Location = new System.Drawing.Point(53, 217);
            this.labelMedicineName.Name = "labelMedicineName";
            this.labelMedicineName.Size = new System.Drawing.Size(0, 13);
            this.labelMedicineName.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Name :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxMedicine);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.labelMedicineStatus);
            this.groupBox1.Controls.Add(this.labelMedicineUploadDate);
            this.groupBox1.Controls.Add(this.labelMedicineExperationDate);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.labelMedicineCategory);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.labelMedicineMg);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.labelMedicinePrice);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.labelMedicineCost);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelMedicineAmount);
            this.groupBox1.Controls.Add(this.labelMedicineName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(468, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 311);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Medicine";
            // 
            // pictureBoxMedicine
            // 
            this.pictureBoxMedicine.Location = new System.Drawing.Point(9, 16);
            this.pictureBoxMedicine.Name = "pictureBoxMedicine";
            this.pictureBoxMedicine.Size = new System.Drawing.Size(209, 178);
            this.pictureBoxMedicine.TabIndex = 36;
            this.pictureBoxMedicine.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(275, 276);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "Status :";
            // 
            // labelMedicineStatus
            // 
            this.labelMedicineStatus.AutoSize = true;
            this.labelMedicineStatus.Location = new System.Drawing.Point(324, 276);
            this.labelMedicineStatus.Name = "labelMedicineStatus";
            this.labelMedicineStatus.Size = new System.Drawing.Size(0, 13);
            this.labelMedicineStatus.TabIndex = 34;
            // 
            // labelMedicineUploadDate
            // 
            this.labelMedicineUploadDate.AutoSize = true;
            this.labelMedicineUploadDate.Location = new System.Drawing.Point(108, 276);
            this.labelMedicineUploadDate.Name = "labelMedicineUploadDate";
            this.labelMedicineUploadDate.Size = new System.Drawing.Size(0, 13);
            this.labelMedicineUploadDate.TabIndex = 33;
            // 
            // labelMedicineExperationDate
            // 
            this.labelMedicineExperationDate.AutoSize = true;
            this.labelMedicineExperationDate.Location = new System.Drawing.Point(417, 247);
            this.labelMedicineExperationDate.Name = "labelMedicineExperationDate";
            this.labelMedicineExperationDate.Size = new System.Drawing.Size(0, 13);
            this.labelMedicineExperationDate.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 276);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Last Upload Date :";
            // 
            // labelMedicineCategory
            // 
            this.labelMedicineCategory.AutoSize = true;
            this.labelMedicineCategory.Location = new System.Drawing.Point(383, 217);
            this.labelMedicineCategory.Name = "labelMedicineCategory";
            this.labelMedicineCategory.Size = new System.Drawing.Size(0, 13);
            this.labelMedicineCategory.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(484, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Mg :";
            // 
            // labelMedicineMg
            // 
            this.labelMedicineMg.AutoSize = true;
            this.labelMedicineMg.Location = new System.Drawing.Point(518, 217);
            this.labelMedicineMg.Name = "labelMedicineMg";
            this.labelMedicineMg.Size = new System.Drawing.Size(0, 13);
            this.labelMedicineMg.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Price :";
            // 
            // labelMedicinePrice
            // 
            this.labelMedicinePrice.AutoSize = true;
            this.labelMedicinePrice.Location = new System.Drawing.Point(49, 247);
            this.labelMedicinePrice.Name = "labelMedicinePrice";
            this.labelMedicinePrice.Size = new System.Drawing.Size(0, 13);
            this.labelMedicinePrice.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(153, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Cost :";
            // 
            // labelMedicineCost
            // 
            this.labelMedicineCost.AutoSize = true;
            this.labelMedicineCost.Location = new System.Drawing.Point(193, 247);
            this.labelMedicineCost.Name = "labelMedicineCost";
            this.labelMedicineCost.Size = new System.Drawing.Size(0, 13);
            this.labelMedicineCost.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Experation Date :";
            // 
            // AdminPanelDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listViewMedicines);
            this.Name = "AdminPanelDelete";
            this.Text = "AdminPanelDelete";
            this.Load += new System.EventHandler(this.AdminPanelDelete_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMedicine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMedicines;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMedicineAmount;
        private System.Windows.Forms.Label labelMedicineName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelMedicineCategory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelMedicineMg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelMedicinePrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelMedicineCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMedicineUploadDate;
        private System.Windows.Forms.Label labelMedicineExperationDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBoxMedicine;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelMedicineStatus;
    }
}