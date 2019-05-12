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
    public partial class AdminPanelHistory : Form
    {

        //sql*
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= C:\Users\Public\PharmacyAppDatabase\history.db");
        SQLiteCommand cmd = new SQLiteCommand();
        //*sql

        List<customerRecords> customerRecordsList = new List<customerRecords>();
        string historyXmlFileLocation = "C://Users/Public/PharmacyAppData/history.xml";// history xml
        public string username;

        public AdminPanelHistory()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            AdminPanel AP = new AdminPanel();
            AP.Show();
            AP.labelUsername.Text = username;
            this.Close();
        }

        public void updateViewList() // funchtion for get values from xml to view list
        {

            // Adding columns for list view

            listViewHistory.Columns.Add(" ", 87, HorizontalAlignment.Center);// sub item 0
            listViewHistory.Columns.Add("Customer Name", 170, HorizontalAlignment.Left);//  sub item 1
            listViewHistory.Columns.Add("Medicine Name", 150, HorizontalAlignment.Center);// sub item 2
            listViewHistory.Columns.Add("Mg", 70, HorizontalAlignment.Center);// sub item 3
            listViewHistory.Columns.Add("Medicine Sold Amount", 150, HorizontalAlignment.Center); // sub item 4
            listViewHistory.Columns.Add("Total Price", 150, HorizontalAlignment.Center); // sub item 5
            listViewHistory.Columns.Add("Recipe", 150, HorizontalAlignment.Center);// sub item 6    
            listViewHistory.Columns.Add("Sell Date", 150, HorizontalAlignment.Center);// sub item 7

            //----------------------------------------------------------------------------

            // getting elements in xml to the temperory list. Each tag have its own list. 
            XmlDocument history = new XmlDocument();
            history.Load(historyXmlFileLocation);

            XmlNodeList customerNameList = history.GetElementsByTagName("customerName");
            XmlNodeList medicineNameList = history.GetElementsByTagName("medicineName");
            XmlNodeList amountList = history.GetElementsByTagName("amount");
            XmlNodeList recipeList = history.GetElementsByTagName("recipe");
            XmlNodeList totalPriceList = history.GetElementsByTagName("totalPrice");
            XmlNodeList mgList = history.GetElementsByTagName("mg");
            XmlNodeList sellDateList = history.GetElementsByTagName("sellDate");


            //--------------------------------------------------------------------------------------


            for (int i = 0; i < customerNameList.Count; i++)// Assıgning every element from xml document to developer defined medicineRecords class list
            {
                customerRecordsList.Add(new customerRecords
                {
                    customerName = customerNameList[i].InnerXml,
                    medicineName = medicineNameList[i].InnerXml,
                    mg = XmlConvert.ToDouble(mgList[i].InnerXml),
                    amount = int.Parse(amountList[i].InnerXml),
                    recipe = recipeList[i].InnerXml,
                    totalPrice = XmlConvert.ToDouble(totalPriceList[i].InnerXml),
                    sellDate = sellDateList[i].InnerXml,
                });

            }


            for (var i = 0; i < customerRecordsList.Count; i++)// Adding medicineRecors list's elements to the list view 
            {

                ListViewItem row = new ListViewItem((i + 1).ToString());// sub item 0

                ListViewItem.ListViewSubItem itms1 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].customerName.ToString());// sub item 1
                ListViewItem.ListViewSubItem itms8 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].medicineName.ToString());// sub item 2 
                ListViewItem.ListViewSubItem itms2 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].mg.ToString());// sub item 3
                ListViewItem.ListViewSubItem itms3 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].amount.ToString());// sub item 4
                ListViewItem.ListViewSubItem itms4 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].totalPrice.ToString());// sub item 5
                ListViewItem.ListViewSubItem itms5 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].recipe.ToString());// sub item 6
                ListViewItem.ListViewSubItem itms6 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].sellDate.ToString());// sub item 7



                row.ImageIndex = i;
                row.SubItems.Add(itms1);
                row.SubItems.Add(itms8);
                row.SubItems.Add(itms2);
                row.SubItems.Add(itms3);
                row.SubItems.Add(itms4);
                row.SubItems.Add(itms5);
                row.SubItems.Add(itms6);

                listViewHistory.Items.Add(row);
            }

        }

        public void Form_Reload(object sender, EventArgs e)
        {
            listViewHistory.Items.Clear();
            listViewHistory.Columns.Clear();
            customerRecordsList.Clear();
            AdminPanelHistory_Load(sender, e);
        }

        private void AdminPanelHistory_Load(object sender, EventArgs e)
        {
            //FULL SCREEN
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //FULL SCREEN

            updateViewList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string customerName = "", medicineName = "", soldAmount = "", recipe = "", sellDate = "";
            double mg,totalPrice;
            try
            {
                if(MessageBox.Show("Do you want to continue to delete this history ? ","History delete confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    customerName = listViewHistory.FocusedItem.SubItems[1].Text.ToString();
                    medicineName = listViewHistory.FocusedItem.SubItems[2].Text.ToString();
                    mg = double.Parse(listViewHistory.FocusedItem.SubItems[3].Text.ToString());
                    soldAmount = listViewHistory.FocusedItem.SubItems[4].Text.ToString();
                    totalPrice = double.Parse(listViewHistory.FocusedItem.SubItems[5].Text.ToString());
                    recipe = listViewHistory.FocusedItem.SubItems[6].Text.ToString();
                    sellDate = listViewHistory.FocusedItem.SubItems[7].Text.ToString();

                    var medicineDoc = XDocument.Load(historyXmlFileLocation);

                    medicineDoc.Descendants("customer")
                        .Where(x => (string)x.Element("customerName") == customerName)
                        .Where(y => (string)y.Element("medicineName") == medicineName)
                        .Where(z => (string)z.Element("mg") == XmlConvert.ToString(mg))
                        .Where(t => (string)t.Element("amount") == soldAmount)
                        .Where(a => (string)a.Element("totalPrice") == XmlConvert.ToString(totalPrice))
                        .Where(b => (string)b.Element("recipe") == recipe)
                        .Where(c => (string)c.Element("sellDate") == sellDate)
                        .Remove();

                    medicineDoc.Save(historyXmlFileLocation);

                    //sql*
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM History WHERE ROWID ='" + int.Parse(listViewHistory.FocusedItem.SubItems[0].Text.ToString()) + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //*sql

                    Form_Reload(sender, e);
                }
                else { /*doNothing*/}
            }
                
            catch
            {
                MessageBox.Show("Please select history", "history select confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
