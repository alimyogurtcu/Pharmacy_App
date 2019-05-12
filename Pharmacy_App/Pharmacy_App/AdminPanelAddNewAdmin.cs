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
    public partial class AdminPanelAddNewAdmin : Form
    {

        //sql*
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= C:\Users\Public\PharmacyAppDatabase\admins.db");
        SQLiteCommand cmd = new SQLiteCommand();
        //*sql

        List<adminsRecords> adminsList = new List<adminsRecords>();// creating list depends on adminclass
        string adminXmlFileLocation = "C://Users/Public/PharmacyAppData/admins.xml";// path to the admins xml file
        public string xmlUsername, xmlPassword;
        string username = "", password = "";
        public string LoginnedAdminName;


        public AdminPanelAddNewAdmin()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //decleration of values
            string username, password, errorMessage = "";
            bool control = true;

            username = textBoxUsername.Text.ToString();
            password = textBoxPassword.Text.ToString();

            if (username == "")
            {
                errorMessage += "Please enter Username !\n";
            }
            else { /*doNothing*/}
            if (password == "")
            {
                errorMessage += "Please enter Password !";
            }
            else { /*doNothing*/}
            if (errorMessage == "")
            {
                for (int i = 0; i < adminsList.Count; i++)
                {
                    if (username == adminsList[i].username.ToString() && password == adminsList[i].password.ToString())
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


                        //sql*
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = "insert into Admins(AdminName, Password) Values('" + username + "', '" + password + "')";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        //*sql

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
                    MessageBox.Show("You cant use same username and password for different admins !", "same username and password usage error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxUsername.Focus();
                }

            }
            else
            {
                MessageBox.Show(errorMessage, "input checks", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            refresh_form(sender, e);


        }

        public void refresh_form(object sender, EventArgs e)
        {
            listViewAdmins.Items.Clear();
            listViewAdmins.Columns.Clear();
            adminsList.Clear();
            AdminPanelAddNewAdmin_Load(sender, e);

        }

        public void uploadAdminListView() // funchtion for get admins username and password
        {
            listViewAdmins.Columns.Add(" ", 75, HorizontalAlignment.Center);// adding empty column for numbers to the list view
            listViewAdmins.Columns.Add("Username", 130, HorizontalAlignment.Center);// adding columns to the list view
            listViewAdmins.Columns.Add("Password", 130, HorizontalAlignment.Center);// adding columns to the list view
            listViewAdmins.Columns.Add("Last Login", 175, HorizontalAlignment.Center);

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


            for (int i = 0; i < adminsList.Count; i++)// adding row 
            {
                ListViewItem row = new ListViewItem((i + 1).ToString());

                ListViewItem.ListViewSubItem itemUsername = new ListViewItem.ListViewSubItem(row, adminsList[i].username.ToString());// adding username to second column
                ListViewItem.ListViewSubItem itemPassword = new ListViewItem.ListViewSubItem(row, adminsList[i].password.ToString());// adding password to third column
                ListViewItem.ListViewSubItem itemLastLogin = new ListViewItem.ListViewSubItem(row, adminsList[i].lastLogin.ToString());// adding password to third column


                row.SubItems.Add(itemUsername);
                row.SubItems.Add(itemPassword);
                row.SubItems.Add(itemLastLogin);

                listViewAdmins.Items.Add(row);
            }
        }

        private void AdminPanelAddNewAdmin_Load(object sender, EventArgs e)
        {
            //FULL SCREEN
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //FULL SCREEN

            uploadAdminListView();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            string username = "", password = "", lastLogin = "";

            try
            {
                username = listViewAdmins.FocusedItem.SubItems[1].Text.ToString();
                password = listViewAdmins.FocusedItem.SubItems[2].Text.ToString();
                lastLogin = listViewAdmins.FocusedItem.SubItems[3].Text.ToString();

                if (adminsList.Count == 1)
                {
                    MessageBox.Show("You cant delete all admins.", "admin delete number confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (MessageBox.Show("Do you want to continue to delete selected admin ? ", "delete confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var adminXml = XDocument.Load(adminXmlFileLocation);
                    adminXml.Descendants("admin")
                        .Where(x => (string)x.Element("username") == username)
                        .Where(y => (string)y.Element("password") == password)
                        .Where(z => (string)z.Element("lastLogin") == lastLogin)
                        .Remove();

                    adminXml.Save(adminXmlFileLocation);

                    username = "";
                    password = "";
                    lastLogin = "";

                    //sql*
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM Admins WHERE ROWID ='" + int.Parse(listViewAdmins.FocusedItem.SubItems[0].Text.ToString()) + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //*sql



                    refresh_form(sender, e);

                }

            }
            catch
            {
                MessageBox.Show("Please select an admin before delete it !","Select Admin",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void listViewAdmins_SelectedIndexChanged(object sender, EventArgs e)
        {
            xmlUsername = listViewAdmins.FocusedItem.SubItems[1].Text.ToString();
            xmlPassword = listViewAdmins.FocusedItem.SubItems[2].Text.ToString();
            labelUsername.Text = listViewAdmins.FocusedItem.SubItems[1].Text.ToString();
            textBoxUpdatePassword.Text = listViewAdmins.FocusedItem.SubItems[2].Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel AP = new AdminPanel();
            AP.Show();
            AP.labelUsername.Text = LoginnedAdminName;
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string password;
            password = textBoxUpdatePassword.Text;



            if (textBoxUpdatePassword.Text == "")
            {
                MessageBox.Show("Please be sure to write new password correctly !", "username password error check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Do you want to continue to update user '" + xmlUsername + "' ? ", "update confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var doc = XDocument.Load(adminXmlFileLocation);

                    var items = from item in doc.Descendants("admin")
                                where item.Element("username").Value == xmlUsername && item.Element("password").Value == xmlPassword
                                select item;

                    foreach (XElement itemElement in items)
                    {
                        itemElement.SetElementValue("password", password);
                    }

                    doc.Save(adminXmlFileLocation);

                    //sql*
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "Update Admins set Password ='" + textBoxPassword.Text + "' where AdminName ='" + listViewAdmins.FocusedItem.SubItems[1].Text.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //*sql

                    MessageBox.Show("Admin '" + xmlUsername + "' was updated", "update info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    labelUsername.Text = "";
                    textBoxUpdatePassword.Text = "";
                    xmlUsername = "";
                    xmlPassword = "";

                    refresh_form(sender, e);
                }
                else { /*doNothing*/}
            }

        }
    }
}
