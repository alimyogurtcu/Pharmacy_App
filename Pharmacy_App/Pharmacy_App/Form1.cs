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
        string xmlFileLocation = @"C:/Users/Public/PharmacyAppData/medicineInfo.xml";
        string folderName = @"C:/Users/Public/PharmacyAppData";
        string imageFolderName = @"C:/Users/Public/PharmacyAppData/Images";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(folderName))// checks if xml file created before or not
            {
                // since there is an xml file which alreay created 
                // do nothing
            }
            else// create's xml file
            {
                Directory.CreateDirectory(folderName);

                string xmlContent = "<medicines>" +
                    "</medicines>";
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
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employePanel EP = new employePanel();
            EP.Show();
            this.Hide();
        }
    }
}
