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
    public partial class ChooseColorVinyl : UserControl
    {
        SqlCommand Cmd;
        SqlConnection Conn;
        SqlDataAdapter Da;
        DataTable Dt;

        public ChooseColorVinyl()
        {
            InitializeComponent();
            String SQL = "Data Source=JISURFACE;Initial Catalog=SNRWareHouseData;Integrated Security=True";
            Conn = new SqlConnection(SQL);
            setCombobox();
        }
        public void setCombobox()
        {
            Conn.Open();
            Cmd = new SqlCommand("SelectColor", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbColor.DataSource = Dt;
            cbColor.DisplayMember = "Color";
            cbColor.ValueMember = "ColorID";
            Conn.Close();

            Conn.Open();
            Cmd = new SqlCommand("SelectVinyl", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbVinyl.DataSource = Dt;
            cbVinyl.DisplayMember = "Vinyl"; 
            cbVinyl.ValueMember = "VNID";
            Conn.Close();

            txtVinylPiece.Visible = false;
            label5.Visible = false; 
        }

        public String getColorID()
        {
            return cbColor.SelectedValue.ToString();
        }

        public String getColorName()
        {
            return cbColor.Text;
        }

        public String getVNID()
        {
            return cbVinyl.SelectedValue.ToString();
        }

        public String getVinyl()
        {
            return cbVinyl.Text;
        }

        public int getPiece()
        {
            try
            {
                return Convert.ToInt32(txtPiece.Text);
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public int getVinylPiece()
        {
            try
            {
                if(txtVinylPiece.Text!=null)
                {
                    return Convert.ToInt32(txtVinylPiece.Text);
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        private void cbVinyl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbVinyl.SelectedValue.ToString() != "none")
            {
                txtVinylPiece.Visible = true;
                label5.Visible = true;
            }
            else
            {
                txtVinylPiece.Visible = false;
                label5.Visible = false;
            }
        }
    }
}
