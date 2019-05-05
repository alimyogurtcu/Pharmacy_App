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
    public partial class AdminPanel : Form
    {

        List<medicineRecords> medicineRecordList = new List<medicineRecords>();// adding class
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";// adding file location

        XmlNodeList imagePathList;

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AdminPanelAdd adminPanelAdd = new AdminPanelAdd();
            adminPanelAdd.Show();
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            AdminPanelDelete adminPanelDelete = new AdminPanelDelete();
            adminPanelDelete.Show();

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            AdminPanelUpdate adminPanelUpdate = new AdminPanelUpdate();
            adminPanelUpdate.Show();
            this.Close();
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            AdminPanelHistory adminPanelHistory = new AdminPanelHistory();
            adminPanelHistory.Show();
        }

        public void Form_Reload(object sender, EventArgs e)
        {
            listViewMedicines.Items.Clear();
            listViewMedicines.Columns.Clear();
            medicineRecordList.Clear();
            AdminPanel_Load(sender, e);
        }

        public void updateViewList() // funchtion for get values from xml to view list
        {

            // Adding columns for list view
            
            listViewMedicines.Columns.Add(" ", 25, HorizontalAlignment.Center);
            listViewMedicines.Columns.Add("Name", 120, HorizontalAlignment.Left);
            listViewMedicines.Columns.Add("Category", 100, HorizontalAlignment.Center);
            listViewMedicines.Columns.Add("Mg", 50, HorizontalAlignment.Center);
            listViewMedicines.Columns.Add("Expiration Date", 150, HorizontalAlignment.Center);
            listViewMedicines.Columns.Add("Amount", 50, HorizontalAlignment.Center);
            listViewMedicines.Columns.Add("Cost", 50, HorizontalAlignment.Center);
            listViewMedicines.Columns.Add("Price", 50, HorizontalAlignment.Center);
            listViewMedicines.Columns.Add("Status", 70, HorizontalAlignment.Center);
            listViewMedicines.Columns.Add("Upload Date", 150, HorizontalAlignment.Center);

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


            for (var i = 0; i < medicineRecordList.Count; i++)// Adding medicineRecors list's elements to the list view 
            {
                ListViewItem row = new ListViewItem((i+1).ToString());

                ListViewItem.ListViewSubItem itms1 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].name.ToString());
                ListViewItem.ListViewSubItem itms8 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].category.ToString());
                ListViewItem.ListViewSubItem itms2 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].mg.ToString());
                ListViewItem.ListViewSubItem itms3 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].experationDate.ToString());
                ListViewItem.ListViewSubItem itms4 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].amount.ToString());
                ListViewItem.ListViewSubItem itms5 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].cost.ToString());
                ListViewItem.ListViewSubItem itms6 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].price.ToString());
                ListViewItem.ListViewSubItem itms7 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].status.ToString());
                ListViewItem.ListViewSubItem itms9 = new ListViewItem.ListViewSubItem(row, medicineRecordList[i].updatedDate.ToString());



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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            updateViewList();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Form_Reload(sender,e);
            
        }

        private void listViewMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            int medicineNumber = (int.Parse(listViewMedicines.FocusedItem.SubItems[0].Text.ToString()) - 1);

            //getting image from xml file

            pictureBoxImage.Image = Image.FromFile(imagePathList[medicineNumber].InnerXml.ToString());
            pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
            //---------------------------
        }
    }
}
