using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_App
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AdminPanelAdd adminPanelAdd = new AdminPanelAdd();
            adminPanelAdd.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            AdminPanelDelete adminPanelDelete = new AdminPanelDelete();
            adminPanelDelete.Show();

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            AdminPanelUpdate adminPanelUpdate = new AdminPanelUpdate();
            adminPanelUpdate.Show();
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            AdminPanelHistory adminPanelHistory = new AdminPanelHistory();
            adminPanelHistory.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
