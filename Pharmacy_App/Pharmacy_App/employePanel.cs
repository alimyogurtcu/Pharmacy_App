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

namespace Pharmacy_App
{
    public partial class employePanel : Form
    {

        List<medicineRecords> medicineRecordList = new List<medicineRecords>();
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";
        string historyXmlFileLocation = "C://Users/Public/PharmacyAppData/history.xml";
        XmlNodeList imagePathList;
        string xmlName, xmlCategory, xmlExperationDate, xmlStatus, imagePathFull;
        int xmlAmount;
        double xmlMg, xmlCost, xmlPrice;


        public employePanel()
        {
            InitializeComponent();
        }

        public void Form_Reload(object sender, EventArgs e)
        {
            listViewMedicines.Items.Clear();
            listViewMedicines.Columns.Clear();
            medicineRecordList.Clear();
            employePanel_Load(sender, e);
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            employeHistory EP = new employeHistory();
            EP.Show();
        }

        public void updateViewList() // funchtion for get values from xml to view list
        {
            radioButtonRecipe.Checked = true;
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

        private void employePanel_Load(object sender, EventArgs e)
        {
            updateViewList();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            string customerName = "",
                recipe,medicineName = "",
                errorMessage = "";
            int amount = 0;
            
            double totalPrice = 0;

            XmlDocument historyDoc = new XmlDocument();


            

            medicineName = labelMedicineName.Text.ToString();

            if(medicineName == "")
            {
                errorMessage += "\nPlease select a medicine";
            }
            else { /*doNothing*/}

            customerName = textBoxCustomerName.Text.ToString();
            if (customerName == "")
            {
                errorMessage += "\nPlease enter customer name";
            }
            else { /*do nothing*/ }

            try
            {
                amount = int.Parse(comboBoxAmount.Text.ToString());

            }
            catch
            {
                errorMessage += "\nPlease select amount";
            }

            try
            {
                totalPrice = double.Parse(textBoxTotalPrice.Text.ToString());
            }
            catch
            {
                errorMessage += "\nTotal price cant be empty";
            }


            if (radioButtonRecipe.Checked == true)
            {
                recipe = radioButtonRecipe.Text.ToString();
            }
            else
            {
                recipe = radioButtonWithoutRecipe.Text.ToString();
            }

            if(labelAmount.Text == "0")
            {
                errorMessage = "Stok for this medicine is 0.(Empty stok)";
            }
            else { /*do nothing*/}

            if(errorMessage == "")
            {
                if (MessageBox.Show("Do you want to continue to sell process of this medicine ?", "medicine delete confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var doc = XDocument.Load(historyXmlFileLocation); //opening xml file


                    var newElement = new XElement("customer",
                    new XElement("customerName", customerName),
                    new XElement("medicineName", medicineName),
                    new XElement("mg", xmlMg),
                    new XElement("amount", amount),
                    new XElement("recipe", recipe),
                    new XElement("totalPrice", totalPrice),
                    new XElement("sellDate", System.DateTime.Now.ToString()));


                    doc.Element("customers").Add(newElement);

                    doc.Save(historyXmlFileLocation);

                    var medicineDoc = XDocument.Load(@xmlFileLocation);

                    var items = from item in medicineDoc.Descendants("medicine")
                                where (item.Element("name").Value == xmlName && item.Element("category").Value == xmlCategory && item.Element("mg").Value == xmlMg.ToString() && item.Element("experationDate").Value == xmlExperationDate && item.Element("amount").Value == xmlAmount.ToString() && item.Element("cost").Value == xmlCost.ToString() && item.Element("price").Value == xmlPrice.ToString() && item.Element("status").Value == xmlStatus.ToString())
                                select item;

                    foreach (XElement itemElement in items)
                    {
                        itemElement.SetElementValue("amount", (int.Parse(listViewMedicines.FocusedItem.SubItems[5].Text.ToString()) - amount));

                    }

                    medicineDoc.Save(@xmlFileLocation);

                    Form_Reload(sender, e);

                    labelMedicineName.Text = "";
                    labelAmount.Text = "";
                    labelPrice.Text = "";
                    textBoxCustomerName.Text = "";
                    textBoxTotalPrice.Text = "";
                    comboBoxAmount.Text = "";
                    comboBoxAmount.Items.Clear();
                }
                else { /*doNothing*/}

            }
            else
            {

                MessageBox.Show(errorMessage, "errors check", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            }

        private void listViewMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            xmlName = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            xmlCategory = listViewMedicines.FocusedItem.SubItems[2].Text.ToString();
            xmlMg = double.Parse(listViewMedicines.FocusedItem.SubItems[3].Text.ToString());
            xmlExperationDate = listViewMedicines.FocusedItem.SubItems[4].Text.ToString();
            xmlAmount = int.Parse(listViewMedicines.FocusedItem.SubItems[5].Text.ToString());
            xmlCost = double.Parse(listViewMedicines.FocusedItem.SubItems[6].Text.ToString());
            xmlPrice = double.Parse(listViewMedicines.FocusedItem.SubItems[7].Text.ToString());
            xmlStatus = listViewMedicines.FocusedItem.SubItems[8].Text.ToString();


            labelMedicineName.Text = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            labelPrice.Text = listViewMedicines.FocusedItem.SubItems[7].Text.ToString();
            labelAmount.Text = listViewMedicines.FocusedItem.SubItems[5].Text.ToString();
            comboBoxAmount.Items.Clear();
            for(int i = 1; i <= int.Parse(listViewMedicines.FocusedItem.SubItems[5].Text.ToString()); i++)
            {
                comboBoxAmount.Items.Add(i);
            }
        }

        private void comboBoxAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            double price;

            price = double.Parse(comboBoxAmount.Text.ToString()) * double.Parse(labelPrice.Text.ToString());

            textBoxTotalPrice.Text = price.ToString();
        }
    }
}
