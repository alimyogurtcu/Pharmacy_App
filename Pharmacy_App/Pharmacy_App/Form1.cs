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
    public partial class Form1 : Form
    {

        List<adminsRecords> adminsRecordsList = new List<adminsRecords>();

        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";
        string adminXmlFileLocation = "C://Users/Public/PharmacyAppData/admins.xml";
        string historyXmlFileLocation = "C://Users/Public/PharmacyAppData/history.xml";
        string folderName = @"C:/Users/Public/PharmacyAppData";
        string imageFolderName = @"C:/Users/Public/PharmacyAppData/Images";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FULL SCREEN
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //FULL SCREEN

            if (Directory.Exists(folderName))// checks if xml file created before or not
            {
                // since there is an xml file which alreay created 
                // do nothing
            }
            else// create's xml file
            {
                Directory.CreateDirectory(folderName);// creats folder

                string xmlContent = "<medicines>" +
                    "</medicines>";

                string adminsXmlContent = "<admins>" +
                    "<admin>" +
                    "<username>burak</username>" +
                    "<password>50mf</password>" +
                    "<lastLogin>new</lastLogin>" +
                    "</admin>" +
                    "</admins>";

                string historyXmlContent = "<customers>" +
                    "</customers>";

                XmlDocument historyDoc = new XmlDocument();
                historyDoc.LoadXml(historyXmlContent);

                using (XmlTextWriter writer = new XmlTextWriter(historyXmlFileLocation, null))
                {

                    writer.Formatting = Formatting.Indented; // optional
                    historyDoc.Save(writer);
                }

                XmlDocument adminDoc = new XmlDocument();
                adminDoc.LoadXml(adminsXmlContent);

                using (XmlTextWriter writer = new XmlTextWriter(adminXmlFileLocation, null))
                {

                    writer.Formatting = Formatting.Indented; // optional
                    adminDoc.Save(writer);
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlContent);

                using (XmlTextWriter writer = new XmlTextWriter(xmlFileLocation, null))
                {

                    writer.Formatting = Formatting.Indented; // optional
                    doc.Save(writer);
                }

            }

            if (Directory.Exists(imageFolderName))// checks if image folder is created before
            {
                // since image folder created do nothing
            }
            else// creates image folder
            {
                Directory.CreateDirectory(imageFolderName);
            }
            
                
            
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool loginCheck = false;

            XmlDocument admins = new XmlDocument();
            admins.Load(adminXmlFileLocation);

            XmlNodeList usernameList = admins.GetElementsByTagName("username");
            XmlNodeList passwordList = admins.GetElementsByTagName("password");

            for(int i = 0; i < usernameList.Count; i++)
            {
                adminsRecordsList.Add(new adminsRecords {
                    username = usernameList[i].InnerXml.ToString(),
                    password = passwordList[i].InnerXml.ToString(),
                });

            }

            for(int i = 0; i < adminsRecordsList.Count; i++)
            {
                if(textBoxName.Text == adminsRecordsList[i].username.ToString() && textBoxPassword.Text == adminsRecordsList[i].password.ToString())
                {

                    var adminsDoc = XDocument.Load(adminXmlFileLocation);

                    var items = from item in adminsDoc.Descendants("admin")
                                where (item.Element("username").Value == textBoxName.Text.ToString() && item.Element("password").Value == textBoxPassword.Text.ToString())
                                select item;
                    foreach (XElement itemElement in items)
                    {
                        itemElement.SetElementValue("username", textBoxName.Text.ToString());
                        itemElement.SetElementValue("password", textBoxPassword.Text.ToString());
                        itemElement.SetElementValue("lastLogin", System.DateTime.Now.ToString());
                    }

                    adminsDoc.Save(adminXmlFileLocation);


                    AdminPanel AP = new AdminPanel();
                    AP.labelUsername.Text = textBoxName.Text.ToString();
                    AP.Show();
                    this.Hide();
                    loginCheck = true;

                   

                    break;
                }
                else { /*doNothing*/}
            }
            if (!loginCheck)//login fails
            {
                labelErrorMessage.Visible = true;
            }
            else { /*doNothing*/}
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            employePanel EP = new employePanel();
            EP.Show();
            this.Hide();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
