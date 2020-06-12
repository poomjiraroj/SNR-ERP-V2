using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SNR_ERP
{
    public partial class Products : UserControl
    {
        SqlCommand Cmd;
        SqlConnection Conn;
        SqlDataAdapter Da;
        DataTable Dt;

        public Products()
        {
            InitializeComponent();
            String SQL = "Data Source=JISURFACE;Initial Catalog=SNRWareHouseData;Integrated Security=True";
            Conn = new SqlConnection(SQL);
            setGV();
        }

        public void setGVDesign()
        {
            gvSKU.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvSKU.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvSKU.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvSKU.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvSKU.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvSKU.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvSKU.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvSKU.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvSKU.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void setGV()
        {
            Conn.Open();
            Cmd = new SqlCommand("SelectSKU", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);
            gvSKU.DataSource = Dt;
            Conn.Close();
            setGVDesign();
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
