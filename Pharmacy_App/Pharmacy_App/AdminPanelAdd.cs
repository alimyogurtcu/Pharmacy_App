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
    public partial class AdminPanelAdd : Form
    {
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";
        string folderName = @"C:/Users/Public/PharmacyAppData";
        public AdminPanelAdd()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();// closing admin panel add form
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name, experationDate, status = "", category; //decleration of values for get informations from textboxes 
            double cost, price;
            int amount, mg, count;

            //getting values from textboxes to values.

            name = textBoxName.Text.ToString();
            amount = int.Parse(textBoxAmount.Text.ToString());
            mg = int.Parse(textBoxMg.Text.ToString());
            cost = double.Parse(textBoxCost.Text.ToString());
            price = double.Parse(textBoxPrice.Text.ToString());
            experationDate = dateTimePickerExpirationDate.Text.ToString();
            category = comboBoxCategory.Text.ToString();

            if (radioButtonSaleable.Checked) //here we are get status from salable radioButton
            {
                status = radioButtonSaleable.Text.ToString();
            }

            if (radioButtonUnsaleable.Checked) //here we are get status from unSalable radioButton
            {
                status = radioButtonUnsaleable.Text.ToString();
            }

            //-------------------------------------------


            var doc = XDocument.Load(@xmlFileLocation); //opening xml file

            XmlDocument medicines = new XmlDocument();
            medicines.Load(xmlFileLocation);

            XmlNodeList countL = medicines.GetElementsByTagName("countLastValue");

            count = int.Parse(countL[0].InnerXml);

            //adding new element and saving it 
            var newElement = new XElement("medicine",
            new XElement("count",++count),
            new XElement("name", name),
            new XElement("mg",mg),
            new XElement("amount", amount),
            new XElement("cost", cost),
            new XElement("price", price),
            new XElement("experationDate", experationDate),
            new XElement("status", status),
            new XElement("category", category));

            doc.Element("medicines").Add(newElement);


            var items = from item in doc.Descendants("medicines")
                        where item.Element("countLastValue").Value == (count-1).ToString()
                        select item;

            foreach (XElement itemElement in items)
            {
                itemElement.SetElementValue("countLastValue", count);
            }

            doc.Save(@xmlFileLocation);


        }

        private void AdminPanelAdd_Load(object sender, EventArgs e)
        {
        }

        private void ButtonCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
