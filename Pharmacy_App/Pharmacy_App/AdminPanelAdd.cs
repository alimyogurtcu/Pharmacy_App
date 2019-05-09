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

namespace Pharmacy_App
{
    public partial class AdminPanelAdd : Form
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= medicines.db"); //sql
        List<medicineRecords> medicineRecordList = new List<medicineRecords>();
        List<medicineRecords> temporaryMedicineRecordList = new List<medicineRecords>();
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml"; // xml file location
        string imageFolderPath = @"C:/Users/Public/PharmacyAppData/Images";// folder for images
        string image = "";
        string imageSourcePath, imageCopyName = "";
        XmlNodeList imagePathList;

        public AdminPanelAdd()
        {
            InitializeComponent();
        }

        public void Form_Reload(object sender, EventArgs e)
        {
            listViewMedicines.Items.Clear();
            listViewMedicines.Columns.Clear();
            listViewTemporaryMedicines.Items.Clear();
            listViewTemporaryMedicines.Columns.Clear();
            medicineRecordList.Clear();
            AdminPanelAdd_Load(sender, e);
        }


        public void updateViewList() // funchtion for get values from xml to view list
        {

            // Adding columns for list view

            listViewMedicines.Columns.Add(" ", 87, HorizontalAlignment.Center);// sub item 0
            listViewMedicines.Columns.Add("Name", 170, HorizontalAlignment.Left);//  sub item 1
            listViewMedicines.Columns.Add("Category", 150, HorizontalAlignment.Center);// sub item 2
            listViewMedicines.Columns.Add("Mg", 70, HorizontalAlignment.Center);// sub item 3
            listViewMedicines.Columns.Add("Expiration Date", 150, HorizontalAlignment.Center); // sub item 4
            listViewMedicines.Columns.Add("Amount", 70, HorizontalAlignment.Center);// sub item 5
            listViewMedicines.Columns.Add("Cost", 70, HorizontalAlignment.Center);// sub item 6
            listViewMedicines.Columns.Add("Price", 70, HorizontalAlignment.Center);// sub item 7
            listViewMedicines.Columns.Add("Status", 100, HorizontalAlignment.Center);// sub item 8
            listViewMedicines.Columns.Add("Upload Date", 150, HorizontalAlignment.Center);// sub item 9

            //----------------------------------------------------------------------------

            // getting elements in xml to the temperory list. Each tag have its own list. 
            XmlDocument medicines = new XmlDocument();
            medicines.Load(xmlFileLocation);

            XmlNodeList nameList = medicines.GetElementsByTagName("name");
            XmlNodeList categoryList = medicines.GetElementsByTagName("category");
            XmlNodeList mgList = medicines.GetElementsByTagName("mg");
            XmlNodeList amountList = medicines.GetElementsByTagName("amount");
            XmlNodeList costList = medicines.GetElementsByTagName("cost");
            XmlNodeList priceList = medicines.GetElementsByTagName("price");
            XmlNodeList experationDateList = medicines.GetElementsByTagName("experationDate");
            XmlNodeList statusList = medicines.GetElementsByTagName("status");
            XmlNodeList UpdatedDateList = medicines.GetElementsByTagName("updatedDate");
            imagePathList = medicines.GetElementsByTagName("imagePath");

            ImageList img = new ImageList();
            img.ImageSize = new Size(70, 70);

            for (int i = 0; i < imagePathList.Count; i++)
            {
                img.Images.Add(Image.FromFile(imagePathList[i].InnerXml));

            }

            //--------------------------------------------------------------------------------------


            for (int i = 0; i < nameList.Count; i++)// Assıgning every element from xml document to developer defined medicineRecords class list
            {
                medicineRecordList.Add(new medicineRecords
                {
                    name = nameList[i].InnerXml,
                    category = categoryList[i].InnerXml,
                    mg = double.Parse(mgList[i].InnerXml),
                    amount = int.Parse(amountList[i].InnerXml),
                    cost = double.Parse(costList[i].InnerXml),
                    price = double.Parse(priceList[i].InnerXml),
                    experationDate = experationDateList[i].InnerXml,
                    status = statusList[i].InnerXml,
                    updatedDate = UpdatedDateList[i].InnerXml,
                });

            }


            for (var i = 0; i < medicineRecordList.Count; i++)// Adding medicineRecords list's elements to the list view 
            {
                listViewMedicines.SmallImageList = img;

                ListViewItem row = new ListViewItem((i + 1).ToString());

                ListViewItem.ListViewSubItem itms1 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].name.ToString());
                ListViewItem.ListViewSubItem itms8 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].category.ToString());
                ListViewItem.ListViewSubItem itms2 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].mg.ToString());
                ListViewItem.ListViewSubItem itms3 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].experationDate.ToString());
                ListViewItem.ListViewSubItem itms4 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].amount.ToString());
                ListViewItem.ListViewSubItem itms5 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].cost.ToString());
                ListViewItem.ListViewSubItem itms6 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].price.ToString());
                ListViewItem.ListViewSubItem itms7 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].status.ToString());
                ListViewItem.ListViewSubItem itms9 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].updatedDate.ToString());



                row.ImageIndex = i;
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

                //*sql add
                conn.Open();
                string sql = "insert into Medicines(Name, Category, Milligram, ExperationDate, Amount, Cost, Price, Status, UpdatedDate) Values('" + textBoxName.Text + "', '" + comboBoxCategory.Text + "', '" + textBoxMg.Text + "', '" + dateTimePickerExpirationDate.Text + "', '" + textBoxAmount.Text + "', '" + textBoxCost.Text + "', '" + textBoxPrice.Text + "', '" + status.ToString() + "', '" + System.DateTime.Now + "')";
                SQLiteCommand uploadDB = new SQLiteCommand(sql, conn);
                uploadDB.ExecuteNonQuery();
                conn.Close();
                //*sql add
            }
            else
            {
                validation = false;
                MessageBox.Show("Invalid inputs found. Please check your ınputs and try again! \n" + errorMessage, "value input eror message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            //-------------------------------------------

            if (validation)
            {
                for(int i = 0; i < medicineRecordList.Count; i++)
                {
                    if (medicineRecordList[i].name == name &&
                        medicineRecordList[i].category == category &&
                        medicineRecordList[i].mg == mg &&
                        medicineRecordList[i].experationDate == experationDate )
                    {
                        MessageBox.Show("This medicine is already entered", "medicine control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        validation = false;
                        break;
                    }
                    else
                    {/*doNothing*/}
                }
            }
            else
            {
                //do nothing
            }

            if (validation)
            {
                // Asks if user wants to continue to add medicine.
                // If dialog result is Yes. Program adds the medicine.
                // If dialog result is no Program dont do anything.

                if (MessageBox.Show("Do you want continue to add this medicine ?\n\n" + "Name: " + name + "\n" + "Category: " + category + "\n" + "Amount:" + amount + "\n" + "Milligram: " + mg + "\n" + "Experation Date: " + experationDate + "\n" + "Cost: " + cost + "\n" + "Price: " + price + "\n" + "Status: " + status, "validation of adding process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    /*--------------------sql code here--------------------*/

                    Form_Reload(sender, e);

                    // Adding colums to the list view

                    listViewTemporaryMedicines.Columns.Add(" ", 25, HorizontalAlignment.Center);
                    listViewTemporaryMedicines.Columns.Add("Name", 120, HorizontalAlignment.Left);
                    listViewTemporaryMedicines.Columns.Add("Category", 100, HorizontalAlignment.Center);
                    listViewTemporaryMedicines.Columns.Add("Mg", 50, HorizontalAlignment.Center);
                    listViewTemporaryMedicines.Columns.Add("Expiration Date", 150, HorizontalAlignment.Center);
                    listViewTemporaryMedicines.Columns.Add("Amount", 50, HorizontalAlignment.Center);
                    listViewTemporaryMedicines.Columns.Add("Cost", 50, HorizontalAlignment.Center);
                    listViewTemporaryMedicines.Columns.Add("Price", 50, HorizontalAlignment.Center);
                    listViewTemporaryMedicines.Columns.Add("Status", 70, HorizontalAlignment.Center);
                    listViewTemporaryMedicines.Columns.Add("Upload Date", 150, HorizontalAlignment.Center);

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

                        listViewTemporaryMedicines.Items.Add(row);
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
                    new XElement("imagePath", imageFolderPath + "/" + imageCopyName));

                    doc.Element("medicines").Add(newElement);

                    doc.Save(@xmlFileLocation);

                    MessageBox.Show("Medicine is added.", "add proccess complation", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    labelClickMessage.Text = "click to add image";

                    Form_Reload(sender, e);
                   

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
            updateViewList();
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

                

                labelClickMessage.Text = "";
                

                    

            }
            else { /*doNothing*/}
            

        }

        private void listViewMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clickMessageLabel_Click(object sender, EventArgs e)
        {
            pictureBoxImage_Click(sender,e);
        }





    }

    
}
