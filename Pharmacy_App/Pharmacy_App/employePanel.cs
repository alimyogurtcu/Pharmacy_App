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
using System.Data.SQLite;

namespace Pharmacy_App
{
    public partial class employePanel : Form
    {
        //sql*
        SQLiteConnection connHistory = new SQLiteConnection(@"Data Source= C:\Users\Public\PharmacyAppDatabase\history.db");
        SQLiteConnection connMedicines = new SQLiteConnection(@"Data Source= C:\Users\Public\PharmacyAppDatabase\medicines.db");
        SQLiteCommand cmd = new SQLiteCommand();
        //*sql

        List<medicineRecords> medicineRecordList = new List<medicineRecords>();
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";
        string historyXmlFileLocation = "C://Users/Public/PharmacyAppData/history.xml";


        XmlNodeList imagePathList;


        public string xmlName, xmlCategory, xmlExperationDate, xmlStatus, imagePathFull;
        public int xmlAmount;
        public double xmlMg, xmlCost, xmlPrice;
        public ulong xmlBarcodeNo;
        public int xmlCountNumber;


        public employePanel()
        {
            InitializeComponent();
        }

        public void Form_Reload(object sender, EventArgs e)
        {
            medicineRecordList.Clear();
            employePanel_Load(sender, e);
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            employeHistory EP = new employeHistory();
            EP.Show();
            this.Close();
        }

        private void textBoxBarcodeNo_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < medicineRecordList.Count; i++)
            {
                if (textBoxBarcodeNo.Text.ToString() == medicineRecordList[i].barcodeNo.ToString())
                {
                    xmlName = medicineRecordList[i].name;
                    xmlCategory = medicineRecordList[i].category;
                    xmlMg = medicineRecordList[i].mg;
                    xmlExperationDate = medicineRecordList[i].experationDate;
                    xmlAmount = medicineRecordList[i].amount;
                    xmlCost = medicineRecordList[i].cost;
                    xmlPrice = medicineRecordList[i].price;
                    xmlStatus = medicineRecordList[i].status;
                    xmlBarcodeNo = medicineRecordList[i].barcodeNo;

                    labelMedicineName.Text = medicineRecordList[i].name;
                    labelPrice.Text = medicineRecordList[i].price.ToString();
                    textBoxBarcodeNo.Text = medicineRecordList[i].barcodeNo.ToString();
                    comboBoxAmount.Items.Clear();
                    for (int j = 1; j <= int.Parse(medicineRecordList[i].amount.ToString().ToString()); j++)
                    {
                        comboBoxAmount.Items.Add(j);
                    }
                    break;
                }

            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            employeChooseMedicine ECM = new employeChooseMedicine();
            ECM.Show();
            this.Close();
        }

        public void updateViewList() // funchtion for get values from xml to view list
        {
            radioButtonRecipe.Checked = true;

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
            XmlNodeList barcodeNoList = medicines.GetElementsByTagName("barcodeNo");
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

        }

        private void employePanel_Load(object sender, EventArgs e)
        {
            //FULL SCREEN
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //FULL SCREEN

            this.comboBoxAmount.DropDownStyle = ComboBoxStyle.DropDownList;

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
                recipe, medicineName = "",
                errorMessage = "";
            int amount = 0;

            double totalPrice = 0;

            XmlDocument historyDoc = new XmlDocument();




            medicineName = labelMedicineName.Text.ToString();

            if (medicineName == "")
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

            if (xmlAmount.ToString() == "0")
            {
                errorMessage += "\nStok for this medicine is 0.(Empty stok)";
            }
            else { /*do nothing*/}

            if (errorMessage == "")
            {
                if (MessageBox.Show("Do you want to continue to sell process of this medicine ?", "medicine delete confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var doc = XDocument.Load(historyXmlFileLocation); //opening xml file


                    var newElement = new XElement("customer",
                    new XElement("customerName", customerName),
                    new XElement("medicineName", medicineName),
                    new XElement("mg", XmlConvert.ToString(xmlMg)),
                    new XElement("amount", amount),
                    new XElement("recipe", recipe),
                    new XElement("totalPrice", XmlConvert.ToString(totalPrice)),
                    new XElement("sellDate", System.DateTime.Now.ToString()));


                    doc.Element("customers").Add(newElement);

                    doc.Save(historyXmlFileLocation);

                    var medicineDoc = XDocument.Load(@xmlFileLocation);

                    var items = from item in medicineDoc.Descendants("medicine")
                                where (item.Element("name").Value == xmlName && item.Element("category").Value == xmlCategory && item.Element("mg").Value == xmlMg.ToString() && item.Element("experationDate").Value == xmlExperationDate && item.Element("amount").Value == xmlAmount.ToString() && item.Element("cost").Value == xmlCost.ToString() && item.Element("price").Value == xmlPrice.ToString() && item.Element("status").Value == xmlStatus.ToString() && item.Element("barcodeNo").Value == xmlBarcodeNo.ToString())
                                select item;

                    foreach (XElement itemElement in items)
                    {
                        itemElement.SetElementValue("amount", (xmlAmount - amount));

                    }

                    medicineDoc.Save(@xmlFileLocation);

                    //sql*history.db
                    connHistory.Open();
                    cmd.Connection = connHistory;
                    cmd.CommandText = "insert into History(CostumerName, MedicineName, Milligram, Amount, Recipe, TotalPrice, BarcodeNo, SellDate) Values('" + customerName + "', '" + medicineName + "', '" + xmlMg + "', '" + amount + "', '" + recipe + "', '" + totalPrice + "', '" + xmlBarcodeNo + "', '" + System.DateTime.Now + "')";
                    cmd.ExecuteNonQuery();
                    connHistory.Close();
                    //*sql


                    //sql*medicines.db
                    connMedicines.Open();
                    cmd.Connection = connMedicines;
                    cmd.CommandText = "Update Medicines set Amount = '" + (xmlAmount - amount).ToString() + "' where ROWID =" + xmlCountNumber + "";
                    cmd.ExecuteNonQuery();
                    connMedicines.Close();
                    //*sql

                    Form_Reload(sender, e);

                    labelMedicineName.Text = "";
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

        private void comboBoxAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            double price;

            price = double.Parse(comboBoxAmount.Text.ToString()) * double.Parse(labelPrice.Text.ToString());

            textBoxTotalPrice.Text = price.ToString();
        }
    }
}
