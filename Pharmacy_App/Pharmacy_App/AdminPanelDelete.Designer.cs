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
            this.listView1 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSeach = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 45);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(418, 393);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(818, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 76);
            this.button2.TabIndex = 7;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
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
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(276, 19);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(99, 20);
            this.buttonSearch.TabIndex = 16;
            this.buttonSearch.Text = "search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // textBoxSeach
            // 
            this.textBoxSeach.Location = new System.Drawing.Point(170, 19);
            this.textBoxSeach.Name = "textBoxSeach";
            this.textBoxSeach.Size = new System.Drawing.Size(100, 20);
            this.textBoxSeach.TabIndex = 15;
            this.textBoxSeach.Text = "search";
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(125, 22);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(39, 13);
            this.labelSearch.TabIndex = 14;
            this.labelSearch.Text = "search";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(818, 362);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 76);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AdminPanelDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSeach);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Name = "AdminPanelDelete";
            this.Text = "AdminPanelDelete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSeach;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button buttonCancel;
    }
}