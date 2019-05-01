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
        string xmlFileLocation = "C://Users/Sateri/Desktop/Pharmacy_App/Pharmacy_App/medicineInfo.xml";//this is path to the xml file

        public AdminPanelAdd()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            label6.Text = dateTimePickerExpirationDate.Text.ToString();
            //this.Close();// closing admin panel add form
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name,amount,cost,price; //decleration of values for get informations from textboxes 

            
            //getting values from textboxes to values.

            name = textBoxName.Text.ToString(); 
            amount = textBoxName.Text.ToString();
            cost = textBoxCost.Text.ToString();
            price = textBoxPrice.Text.ToString();
            //-------------------------------------------


            var doc = XDocument.Load(@xmlFileLocation);//opening xml file

            //adding new element and saving it 
            var newElement = new XElement("medicine",
            new XElement("name", name),
            new XElement("amount", amount),
            new XElement("cost", cost));
            new XElement("price", price);

            doc.Element("medicines").Add(newElement);

            doc.Save(@xmlFileLocation);


        
        }

        private void AdminPanelAdd_Load(object sender, EventArgs e)
        {
        }
        
    }
}
