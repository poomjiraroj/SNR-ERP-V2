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
    public partial class AddBrandForm : Form
    {
        SqlCommand Cmd;
        SqlConnection Conn;

        DialogMeesageBox.MessageDialog MD;

        public AddBrandForm()
        {
            InitializeComponent();
            String SQL = "Data Source=JISURFACE;Initial Catalog=SNRWareHouseData;Integrated Security=True";
            Conn = new SqlConnection(SQL);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Conn.Open();
            Cmd = new SqlCommand("insertBrand", Conn);
            Cmd.Parameters.Add(new SqlParameter("@BrandName", txtBrand.Text));
            Cmd.Parameters.Add(new SqlParameter("@Description", txtDescription.Text));
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
