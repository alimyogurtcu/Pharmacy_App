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
            string name, amount, cost, price, expirationDate, sellDate, status = ""; //decleration of values for get informations from textboxes 


            //getting values from textboxes to values.

            name = textBoxName.Text.ToString();
            amount = textBoxAmount.Text.ToString();
            cost = textBoxCost.Text.ToString();
            price = textBoxPrice.Text.ToString();
            expirationDate = dateTimePickerExpirationDate.Text.ToString();
            sellDate = dateTimePickerSellDate.Text.ToString();

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

            //adding new element and saving it 
            var newElement = new XElement("medicine",
            new XElement("names", name),
            new XElement("amount", amount),
            new XElement("cost", cost),
            new XElement("price", price),
            new XElement("expirationDate", expirationDate),
            new XElement("saleDate", sellDate),
            new XElement("status", status));

            doc.Element("medicines").Add(newElement);

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
