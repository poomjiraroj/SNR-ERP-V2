using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNR_ERP
{
    public partial class Products : UserControl
    {
        public Products()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSKU_Click(object sender, EventArgs e)
        {
            InsertSKU ISKU = new InsertSKU();
            ISKU.Show();
        }
    }
}
