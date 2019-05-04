namespace Pharmacy_App
{
    partial class AdminPanelAdd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.radioButtonUnsaleable = new System.Windows.Forms.RadioButton();
            this.radioButtonSaleable = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewMedicines = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxCategory);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxMg);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePickerExpirationDate);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.buttonReturn);
            this.groupBox1.Controls.Add(this.radioButtonUnsaleable);
            this.groupBox1.Controls.Add(this.radioButtonSaleable);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxPrice);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxCost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 225);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Medicine";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Category";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "hap",
            "surup",
            "sampuan"});
            this.comboBoxCategory.Location = new System.Drawing.Point(61, 58);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategory.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(413, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 16);
            this.label7.TabIndex = 45;
            this.label7.Text = "g";
            // 
            // textBoxMg
            // 
            this.textBoxMg.Location = new System.Drawing.Point(369, 32);
            this.textBoxMg.Name = "textBoxMg";
            this.textBoxMg.Size = new System.Drawing.Size(38, 20);
            this.textBoxMg.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Mg";
            // 
            // dateTimePickerExpirationDate
            // 
            this.dateTimePickerExpirationDate.Location = new System.Drawing.Point(273, 58);
            this.dateTimePickerExpirationDate.Name = "dateTimePickerExpirationDate";
            this.dateTimePickerExpirationDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerExpirationDate.TabIndex = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(327, 196);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(408, 196);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(75, 23);
            this.buttonReturn.TabIndex = 11;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.ButtonReturn_Click_1);
            // 
            // radioButtonUnsaleable
            // 
            this.radioButtonUnsaleable.AutoSize = true;
            this.radioButtonUnsaleable.Location = new System.Drawing.Point(229, 148);
            this.radioButtonUnsaleable.Name = "radioButtonUnsaleable";
            this.radioButtonUnsaleable.Size = new System.Drawing.Size(78, 17);
            this.radioButtonUnsaleable.TabIndex = 9;
            this.radioButtonUnsaleable.TabStop = true;
            this.radioButtonUnsaleable.Text = "Unsaleable";
            this.radioButtonUnsaleable.UseVisualStyleBackColor = true;
            // 
            // radioButtonSaleable
            // 
            this.radioButtonSaleable.AutoSize = true;
            this.radioButtonSaleable.Location = new System.Drawing.Point(229, 128);
            this.radioButtonSaleable.Name = "radioButtonSaleable";
            this.radioButtonSaleable.Size = new System.Drawing.Size(66, 17);
            this.radioButtonSaleable.TabIndex = 8;
            this.radioButtonSaleable.TabStop = true;
            this.radioButtonSaleable.Text = "Saleable";
            this.radioButtonSaleable.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(146, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 25);
            this.label12.TabIndex = 37;
            this.label12.Text = "$ ";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(40, 153);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrice.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Price";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(146, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 25);
            this.label10.TabIndex = 34;
            this.label10.Text = "$ ";
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(40, 125);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.Size = new System.Drawing.Size(100, 20);
            this.textBoxCost.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cost";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(226, 32);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmount.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Expiration Date";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(61, 32);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // listViewMedicines
            // 
            this.listViewMedicines.FullRowSelect = true;
            this.listViewMedicines.GridLines = true;
            this.listViewMedicines.Location = new System.Drawing.Point(12, 25);
            this.listViewMedicines.Name = "listViewMedicines";
            this.listViewMedicines.Size = new System.Drawing.Size(864, 308);
            this.listViewMedicines.TabIndex = 5;
            this.listViewMedicines.UseCompatibleStateImageBehavior = false;
            this.listViewMedicines.View = System.Windows.Forms.View.Details;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "New Added Elements :";
            // 
            // AdminPanelAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 576);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listViewMedicines);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminPanelAdd";
            this.Text = "AdminPanelAdd";
            this.Load += new System.EventHandler(this.AdminPanelAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpirationDate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.RadioButton radioButtonUnsaleable;
        private System.Windows.Forms.RadioButton radioButtonSaleable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listViewMedicines;
        private System.Windows.Forms.Label label8;
    }
}