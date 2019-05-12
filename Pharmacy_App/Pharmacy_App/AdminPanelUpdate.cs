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
using System.Xml.Linq;
using System.IO;
using System.Data.SQLite;

namespace Pharmacy_App
{
    public partial class AdminPanelUpdate : Form
    {
        //sql*
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= C:\Users\Public\PharmacyAppDatabase\medicines.db");
        SQLiteCommand cmd = new SQLiteCommand();
        //*sql

        int medicineNumber;// variable for get row number

        List<medicineRecords> medicineRecordList = new List<medicineRecords>();// medicine list for get elements from xml

        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";// xml file location
        string imageFolderPath = @"C:/Users/Public/PharmacyAppData/Images";// folder path for copy images

        public string username;


        // this variables will be used for get values
        // from list view and find selected
        // item in xml file
        string xmlName, xmlCategory, xmlExperationDate, xmlStatus, imagePathFull;
        int xmlAmount;
        double xmlMg, xmlCost, xmlPrice;
        ulong xmlBarcodeNo;
        //-----------------------------------------------


        string imageSourcePath, imageCopyName;// variables for open file dialog


        XmlNodeList imagePathList;// list to get image paths from xml file


        public AdminPanelUpdate()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e) // Button to return admin panel
        {
            AdminPanel Ap = new AdminPanel();
            Ap.Show();
            Ap.labelUsername.Text = username;
            this.Close();
        }

        public void Form_Reload(object sender, EventArgs e)// funchtion to reload page
        {
            listViewMedicines.Items.Clear();
            listViewMedicines.Columns.Clear();
            medicineRecordList.Clear();
            AdminPanelUpdate_Load(sender, e);
        }

        private void pictureBoxImages_Click(object sender, EventArgs e)// uses open file dialog to get image path nad copy image to image folder path
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select product picture.";
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                imageSourcePath = ofd.FileName.ToString();
                imageCopyName = ofd.SafeFileName.ToString();

                try
                {
                    System.IO.File.Copy(imageSourcePath, imageFolderPath + "/" + imageCopyName);
                    pictureBoxImage.Image = Image.FromFile(imageFolderPath + "/" + imageCopyName);
                    pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    imagePathFull = imageFolderPath + "/" + imageCopyName;
                }
                catch
                {
                    for (int i = 0; i < 100000; i++)
                    {
                        try
                        {
                            System.IO.File.Copy(imageSourcePath, imageFolderPath + "/" + "(" + i + ")" + imageCopyName);
                            pictureBoxImage.Image = Image.FromFile(imageFolderPath + "/" + "(" + i + ")" + imageCopyName);
                            pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                            imageCopyName = "(" + i + ")" + imageCopyName;
                            imagePathFull = imageFolderPath + "/" + imageCopyName;
                            break;
                        }
                        catch (Exception Ex)
                        {

                        }
                    }
                }
            }
        }


        public void updateViewList() // funchtion for get values from xml to view list
        {

            // Adding columns for list view

            listViewMedicines.Columns.Add(" ", 80, HorizontalAlignment.Center);// sub item 0
            listViewMedicines.Columns.Add("Name", 150, HorizontalAlignment.Left);//  sub item 1
            listViewMedicines.Columns.Add("Category", 100, HorizontalAlignment.Center);// sub item 2
            listViewMedicines.Columns.Add("Mg", 50, HorizontalAlignment.Center);// sub item 3
            listViewMedicines.Columns.Add("Expiration Date", 150, HorizontalAlignment.Center); // sub item 4
            listViewMedicines.Columns.Add("Amount", 60, HorizontalAlignment.Center);// sub item 5
            listViewMedicines.Columns.Add("Cost", 50, HorizontalAlignment.Center);// sub item 6
            listViewMedicines.Columns.Add("Price", 50, HorizontalAlignment.Center);// sub item 7
            listViewMedicines.Columns.Add("Status", 70, HorizontalAlignment.Center);// sub item 8
            listViewMedicines.Columns.Add("Barcode No", 150, HorizontalAlignment.Center);//sub item 9
            listViewMedicines.Columns.Add("Upload Date", 150, HorizontalAlignment.Center);// sub item 10

            //----------------------------------------------------------------------------


            // To get every node from xml file to list view ;
            // First get items from xml file to XmlNodeList
            // Then assing information from XmlNodeList to
            // user defined list class. Get information from list 
            // to listViewMedicines




            // Getting elements from xml file to the temperory list. 
            // Each tag have its own list. 
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
            XmlNodeList barcodeNoList = medicines.GetElementsByTagName("barcodeNo");
            XmlNodeList UpdatedDateList = medicines.GetElementsByTagName("updatedDate");
            imagePathList = medicines.GetElementsByTagName("imagePath");

            ImageList img = new ImageList();
            img.ImageSize = new Size(50, 50);

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
                    mg = XmlConvert.ToDouble(mgList[i].InnerXml),
                    amount = int.Parse(amountList[i].InnerXml),
                    cost = XmlConvert.ToDouble(costList[i].InnerXml),
                    price = XmlConvert.ToDouble(priceList[i].InnerXml),
                    experationDate = experationDateList[i].InnerXml,
                    status = statusList[i].InnerXml,
                    barcodeNo = ulong.Parse(barcodeNoList[i].InnerXml),
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
                ListViewItem.ListViewSubItem itms10 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].barcodeNo.ToString());
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
                row.SubItems.Add(itms10);
                row.SubItems.Add(itms9);

                listViewMedicines.Items.Add(row);


            }

        }

        private void AdminPanelUpdate_Load(object sender, EventArgs e)
        {
            //FULL SCREEN
            FormBorderStyle = FormBorderStyle.None;// Remove's windows borders
            WindowState = FormWindowState.Maximized;// Make application full screen
            //FULL SCREEN

            // Textbox to unwriteable

            textBoxName.Enabled = false;
            textBoxBarcodeNo.Enabled = false;
            textBoxCost.Enabled = false;
            textBoxMg.Enabled = false;
            textBoxPrice.Enabled = false;
            textBoxAmount.Enabled = false;
            comboBoxCategory.Enabled = false;
            dateTimePickerExpirationDate.Enabled = false;
            radioButtonSaleable.Enabled = false;
            radioButtonUnsaleable.Enabled = false;
            
            pictureBoxImage.Enabled = false;

            updateViewList();
        }


        private void listViewMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {

            // getting values from viev list to medicine groub box

            medicineNumber = (int.Parse(listViewMedicines.FocusedItem.SubItems[0].Text.ToString()) - 1);
            textBoxName.Text = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            comboBoxCategory.Text = listViewMedicines.FocusedItem.SubItems[2].Text.ToString();
            textBoxMg.Text = listViewMedicines.FocusedItem.SubItems[3].Text.ToString();
            dateTimePickerExpirationDate.Text = listViewMedicines.FocusedItem.SubItems[4].Text.ToString();
            textBoxAmount.Text = listViewMedicines.FocusedItem.SubItems[5].Text.ToString();
            textBoxCost.Text = listViewMedicines.FocusedItem.SubItems[6].Text.ToString();
            textBoxPrice.Text = listViewMedicines.FocusedItem.SubItems[7].Text.ToString();
            textBoxBarcodeNo.Text = listViewMedicines.FocusedItem.SubItems[9].Text.ToString();
            imagePathFull = imagePathList[medicineNumber].InnerXml.ToString();


            if (listViewMedicines.FocusedItem.SubItems[8].Text.ToString() == "Saleable")
            {
                radioButtonSaleable.Checked = true;
            }
            else
            {
                radioButtonUnsaleable.Checked = true;
            }

            //getting image from xml file

            pictureBoxImage.Image = Image.FromFile(imagePathList[medicineNumber].InnerXml.ToString());
            pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
            //---------------------------

            //----------------------------------------------------------


            // getting values to variables

            xmlName = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            xmlCategory = listViewMedicines.FocusedItem.SubItems[2].Text.ToString();
            xmlMg = double.Parse(listViewMedicines.FocusedItem.SubItems[3].Text.ToString());
            xmlExperationDate = listViewMedicines.FocusedItem.SubItems[4].Text.ToString();
            xmlAmount = int.Parse(listViewMedicines.FocusedItem.SubItems[5].Text.ToString());
            xmlCost = double.Parse(listViewMedicines.FocusedItem.SubItems[6].Text.ToString());
            xmlPrice = double.Parse(listViewMedicines.FocusedItem.SubItems[7].Text.ToString());
            xmlStatus = listViewMedicines.FocusedItem.SubItems[8].Text.ToString();
            xmlBarcodeNo = ulong.Parse(listViewMedicines.FocusedItem.SubItems[9].Text.ToString());

            //------------------------------------------------------------------------------------


            // Makes textboxes writeable
            textBoxName.Enabled = true;
            textBoxBarcodeNo.Enabled = true;
            textBoxCost.Enabled = true;
            textBoxMg.Enabled = true;
            textBoxPrice.Enabled = true;
            textBoxAmount.Enabled = true;
            comboBoxCategory.Enabled = true;
            dateTimePickerExpirationDate.Enabled = true;
            radioButtonSaleable.Enabled = true;
            radioButtonUnsaleable.Enabled = true;
            
            pictureBoxImage.Enabled = true;
            // ------------------------------------

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            string name, status, updatedDate;
            double mg = 0, cost = 0, price = 0;
            ulong barcodeNo = 0;
            int amount = 0;
            string errorMessage = "";
            bool validation = true;
            var x = medicineRecordList.ElementAt(0);
            if (pictureBoxImage.Image == null)
            {
                MessageBox.Show("Please select a medicine", "medicine selection confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                name = textBoxName.Text.ToString();
                if (name == "")
                {
                    errorMessage += "\nName";
                }
                else { /*doNothing*/}

                try
                {
                    barcodeNo = ulong.Parse(textBoxBarcodeNo.Text.ToString());
                }
                catch (Exception ex)
                {
                    errorMessage += "\nBarcode No";
                }

                string category = comboBoxCategory.Text.ToString();

                if (category == "")
                {
                    errorMessage += "\nCategory";
                }
                else { /*doNothing*/}

                try
                {
                    mg = double.Parse(textBoxMg.Text.ToString());
                }
                catch (Exception ex)
                {
                    errorMessage += "\nMg";
                }

                string experationDate = dateTimePickerExpirationDate.Text.ToString();

                try
                {
                    amount = int.Parse(textBoxAmount.Text.ToString());
                }
                catch
                {
                    errorMessage += "\nAmount";
                }

                try
                {
                    cost = double.Parse(textBoxCost.Text.ToString());
                }
                catch
                {
                    errorMessage += "\nCost";
                }

                try
                {
                    price = double.Parse(textBoxPrice.Text.ToString());
                }
                catch
                {
                    errorMessage += "\nPrice";
                }

                updatedDate = System.DateTime.Now.ToString();

                if (radioButtonSaleable.Checked)
                {
                    status = radioButtonSaleable.Text.ToString();
                }
                else
                {
                    status = radioButtonUnsaleable.Text.ToString();
                }

                if (errorMessage == "")
                {
                    validation = true;
                }
                else
                {
                    validation = false;
                    MessageBox.Show("Invalid inputs. Please try again:\n" + errorMessage, "validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (validation)
                {
                    for (int i = 0; i < medicineRecordList.Count; i++)
                    {
                        if (medicineRecordList[i].name == xmlName &&
                            medicineRecordList[i].price == xmlPrice &&
                            medicineRecordList[i].cost == xmlCost &&
                            medicineRecordList[i].amount == xmlAmount &&
                            medicineRecordList[i].category == xmlCategory &&
                            medicineRecordList[i].mg == xmlMg &&
                            medicineRecordList[i].experationDate == xmlExperationDate &&
                            medicineRecordList[i].status == xmlStatus &&
                            medicineRecordList[i].barcodeNo == xmlBarcodeNo)
                        {
                            x = medicineRecordList.ElementAt(i);
                            medicineRecordList.RemoveAt(i);
                        }
                        else
                        {/*doNothing*/}
                    }

                    for (int i = 0; i < medicineRecordList.Count; i++)
                    {
                        if (medicineRecordList[i].name == name &&
                            medicineRecordList[i].category == category &&
                            medicineRecordList[i].mg == mg &&
                            medicineRecordList[i].experationDate == experationDate &&
                            medicineRecordList[i].barcodeNo == barcodeNo)
                        {
                            MessageBox.Show("New informations overlaps with a medicine !", "medicine control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            medicineRecordList.Add(x);
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
                    if (MessageBox.Show("\nDo you want to continue to update this medicine with new informations ?\n\n" + "Name: " + xmlName + " to " + name + "\n" + "Category: " + xmlCategory + " to " + category + "\n" + "Amount:" + xmlAmount + " to " + amount + "\n" + "Milligram: " + xmlMg + " to " + mg + "\n" + "Experation Date: " + xmlExperationDate + " to " + experationDate + "\n" + "Cost: " + xmlCost + " to " + cost + "\n" + "Price: " + xmlPrice + " to " + price + "\n" + "Status: " + xmlBarcodeNo + " to " + barcodeNo + "\n" + "Status: " + xmlStatus + " to " + status, "Updated check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //sql*update
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = "Update Medicines set Name ='" + name + "', Category = '" + category + "', Milligram = '" + mg + "', ExperationDate = '" + experationDate + "', Amount = '" + amount + "', Cost = '" + cost + "', Price = '" + price + "', Status = '" + status + "', BarcodeNo = '" + barcodeNo + "', UpdatedDate = '" + System.DateTime.Now + "', ImageFolder = '" + (imageCopyName + "/" + imageCopyName) + "' where ROWID ='" + int.Parse(listViewMedicines.FocusedItem.SubItems[0].Text.ToString()) + "'";
                        cmd.ExecuteNonQuery();
                        //sql*update


                        var medicineDoc = XDocument.Load(@xmlFileLocation);

                        var items = from item in medicineDoc.Descendants("medicine")
                                    where (item.Element("name").Value == xmlName && item.Element("category").Value == xmlCategory && item.Element("mg").Value == XmlConvert.ToString(xmlMg) && item.Element("experationDate").Value == xmlExperationDate && item.Element("amount").Value == xmlAmount.ToString() && item.Element("cost").Value == XmlConvert.ToString(xmlCost) && item.Element("price").Value == XmlConvert.ToString(xmlPrice) && item.Element("status").Value == xmlStatus.ToString() && item.Element("barcodeNo").Value == xmlBarcodeNo.ToString())
                                    select item;

                        foreach (XElement itemElement in items)
                        {
                            itemElement.SetElementValue("name", name);
                            itemElement.SetElementValue("category", category);
                            itemElement.SetElementValue("mg", XmlConvert.ToString(mg));
                            itemElement.SetElementValue("experationDate", experationDate);
                            itemElement.SetElementValue("amount", amount);
                            itemElement.SetElementValue("cost", XmlConvert.ToString(cost));
                            itemElement.SetElementValue("price", XmlConvert.ToString(price));
                            itemElement.SetElementValue("status", status);
                            itemElement.SetElementValue("updatedDate", updatedDate);
                            itemElement.SetElementValue("imagePath", imagePathFull);
                            itemElement.SetElementValue("barcodeNo", barcodeNo);

                        }

                        medicineDoc.Save(xmlFileLocation);

                        // Cleans tools
                        textBoxName.Text = "";
                        textBoxAmount.Text = "";
                        textBoxMg.Text = "";
                        textBoxPrice.Text = "";
                        textBoxCost.Text = "";
                        textBoxBarcodeNo.Text = "";
                        comboBoxCategory.Text = "";
                        radioButtonSaleable.Checked = false;
                        radioButtonUnsaleable.Checked = false;
                        pictureBoxImage.Image = null;

                        textBoxName.Enabled = false;
                        textBoxBarcodeNo.Enabled = false;
                        textBoxCost.Enabled = false;
                        textBoxMg.Enabled = false;
                        textBoxPrice.Enabled = false;
                        textBoxAmount.Enabled = false;
                        comboBoxCategory.Enabled = false;
                        dateTimePickerExpirationDate.Enabled = false;
                        radioButtonSaleable.Enabled = false;
                        radioButtonUnsaleable.Enabled = false;
                        pictureBoxImage.Enabled = false;

                        //-------------------------------------------

                        Form_Reload(sender, e);

                        if(MessageBox.Show("Medicine updated", "confirm", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK){
                           

                            conn.Close();
                        }

                    }
                }
                else { /*doNothing*/}

            }

        }
    }
}
