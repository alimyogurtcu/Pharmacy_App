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
        XmlNodeList imagePathList;
        public employePanel()
        {
            InitializeComponent();
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

        private void employePanel_Load(object sender, EventArgs e)
        {
            updateViewList();
        }
    }
}
