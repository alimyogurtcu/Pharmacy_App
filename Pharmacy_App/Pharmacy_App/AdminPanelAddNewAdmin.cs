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
    public partial class AdminPanelAddNewAdmin : Form
    {

        List<adminsRecords> adminsList = new List<adminsRecords>();// creating list depends on adminclass
        string adminXmlFileLocation = "C://Users/Public/PharmacyAppData/admins.xml";// path to the admins xml file
        public string xmlUsername, xmlPassword;
        public AdminPanelAddNewAdmin()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //decleration of values
            string username, password;
            bool control = true;

            username = textBoxUsername.Text.ToString();
            password = textBoxPassword.Text.ToString();

            if(username == null)
            {
                MessageBox.Show("Please enter username !", "validation of username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(password == null)
            {
                MessageBox.Show("Please enter password !", "validation of password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for(int i = 0; i < adminsList.Count; i++)
                {
                    if(username == adminsList[i].username.ToString())
                    {
                        control = false;
                    }
                    else { /*doNothing*/}
                }

                if (control)
                {
                    if (MessageBox.Show("Do you want to contiune to add this admin ?", "admin add confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var adminDoc = XDocument.Load(adminXmlFileLocation);

                        var newElement = new XElement("admin",
                            new XElement("username", username),
                            new XElement("password", password),
                            new XElement("lastLogin", "new"));
                        adminDoc.Element("admins").Add(newElement);

                        adminDoc.Save(adminXmlFileLocation);

                        MessageBox.Show("New admin '" + username + "' is added", "admin was added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBoxUsername.Text = "";
                        textBoxPassword.Text = "";
                        labelUsername.Text = "";
                        textBoxUpdatePassword.Text = "";

                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("You cant use same username for different admins !", "same username usage error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxUsername.Focus();
                }
                
            }

            refresh_form(sender, e);


        }

        public void refresh_form(object sender, EventArgs e)
        {
            listViewAdmins.Items.Clear();
            listViewAdmins.Columns.Clear();
            adminsList.Clear();
            AdminPanelAddNewAdmin_Load(sender,e);

        }

        private void AdminPanelAddNewAdmin_Load(object sender, EventArgs e)
        {
            listViewAdmins.Columns.Add(" ", 75, HorizontalAlignment.Center);// adding empty column for numbers to the list view
            listViewAdmins.Columns.Add("Username", 75, HorizontalAlignment.Center);// adding columns to the list view
            listViewAdmins.Columns.Add("Password", 75, HorizontalAlignment.Center);// adding columns to the list view
            listViewAdmins.Columns.Add("Last Login", 75, HorizontalAlignment.Center);

            XmlDocument adminXmlDocument = new XmlDocument();// opends admin xml file
            adminXmlDocument.Load(adminXmlFileLocation);//---------------------------

            XmlNodeList usernameList = adminXmlDocument.GetElementsByTagName("username");// getting elements from xml files to node lists
            XmlNodeList passwordList = adminXmlDocument.GetElementsByTagName("password");// getting elements from xml files to node lists
            XmlNodeList lastLoginList = adminXmlDocument.GetElementsByTagName("lastLogin");

            for (int i = 0; i < usernameList.Count; i++)// push values from nodelists to admin lists
            {
                adminsList.Add(new adminsRecords
                {
                    username = usernameList[i].InnerXml,// adds username 
                    password = passwordList[i].InnerXml,// adds password
                    lastLogin = lastLoginList[i].InnerXml,
                    
                });
            }


            for(int i = 0; i < adminsList.Count; i++)// adding row 
            {
                ListViewItem row = new ListViewItem((i+1).ToString());

                ListViewItem.ListViewSubItem itemUsername = new ListViewItem.ListViewSubItem(row, adminsList[i].username.ToString());// adding username to second column
                ListViewItem.ListViewSubItem itemPassword = new ListViewItem.ListViewSubItem(row, adminsList[i].password.ToString());// adding password to third column
                ListViewItem.ListViewSubItem itemLastLogin = new ListViewItem.ListViewSubItem(row, adminsList[i].lastLogin.ToString());// adding password to third column

                
                row.SubItems.Add(itemUsername);
                row.SubItems.Add(itemPassword);
                row.SubItems.Add(itemLastLogin);

                listViewAdmins.Items.Add(row);
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string username;

            username = textBoxUsername.Text.ToString();

            if(username == "")
            {
                MessageBox.Show("Please choose admin that you want to delete", "admin delete confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else if(adminsList.Count == 1)
            {
                MessageBox.Show("You cant delete all admins.", "admin delete number confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(MessageBox.Show("Do you want to continue to delete selected admin ? ","delete confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var adminXml = XDocument.Load(adminXmlFileLocation);
                adminXml.Descendants("admin")
                    .Where(x => (string)x.Element("username") == username)
                    .Remove();

                adminXml.Save(adminXmlFileLocation);

                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
                labelUsername.Text = "";
                textBoxUpdatePassword.Text = "";

                refresh_form(sender, e);

            }
            
            
        }

        private void listViewAdmins_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxUsername.Text = listViewAdmins.FocusedItem.SubItems[1].Text.ToString();
            textBoxPassword.Text = listViewAdmins.FocusedItem.SubItems[2].Text.ToString();
            xmlUsername = listViewAdmins.FocusedItem.SubItems[1].Text.ToString();
            xmlPassword = listViewAdmins.FocusedItem.SubItems[2].Text.ToString();
            labelUsername.Text = listViewAdmins.FocusedItem.SubItems[1].Text.ToString();
            textBoxUpdatePassword.Text = listViewAdmins.FocusedItem.SubItems[2].Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel AP = new AdminPanel();
            AP.Show();
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string password;
            password = textBoxUpdatePassword.Text;

            
            
            if(textBoxUpdatePassword.Text == "")
            {
                MessageBox.Show("Please be sure to write new password correctly !", "username password error check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(MessageBox.Show("Do you want to continue to update user '"+ xmlUsername +"' ? ","update confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes){
                    var doc = XDocument.Load(adminXmlFileLocation);

                    var items = from item in doc.Descendants("admin")
                                where item.Element("username").Value == xmlUsername
                                select item;

                    foreach (XElement itemElement in items)
                    {
                        itemElement.SetElementValue("password", password);
                    }

                    doc.Save(adminXmlFileLocation);

                    MessageBox.Show("Admin '" + xmlUsername + "' was updated", "update info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh_form(sender, e);
                }
                else{ /*doNothing*/}
            }
           
        }
    }
}
