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

        bool february,februaryExpirationDate;
        bool sellDayCheck = false;
        string xmlFileLocation = "C://Users/Sateri/Desktop/Pharmacy_App/Pharmacy_App/medicineInfo.xml";//this is path to the xml file
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
            string name,expirationDate,amount,sellDate,cost,price,validation; //decleration of values for get informations from textboxes 

            
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
            for(int ii = 2019; ii < 2301; ii++)//Adding items to the year combo box
            {
                comboBoxYear.Items.Add(ii);
            }

        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = int.Parse(comboBoxYear.Text.ToString());
            february = false;
            if (x % 4 == 0)
            {
                february = true;
            }
            else
            {
                february = false;
            }
            comboBoxMonth.Text = "";
            comboBoxDay.Text = "";
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month = comboBoxMonth.Text.ToString();

            if (month == "January" || month == "March" || month == "May" || month == "July" || month == "September" || month == "November")
            {
                if (sellDayCheck == false)
                {
                    for (int i = 1; i < 32; i++)
                    {
                        comboBoxDay.Items.Add(i);
                        sellDayCheck = true;
                    }
                }
                else // sellDayCheck == true
                {
                    for (int i = 1; i < 32; i++)
                    {
                        comboBoxDay.Items.Remove(i);
                    }

                    for (int i = 1; i < 32; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                }
            }
            else if (month == "February")
            {
                if (february)
                {
                    if (sellDayCheck == false)
                    {
                        for (int i = 1; i < 30; i++)
                        {
                            comboBoxDay.Items.Add(i);
                            sellDayCheck = true;
                        }

                    }
                    else
                    {
                        for (int i = 1; i < 32; i++)
                        {
                            comboBoxDay.Items.Remove(i);
                        }
                        for (int i = 1; i < 30; i++)
                        {
                            comboBoxDay.Items.Add(i);
                        }
                    }
                }
                else
                {
                    if (!sellDayCheck)
                    {
                        for (int i = 1; i < 29; i++)
                        {
                            comboBoxDay.Items.Add(i);
                            sellDayCheck = true;
                        }

                    }
                    else
                    {
                        for (int i = 1; i < 32; i++)
                        {
                            comboBoxDay.Items.Remove(i);
                        }
                        for (int i = 1; i < 29; i++)
                        {
                            comboBoxDay.Items.Add(i);
                        }
                    }
                }
            }
            else
            {
                if (!sellDayCheck)
                {
                    for (int i = 1; i < 31; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    sellDayCheck = true;
                }
                else
                {
                    for (int i = 1; i < 32; i++)
                    {
                        comboBoxDay.Items.Remove(i);
                    }
                    for (int i = 1; i < 31; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                }
            }
            comboBoxDay.Text = "";
        }
    }
}
