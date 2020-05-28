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
using System.Reflection;

namespace SNR_ERP.mainPanelUC.Products.InsertSKUPanelUC
{
    public partial class ChooseVehicle : UserControl
    {
        SqlCommand Cmd;
        SqlConnection Conn;
        SqlDataAdapter Da;
        DataTable Dt;

        String BrandID;
        String BrandName;
        String SeriesID;
        String SeriesName;
        int ModelSelect;
        public ChooseVehicle() 
        {
            InitializeComponent();
            String SQL = "Server=tcp:jiserver.database.windows.net,1433;Initial Catalog=SNRWareHouseData;Persist Security Info=False;User ID=poom_jiraroj;Password=@Minimalism2020;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Conn = new SqlConnection(SQL);
            setCombobox();
        }

        public void setCombobox()
        {
            Conn.Open();
            Cmd = new SqlCommand("SelectBrand", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbBrand.DataSource = Dt;
            cbBrand.DisplayMember = "BrandName";
            cbBrand.ValueMember = "BrandID";
            Conn.Close();
        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrandID = cbBrand.SelectedValue.ToString();
            BrandName = cbBrand.Text;

            Conn.Close();
            Conn.Open();
            Cmd = new SqlCommand("SelectSeries", Conn);
            Cmd.Parameters.Add(new SqlParameter("@BrandID", BrandID));
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbSeries.DataSource = Dt;
            cbSeries.DisplayMember = "SeriesName";
            cbSeries.ValueMember = "SeriesID";
            Conn.Close();
        }

        private void cbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelSelect = 0;
            SeriesID = cbSeries.SelectedValue.ToString();
            SeriesName = cbSeries.Text;

            Conn.Close();
            Conn.Open();
            Cmd = new SqlCommand("SelectModel", Conn);
            Cmd.Parameters.Add(new SqlParameter("@SeriesID", SeriesID));
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbModel.DataSource = Dt;
            cbModel.DisplayMember = "Models";
            cbModel.ValueMember = "ModelID";
            Conn.Close();
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelSelect = 1;
        }

        public String getBrandName()
        {
            return cbBrand.Text;
        }

        public String getSeriesName()
        {
            return SeriesName;
        }

        public String getModelID()
        {
            if(ModelSelect==1)
            {
                return cbModel.SelectedValue.ToString();
            }
            else
            {
                return "ModelError";
            }
        }

        public String getModelName()
        {
            return cbModel.Text;
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSeries_Click(object sender, EventArgs e)
        {

        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {

        }
    }
}
