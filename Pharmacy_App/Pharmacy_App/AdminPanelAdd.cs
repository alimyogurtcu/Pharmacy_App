using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;
using System.Xml.Linq;
using System.IO;
using System.Drawing.Imaging;

namespace Pharmacy_App
{
    public partial class AdminPanelAdd : Form
    {
        //sql*
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= medicines.db");
        SQLiteCommand cmd = new SQLiteCommand();
        //*sql

        List<medicineRecords> temporaryMedicineRecordList = new List<medicineRecords>();
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml"; // xml file location
        string imageFolderPath = @"C:/Users/Public/PharmacyAppData/Images";// folder for images
        string image = "";
        string imageSourcePath, imageCopyName = "";
        public AdminPanelAdd()
        {
            InitializeComponent();
        }

        public void Form_Reload(object sender, EventArgs e)
        {
            listViewMedicines.Items.Clear();
            listViewMedicines.Columns.Clear();
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //decleration of values for get informations from textboxes

            string name = "", experationDate, status = "", category,errorMessage = "";
            double cost = 0,
                   price = 0,
                   mg = 0;
            int amount = 0;
                



            bool validation = true;// value for check if medicine is valid or not


            //---------------------------------------------------------


            // getting values from textboxes to values with *validations !!!

            // for validation, validation bool value used. If
            // valudation is true program continues to check 
            // values. If all values correctly writted adding
            // values to xml document proccess is starts. Else
            // gives errors for each value.

            name = textBoxName.Text.ToString();

            if (name == "")
            {
                errorMessage += "\nName";
                textBoxName.Text = "";
                textBoxName.Focus();
            }
            else { /*doNothing*/}

            try
            {
                amount = int.Parse(textBoxAmount.Text.ToString());
            }
            catch (Exception Ex)
            {
                textBoxAmount.Text = "";
                errorMessage += "\nAmount";
                textBoxAmount.Focus();
            }

            try
            {
                mg = double.Parse(textBoxMg.Text.ToString());

            }
            catch (Exception Ex)
            {
                textBoxMg.Text = "";
                errorMessage += "\nMg";
                textBoxMg.Focus();
            }

            try
            {
                cost = double.Parse(textBoxCost.Text.ToString());
            }
            catch (Exception Ex)
            {
                textBoxCost.Text = "";
                errorMessage += "\nCost";
                textBoxCost.Text = "";
                textBoxCost.Focus();
            }

            try
            {
                
                price = double.Parse(textBoxPrice.Text.ToString());
            }
            catch
            {
                textBoxPrice.Text = "";
                errorMessage = errorMessage += "\nPrice";
                textBoxPrice.Text = "";
                textBoxPrice.Focus();
            }


            experationDate = dateTimePickerExpirationDate.Text.ToString();
            category = comboBoxCategory.Text.ToString();


            if (category == "")
            {
                errorMessage += "\nCategory";
                comboBoxCategory.Focus();
            }
            else {/*doNothing*/}


            if (radioButtonSaleable.Checked) //here we are get status from salable radioButton
            {
                status = radioButtonSaleable.Text.ToString();
            }

            else if (radioButtonUnsaleable.Checked) //here we are get status from unSalable radioButton
            {
                status = radioButtonUnsaleable.Text.ToString();
            }

            if(imageCopyName == "")
            {
                errorMessage += "\nImage";
            }


            if(errorMessage == "")
            {
                validation = true;
            }
            else
            {
                validation = false;
                MessageBox.Show("Invalid inputs found. Please check your ınputs and try again! \n" + errorMessage, "value input eror message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            //-------------------------------------------

            if (validation)
            {
                // Asks if user wants to continue to add medicine.
                // If dialog result is Yes. Program adds the medicine.
                // If dialog result is no Program dont do anything.

                if(MessageBox.Show("Do you want continue to add this medicine ?\n\n" + "Name: " + name + "\n" + "Category: " +category + "\n" + "Amount:" + amount + "\n" + "Milligram: " + mg + "\n" + "Experation Date: " + experationDate + "\n" + "Cost: " + cost + "\n" + "Price: " + price + "\n" + "Status: " + status, "validation of adding process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Form_Reload(sender, e);

                    // Adding colums to the list view

                    listViewMedicines.Columns.Add(" ", 57, HorizontalAlignment.Center);
                    listViewMedicines.Columns.Add("Name", 120, HorizontalAlignment.Left);
                    listViewMedicines.Columns.Add("Category", 100, HorizontalAlignment.Center);
                    listViewMedicines.Columns.Add("Mg", 50, HorizontalAlignment.Center);
                    listViewMedicines.Columns.Add("Expiration Date", 145, HorizontalAlignment.Center);
                    listViewMedicines.Columns.Add("Amount", 50, HorizontalAlignment.Center);
                    listViewMedicines.Columns.Add("Cost", 50, HorizontalAlignment.Center);
                    listViewMedicines.Columns.Add("Price", 50, HorizontalAlignment.Center);
                    listViewMedicines.Columns.Add("Status", 70, HorizontalAlignment.Center);
                    listViewMedicines.Columns.Add("Upload Date", 145, HorizontalAlignment.Center);

                    //------------------------------

                    temporaryMedicineRecordList.Add(new medicineRecords // adding new item to temporary list.
                    {
                        name = name,
                        category = category,
                        mg = mg,
                        amount = amount,
                        cost = cost,
                        price = price,
                        experationDate = experationDate,
                        status = status,
                        updatedDate = System.DateTime.Now.ToString(),
                        imagePath = imageFolderPath + "/" + imageCopyName,

                    });

                    for (var i = 0; i < temporaryMedicineRecordList.Count; i++)// Adding temporaryMedicineRecors list's elements to the list view 
                    {

                        ListViewItem row = new ListViewItem((i + 1).ToString());

                        ListViewItem.ListViewSubItem itms1 = new ListViewItem.ListViewSubItem(row, temporaryMedicineRecordList[i].name.ToString());
                        ListViewItem.ListViewSubItem itms8 = new ListViewItem.ListViewSubItem(row, temporaryMedicineRecordList[i].category.ToString());
                        ListViewItem.ListViewSubItem itms2 = new ListViewItem.ListViewSubItem(row, temporaryMedicineRecordList[i].mg.ToString());
                        ListViewItem.ListViewSubItem itms3 = new ListViewItem.ListViewSubItem(row, temporaryMedicineRecordList[i].experationDate.ToString());
                        ListViewItem.ListViewSubItem itms4 = new ListViewItem.ListViewSubItem(row, temporaryMedicineRecordList[i].amount.ToString());
                        ListViewItem.ListViewSubItem itms5 = new ListViewItem.ListViewSubItem(row, temporaryMedicineRecordList[i].cost.ToString());
                        ListViewItem.ListViewSubItem itms6 = new ListViewItem.ListViewSubItem(row, temporaryMedicineRecordList[i].price.ToString());
                        ListViewItem.ListViewSubItem itms7 = new ListViewItem.ListViewSubItem(row, temporaryMedicineRecordList[i].status.ToString());
                        ListViewItem.ListViewSubItem itms9 = new ListViewItem.ListViewSubItem(row, temporaryMedicineRecordList[i].updatedDate.ToString());


                        row.SubItems.Add(itms1);
                        row.SubItems.Add(itms8);
                        row.SubItems.Add(itms2);
                        row.SubItems.Add(itms3);
                        row.SubItems.Add(itms4);
                        row.SubItems.Add(itms5);
                        row.SubItems.Add(itms6);
                        row.SubItems.Add(itms7);
                        row.SubItems.Add(itms9);
                        
                        listViewMedicines.Items.Add(row);

                    }

                    var doc = XDocument.Load(@xmlFileLocation); //opening xml file

                    //adding new element and saving it 
                    var newElement = new XElement("medicine",
                    new XElement("name", name),
                    new XElement("mg", mg),
                    new XElement("amount", amount),
                    new XElement("cost", cost),
                    new XElement("price", price),
                    new XElement("experationDate", experationDate),
                    new XElement("status", status),
                    new XElement("category", category),
                    new XElement("updatedDate", System.DateTime.Now.ToString()),
                    new XElement("imagePath", imageFolderPath+"/"+imageCopyName));

                    doc.Element("medicines").Add(newElement);

                    doc.Save(@xmlFileLocation);

                    //sql*
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into Medicines(Name, Category, Milligram, ExperationDate, Amount, Cost, Price, Status, UpdatedDate) Values('" + textBoxName.Text + "', '" + comboBoxCategory.Text + "', '" + textBoxMg.Text + "', '" + dateTimePickerExpirationDate.Text + "', '" + textBoxAmount.Text + "', '" + textBoxCost.Text + "', '" + textBoxPrice.Text + "', '" + status.ToString() + "', '" + System.DateTime.Now + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //*sql

                    MessageBox.Show("Medicine is added.", "add proccess complation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    labelClickMessage.Visible = true;
                    textBoxName.Text = "";
                    textBoxMg.Text = "";
                    textBoxAmount.Text = "";
                    textBoxMg.Text = "";
                    textBoxCost.Text = "";
                    textBoxPrice.Text = "";
                    comboBoxCategory.Text = "";
                    radioButtonSaleable.Checked = true;
                    pictureBoxImage.Image = null;
                    imageCopyName = "";
                    
                    }
                else
                {
                    /*doNothing*/
                }

            }
            else
            {
                //do nothing
            }

            

        }


            private void AdminPanelAdd_Load(object sender, EventArgs e)
        {
            radioButtonSaleable.Checked = true;// Radio button salable is checked

            this.comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList; // Makes combo box unvriteable
        }

        private void ButtonReturn_Click_1(object sender, EventArgs e)
        {
            // For return to admin main panel

            AdminPanel AP = new AdminPanel();
            AP.Show();
            this.Close();

        }

        private void pictureBoxImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select product picture.";
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            DialogResult dr = ofd.ShowDialog();
            if(dr == System.Windows.Forms.DialogResult.OK)
            {

                imageSourcePath = ofd.FileName.ToString();
                imageCopyName = ofd.SafeFileName.ToString();

                try
                {
                    System.IO.File.Copy(imageSourcePath, imageFolderPath + "/" + imageCopyName);
                    pictureBoxImage.Image = Image.FromFile(imageFolderPath + "/" + imageCopyName);
                }
                catch
                {
                    for(int i = 0; i < 100000; i++)
                    {
                        try
                        {
                            System.IO.File.Copy(imageSourcePath, imageFolderPath + "/" + "(" + i + ")" + imageCopyName);
                            pictureBoxImage.Image = Image.FromFile(imageFolderPath + "/" + "(" + i + ")" + imageCopyName);
                            pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                            imageCopyName = "(" + i + ")" + imageCopyName;
                            break;
                        }
                        catch(Exception Ex)
                        {

                        }
                    }
                }



                labelClickMessage.Visible = false;
                

                    

            }
            else { /*doNothing*/}
            

        }

        private void clickMessageLabel_Click(object sender, EventArgs e)
        {
            pictureBoxImage_Click(sender,e);
        }

    }

    
}
