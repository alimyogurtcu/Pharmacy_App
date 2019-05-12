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
    public partial class employeChooseMedicine : Form
    {

        List<medicineRecords> medicineRecordList = new List<medicineRecords>();// adding class
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";// xml file location

        XmlNodeList imagePathList;

        public employeChooseMedicine()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            employePanel EP = new employePanel();
            EP.Show();
            this.Close();
        }

        public void updateViewList() // funchtion for get values from xml to view list
        {

            // Adding columns for list view

            listViewMedicines.Columns.Add(" ", 80, HorizontalAlignment.Center);// sub item 0
            listViewMedicines.Columns.Add("Name", 100, HorizontalAlignment.Left);//  sub item 1
            listViewMedicines.Columns.Add("Category", 150, HorizontalAlignment.Center);// sub item 2
            listViewMedicines.Columns.Add("Mg", 50, HorizontalAlignment.Center);// sub item 3
            listViewMedicines.Columns.Add("Expiration Date", 150, HorizontalAlignment.Center); // sub item 4
            listViewMedicines.Columns.Add("Amount", 50, HorizontalAlignment.Center);// sub item 5
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
        private void employeChooseMedicine_Load(object sender, EventArgs e)
        {
            //FULL SCREEN
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //FULL SCREEN

            updateViewList();
        }

        private void listViewMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            employePanel EP = new employePanel();
            EP.Show();

            EP.xmlName = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            EP.xmlCategory = listViewMedicines.FocusedItem.SubItems[2].Text.ToString();
            EP.xmlMg = double.Parse(listViewMedicines.FocusedItem.SubItems[3].Text.ToString());
            EP.xmlExperationDate = listViewMedicines.FocusedItem.SubItems[4].Text.ToString();
            EP.xmlAmount = int.Parse(listViewMedicines.FocusedItem.SubItems[5].Text.ToString());
            EP.xmlCost = double.Parse(listViewMedicines.FocusedItem.SubItems[6].Text.ToString());
            EP.xmlPrice = double.Parse(listViewMedicines.FocusedItem.SubItems[7].Text.ToString());
            EP.xmlStatus = listViewMedicines.FocusedItem.SubItems[8].Text.ToString();
            EP.xmlBarcodeNo = ulong.Parse(listViewMedicines.FocusedItem.SubItems[9].Text.ToString());
            EP.xmlCountNumber = int.Parse(listViewMedicines.FocusedItem.SubItems[0].Text.ToString());

            EP.labelMedicineName.Text = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            EP.labelPrice.Text = listViewMedicines.FocusedItem.SubItems[7].Text.ToString();
            EP.textBoxBarcodeNo.Text = listViewMedicines.FocusedItem.SubItems[9].Text.ToString();
            EP.comboBoxAmount.Items.Clear();
            for (int i = 1; i <= int.Parse(listViewMedicines.FocusedItem.SubItems[5].Text.ToString()); i++)
            {
                EP.comboBoxAmount.Items.Add(i);
            }


            this.Close();
        }
    }
}
