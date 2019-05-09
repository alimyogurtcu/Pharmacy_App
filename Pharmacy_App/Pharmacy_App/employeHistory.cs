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
    public partial class employeHistory : Form
    {

        List<customerRecords> customerRecordsList = new List<customerRecords>();
        string historyXmlFileLocation = "C://Users/Public/PharmacyAppData/history.xml";// history xml
        

        public employeHistory()
        {
            InitializeComponent();
        }

        public void updateViewList() // funchtion for get values from xml to view list
        {

            // Adding columns for list view

            listViewHistory.Columns.Add(" ", 87, HorizontalAlignment.Center);// sub item 0
            listViewHistory.Columns.Add("Customer Name", 170, HorizontalAlignment.Left);//  sub item 1
            listViewHistory.Columns.Add("Medicine Name", 150, HorizontalAlignment.Center);// sub item 2
            listViewHistory.Columns.Add("Mg", 70, HorizontalAlignment.Center);// sub item 3
            listViewHistory.Columns.Add("Medicine Sold Amount", 150, HorizontalAlignment.Center); // sub item 4
            listViewHistory.Columns.Add("Total Price", 150, HorizontalAlignment.Center); // sub item 4
            listViewHistory.Columns.Add("Recipe", 150, HorizontalAlignment.Center);
            listViewHistory.Columns.Add("Sell Date", 150, HorizontalAlignment.Center);

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
                    mg = double.Parse(mgList[i].InnerXml),
                    amount = int.Parse(amountList[i].InnerXml),
                    recipe = recipeList[i].InnerXml,
                    totalPrice = double.Parse(totalPriceList[i].InnerXml),
                    sellDate = sellDateList[i].InnerXml,
                });

            }


            for (var i = 0; i < customerRecordsList.Count; i++)// Adding medicineRecors list's elements to the list view 
            {

                ListViewItem row = new ListViewItem((i + 1).ToString());

                ListViewItem.ListViewSubItem itms1 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].customerName.ToString());
                ListViewItem.ListViewSubItem itms8 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].medicineName.ToString());
                ListViewItem.ListViewSubItem itms2 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].mg.ToString());
                ListViewItem.ListViewSubItem itms3 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].amount.ToString());
                ListViewItem.ListViewSubItem itms4 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].totalPrice.ToString());
                ListViewItem.ListViewSubItem itms5 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].recipe.ToString());
                ListViewItem.ListViewSubItem itms6 = new ListViewItem.ListViewSubItem(row, customerRecordsList[i].sellDate.ToString());



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

        private void employeHistory_Load(object sender, EventArgs e)
        {
            //FULL SCREEN
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //FULL SCREEN

            updateViewList();
        }
    }
}
