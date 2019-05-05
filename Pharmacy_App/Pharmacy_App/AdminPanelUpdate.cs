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

namespace Pharmacy_App
{
    public partial class AdminPanelUpdate : Form
    {
        List<medicineRecords> medicineRecordList = new List<medicineRecords>();
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";
        string imageFolderPath = @"C:/Users/Public/PharmacyAppData/Images";// folder for images

        // this string variables will be used for get values
        // from list view and make validation for selected
        // item in xml file
        string xmlName,xmlCategory,xmlExperationDate,xmlStatus;
        int xmlAmount;
        double xmlMg, xmlCost, xmlPrice;
        //-----------------------------------------------
        int listViewIndex;
        string imageSourcePath, imageCopyName;
        XmlNodeList imagePathList;


        public AdminPanelUpdate()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            AdminPanel Ap = new AdminPanel();
            Ap.Show();
            this.Close();
        }

        public void Form_Reload(object sender, EventArgs e)
        {
            listViewMedicines.Items.Clear();
            listViewMedicines.Columns.Clear();
            medicineRecordList.Clear();
            AdminPanelUpdate_Load(sender, e);
        }

        private void pictureBoxImages_Click(object sender, EventArgs e)
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
                            break;
                        }
                        catch (Exception Ex)
                        {

                        }
                    }
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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


            for (int i = 0; i < nameList.Count; i++)// Assaning every element from xml document to developer defined medicineRecords class list
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

        private void AdminPanelUpdate_Load(object sender, EventArgs e)
        {
            updateViewList();    
        }


        private void listViewMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            int medicineNumber;


            listViewIndex = listViewMedicines.FocusedItem.Index;

            // getting values from viev list to medicine groub box

            medicineNumber = (int.Parse(listViewMedicines.FocusedItem.SubItems[0].Text.ToString()) - 1);
            textBoxName.Text = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            comboBoxCategory.Text = listViewMedicines.FocusedItem.SubItems[2].Text.ToString();
            textBoxMg.Text = listViewMedicines.FocusedItem.SubItems[3].Text.ToString();
            dateTimePickerExpirationDate.Text = listViewMedicines.FocusedItem.SubItems[4].Text.ToString();
            textBoxAmount.Text = listViewMedicines.FocusedItem.SubItems[5].Text.ToString();
            textBoxCost.Text = listViewMedicines.FocusedItem.SubItems[6].Text.ToString();
            textBoxPrice.Text = listViewMedicines.FocusedItem.SubItems[7].Text.ToString();

            if (listViewMedicines.FocusedItem.SubItems[8].Text.ToString() == "Saleable")
            {
                radioButtonSaleable.Checked = true;
            }
            else
            {
                radioButtonUnsaleable.Checked = true;
            }

            //----------------------------------------------------------


            // getting values to variables

            xmlName = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            xmlCategory = listViewMedicines.FocusedItem.SubItems[2].Text.ToString();
            xmlMg = double.Parse(listViewMedicines.FocusedItem.SubItems[3].Text.ToString());
            xmlExperationDate = listViewMedicines.FocusedItem.SubItems[4].Text.ToString();
            xmlAmount = int.Parse(listViewMedicines.FocusedItem.SubItems[5].Text.ToString());
            xmlCost = double.Parse(listViewMedicines.FocusedItem.SubItems[6].Text.ToString());
            xmlPrice = double.Parse(listViewMedicines.FocusedItem.SubItems[7].Text.ToString());

            if (listViewMedicines.FocusedItem.SubItems[8].Text.ToString() == "Saleable")
            {
                xmlStatus = "Saleable";
            }
            else
            {
                xmlStatus = "Unsaleable";
            }
            //------------------------------------------------------------------------------------


            //getting image from xml file
            
            pictureBoxImage.Image = Image.FromFile(imagePathList[medicineNumber].InnerXml.ToString());
            pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
            //---------------------------


        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            string name, status, updatedDate;
            double mg = 0, cost = 0, price = 0;
            int amount = 0;
            string errorMessage = "";
            bool validation = true;


            name = textBoxName.Text.ToString();
            if (name == "")
            {
                errorMessage += "\nName";
            }
            else { /*doNothing*/}

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
                if (MessageBox.Show("Medicine:\n" +
                        xmlName +
                        " " +
                        xmlCategory +
                        " " +
                        xmlMg +
                        " " +
                        xmlAmount +
                        " " +
                        xmlCost +
                        " " +
                        xmlPrice +
                        " " +
                        xmlExperationDate +
                        " " +
                        xmlStatus +
                        "\nDo you want to continue to update ?", "updated check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    /*-------------------------------------sqlCodeHere-----------------------------*/


                    var medicineDoc = XDocument.Load(@xmlFileLocation);

                    var items = from item in medicineDoc.Descendants("medicine")
                                where (item.Element("name").Value == xmlName && item.Element("category").Value == xmlCategory && item.Element("mg").Value == xmlMg.ToString() && item.Element("experationDate").Value == xmlExperationDate && item.Element("amount").Value == xmlAmount.ToString() && item.Element("cost").Value == xmlCost.ToString() && item.Element("price").Value == xmlPrice.ToString() && item.Element("status").Value == xmlStatus.ToString())
                                select item;
                                
                    foreach (XElement itemElement in items)
                    {
                        itemElement.SetElementValue("name", name);
                        itemElement.SetElementValue("category", category);
                        itemElement.SetElementValue("mg", mg);
                        itemElement.SetElementValue("experationDate", experationDate);
                        itemElement.SetElementValue("amount", amount);
                        itemElement.SetElementValue("cost", cost);
                        itemElement.SetElementValue("price", price);
                        itemElement.SetElementValue("status", status);
                        itemElement.SetElementValue("updatedDate", updatedDate);
                        itemElement.SetElementValue("imagePath", imageFolderPath + "/" + imageCopyName);

                    }

                    medicineDoc.Save(@xmlFileLocation);

                    textBoxName.Text = "";
                    textBoxAmount.Text = "";
                    textBoxMg.Text = "";
                    textBoxPrice.Text = "";
                    textBoxCost.Text = "";
                    comboBoxCategory.Text = "";
                    radioButtonSaleable.Checked = false;
                    radioButtonUnsaleable.Checked = false;

                    Form_Reload(sender, e);

                    MessageBox.Show("Medicine updated" , "confirm",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
            }
            else { /*doNothing*/}

            pictureBoxImage.Image = null;
                


        }
    }
}
  