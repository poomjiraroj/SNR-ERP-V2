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

namespace SNR_ERP.mainPanelUC.Products.InsertSKUPanelUC
{
    public partial class ChooseWarehouse : UserControl
    {
        SqlCommand Cmd;
        SqlConnection Conn;
        SqlDataAdapter Da;
        DataTable Dt;

        public ChooseWarehouse()
        {
            InitializeComponent();
            String SQL = "Data Source=JISURFACE;Initial Catalog=SNRWareHouseData;Integrated Security=True";
            Conn = new SqlConnection(SQL);
            setCombobox();
        }

        public void setCombobox()
        {
            Conn.Open();
            Cmd = new SqlCommand("SelectCompany", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbCompany.DataSource = Dt;
            cbCompany.DisplayMember = "CompanyName";
            cbCompany.ValueMember = "CompanyID";
            Conn.Close();

            Conn.Open();
            Cmd = new SqlCommand("SelectWarehouse", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbWarehouse.DataSource = Dt;
            cbWarehouse.DisplayMember = "WarehouseName";
            cbWarehouse.ValueMember = "WarehouseID";
            Conn.Close();
        }

        public String getCompanyID()
        {
            return cbCompany.SelectedValue.ToString();
        }

        public String getCompany()
        {
            return cbCompany.Text;
        }

        public String getWarehouseID()
        {
            return cbWarehouse.SelectedValue.ToString();
        }

        public String getWarehouse()
        {
            return cbWarehouse.Text;
        }
    }
}