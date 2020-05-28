using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNR_ERP
{
    public partial class Dashboard : Form
    {
        DashboardControl DC = new DashboardControl();
        Products pd = new Products();

        public Dashboard()
        {
            InitializeComponent();
            dashboardLoading();
        }

        public void dashboardLoading()
        {
            mainPanel.Controls.Clear();
            DC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(DC);
            lbHome.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lbProducts.Font = new Font("Segoe UI", 15, FontStyle.Regular);
            lbOrders.Font = new Font("Segoe UI", 15, FontStyle.Regular);
            lbSetting.Font = new Font("Segoe UI", 15, FontStyle.Regular);
        }

        private void lbProducts_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            pd.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(pd);
            lbHome.Font = new Font("Segoe UI", 15,FontStyle.Regular);
            lbProducts.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lbOrders.Font = new Font("Segoe UI", 15, FontStyle.Regular);
            lbSetting.Font = new Font("Segoe UI", 15, FontStyle.Regular);
        }

        private void lbHome_Click(object sender, EventArgs e)
        {
            dashboardLoading();
        }
    }
}
