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
    public partial class AdminPanelDelete : Form
    {
        //sql*
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= Database/medicines.db");
        SQLiteCommand cmd = new SQLiteCommand();
        //*sql

        int medicineNumber;
        

        List<medicineRecords> medicineRecordList = new List<medicineRecords>();// adding class
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";// adding file location
        XmlNodeList imagePathList;


        // variables for find in xml file 
        int xmlAmount;
        double xmlCost, xmlPrice, xmlMg;
        string xmlName, xmlStatus, xmlExperationDate, xmlUpdatedDate, xmlCategory;

        public void Form_Reload(object sender, EventArgs e)
        {
            listViewMedicines.Items.Clear();
            listViewMedicines.Columns.Clear();
            medicineRecordList.Clear();
            AdminPanelDelete_Load(sender, e);
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {

            if(labelMedicineName.Text == "")
            {
                MessageBox.Show("Please chose an item from list", "selection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(MessageBox.Show("Are you sure to delete this medicine ? ", "medicine delete confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {

                // searching values is xml File and removing it 

                //sql*
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Medicines WHERE ROWID ='" + int.Parse(listViewMedicines.FocusedItem.SubItems[0].Text.ToString()) + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                //*sql

                var medicineDoc = XDocument.Load(xmlFileLocation);

                medicineDoc.Descendants("medicine")
                    .Where(x => (string)x.Element("name") == xmlName)
                    .Where(y => (string)y.Element("amount") == xmlAmount.ToString())
                    .Where(z => (string)z.Element("cost") == xmlCost.ToString())
                    .Where(t => (string)t.Element("category") == xmlCategory)
                    .Where(a => (string)a.Element("price") == xmlPrice.ToString())
                    .Where(b => (string)b.Element("mg") == xmlMg.ToString())
                    .Where(c => (string)c.Element("status") == xmlStatus)
                    .Where(d => (string)d.Element("experationDate") == xmlExperationDate)
                    .Where(l => (string)l.Element("updatedDate") == xmlUpdatedDate)
                    .Remove();

                medicineDoc.Save(xmlFileLocation);


                //------------------------------------------------


                // clearing labels after delet procress
                labelMedicineName.Text = "";
                labelMedicineAmount.Text = "";
                labelMedicineCategory.Text = "";
                labelMedicineCost.Text = "";
                labelMedicinePrice.Text = "";
                labelMedicineMg.Text = "";
                labelMedicineStatus.Text = "";
                labelMedicineExperationDate.Text = "";
                labelMedicineUploadDate.Text = "";
                pictureBoxMedicine.Image = null;
                //---------------------------------------


                Form_Reload(sender, e);

            }
            else{ /*do nothing*/}


        }

        public AdminPanelDelete()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            AdminPanel AP = new AdminPanel();
            AP.Show();
            this.Close();

        }

        public void updateViewList() // funchtion for get values from xml to view list
        {

            // Adding columns for list view

            listViewMedicines.Columns.Add(" ", 87, HorizontalAlignment.Center);
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


            for (var i = 0; i < medicineRecordList.Count; i++)// Adding medicineRecors list's elements to the list view 
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

        private void AdminPanelDelete_Load(object sender, EventArgs e)
        {
            //FULL SCREEN
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //FULL SCREEN

            updateViewList();
        }

        private void listViewMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {

            // getting values from listview to labels 

            medicineNumber = int.Parse(listViewMedicines.FocusedItem.SubItems[0].Text.ToString())-1;
            labelMedicineName.Text = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            labelMedicineAmount.Text = listViewMedicines.FocusedItem.SubItems[5].Text.ToString();
            labelMedicineCategory.Text = listViewMedicines.FocusedItem.SubItems[2].Text.ToString();
            labelMedicineCost.Text = listViewMedicines.FocusedItem.SubItems[6].Text.ToString();
            labelMedicinePrice.Text = listViewMedicines.FocusedItem.SubItems[7].Text.ToString();
            labelMedicineStatus.Text = listViewMedicines.FocusedItem.SubItems[8].Text.ToString();
            labelMedicineUploadDate.Text = listViewMedicines.FocusedItem.SubItems[9].Text.ToString();
            labelMedicineExperationDate.Text = listViewMedicines.FocusedItem.SubItems[4].Text.ToString();
            labelMedicineMg.Text = listViewMedicines.FocusedItem.SubItems[3].Text.ToString();
            pictureBoxMedicine.Image = Image.FromFile(imagePathList[medicineNumber].InnerXml);
            pictureBoxMedicine.SizeMode = PictureBoxSizeMode.StretchImage;
            //------------------------------------------------------

            //getting values to variables for search in xml file 

            xmlName = listViewMedicines.FocusedItem.SubItems[1].Text.ToString();
            xmlAmount = int.Parse(listViewMedicines.FocusedItem.SubItems[5].Text.ToString());
            xmlCost = double.Parse(listViewMedicines.FocusedItem.SubItems[6].Text.ToString());
            xmlCategory = listViewMedicines.FocusedItem.SubItems[2].Text.ToString();
            xmlPrice = double.Parse(listViewMedicines.FocusedItem.SubItems[7].Text.ToString());
            xmlStatus = listViewMedicines.FocusedItem.SubItems[8].Text.ToString();
            xmlUpdatedDate = listViewMedicines.FocusedItem.SubItems[9].Text.ToString();
            xmlMg = double.Parse(listViewMedicines.FocusedItem.SubItems[3].Text.ToString());
            xmlExperationDate = listViewMedicines.FocusedItem.SubItems[4].Text.ToString();

            //--------------------------------------------------

            

            
        } 
    }
}
