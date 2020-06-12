using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SNR_ERP.mainPanelUC.Products.InsertSKUPanelUC.addVehicle
{
    public partial class AddSeries : Form
    {
        SqlCommand Cmd;
        SqlConnection Conn;

        DialogMeesageBox.MessageDialog MD;

        String BrandID;
        public AddSeries(String BrandID)
        {
            InitializeComponent();
            String SQL = "Data Source=JISURFACE;Initial Catalog=SNRWareHouseData;Integrated Security=True";
            Conn = new SqlConnection(SQL);

            this.BrandID = BrandID;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Conn.Open();
            Cmd = new SqlCommand("insertSeries", Conn);
            Cmd.Parameters.Add(new SqlParameter("@BrandID", BrandID));
            Cmd.Parameters.Add(new SqlParameter("@SeriesName", txtSeries.Text));
            Cmd.Parameters.Add(new SqlParameter("SeriesDescription", txtDescription.Text));
            Cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Cmd.ExecuteNonQuery();
                this.Close();
            }
            catch (Exception ex)
            {
                MD = new DialogMeesageBox.MessageDialog("บันทึกข้อมูลไม่สำเร็จ กรุณาแก้ไขข้อมูล");
                MD.ShowDialog();
            }
            Conn.Close();
        }
    }
}
