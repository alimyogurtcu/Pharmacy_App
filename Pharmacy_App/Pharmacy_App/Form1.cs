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
        string xmlFile = @"C://students.xml";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(xmlFile))
            {

            }
            else
            {
                string xmlContent = "<medicines>" +
                    "</medicines>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlContent);

                using (XmlTextWriter writer = new XmlTextWriter(@xmlFile, null))
                {

                    writer.Formatting = Formatting.Indented; // optional
                    doc.Save(writer);
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Hide();
        }
    }
}
