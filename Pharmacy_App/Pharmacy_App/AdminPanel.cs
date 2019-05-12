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
            adminPanelAdd.username = labelUsername.Text.ToString();
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            AdminPanelDelete adminPanelDelete = new AdminPanelDelete();
            adminPanelDelete.Show();
            adminPanelDelete.username = labelUsername.Text.ToString();
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            AdminPanelUpdate adminPanelUpdate = new AdminPanelUpdate();
            adminPanelUpdate.Show();
            adminPanelUpdate.username = labelUsername.Text.ToString();
            this.Close();
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            AdminPanelHistory adminPanelHistory = new AdminPanelHistory();
            adminPanelHistory.Show();
            adminPanelHistory.username = labelUsername.Text.ToString();
            this.Close();
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

            listViewMedicines.Columns.Add(" ", 80, HorizontalAlignment.Center);// sub item 0
            listViewMedicines.Columns.Add("Name", 110, HorizontalAlignment.Left);//  sub item 1
            listViewMedicines.Columns.Add("Category", 100, HorizontalAlignment.Center);// sub item 2
            listViewMedicines.Columns.Add("Mg", 50, HorizontalAlignment.Center);// sub item 3
            listViewMedicines.Columns.Add("Expiration Date", 150, HorizontalAlignment.Center); // sub item 4
            listViewMedicines.Columns.Add("Amount", 60, HorizontalAlignment.Center);// sub item 5
            listViewMedicines.Columns.Add("Cost", 50, HorizontalAlignment.Center);// sub item 6
            listViewMedicines.Columns.Add("Price", 50, HorizontalAlignment.Center);// sub item 7
            listViewMedicines.Columns.Add("Status", 100, HorizontalAlignment.Center);// sub item 8
            listViewMedicines.Columns.Add("Barcode No", 150, HorizontalAlignment.Center);//sub item 9
            listViewMedicines.Columns.Add("Upload Date", 145, HorizontalAlignment.Center);// sub item 10

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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            //FULL SCREEN
            FormBorderStyle = FormBorderStyle.None;// removing application borders
            WindowState = FormWindowState.Maximized;// maximazing application window
            //FULL SCREEN

            updateViewList();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Form_Reload(sender, e);

        }

        private void listViewMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            int medicineNumber = (int.Parse(listViewMedicines.FocusedItem.SubItems[0].Text.ToString()) - 1);

            //getting image from xml file

            pictureBoxImage.Image = Image.FromFile(imagePathList[medicineNumber].InnerXml.ToString());
            pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
            //---------------------------
        }

        private void buttonAddAdmin_Click(object sender, EventArgs e)
        {
            AdminPanelAddNewAdmin APA = new AdminPanelAddNewAdmin();
            APA.Show();
            APA.LoginnedAdminName = labelUsername.Text.ToString();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 LG = new Form1();
            LG.Show();
            this.Close();
        }
    }
}
