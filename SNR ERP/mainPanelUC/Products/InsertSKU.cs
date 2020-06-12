using SNR_ERP.DialogMeesageBox;
using SNR_ERP.mainPanelUC.Products.InsertSKUPanelUC;
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

namespace SNR_ERP
{
    public partial class InsertSKU : Form
    {
        SqlCommand Cmd;
        SqlConnection Conn;

        ChooseVehicle cv= new ChooseVehicle();
        ChooseColorVinyl cc = new ChooseColorVinyl();
        SKUandPrice SKUP = new SKUandPrice();
        ChooseWarehouse cw = new ChooseWarehouse();

        String BrandName;
        String SeriesName;
        String ModelID;
        String ModelName;

        String ColorID;
        String VNID;
        int Piece;
        int VNPiece;

        String SKU;
        Double Cost;
        Double WholeSale;
        Double Price;
        int Quantity;
        String Remark;

        String CompanyID;
        String WarehouseID;

        MessageDialog MD;

        int intPage = 0;
        public InsertSKU()
        {
            InitializeComponent();
            String SQL = "Data Source=JISURFACE;Initial Catalog=SNRWareHouseData;Integrated Security=True";
            Conn = new SqlConnection(SQL);
            btnConfirm.Visible = false;
            chooseVehicle();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch(intPage)
            {
                case 1: setVehicle();
                    break;

                case 2: setColorVinyl();
                    break;

                case 3: setWarehouse();
                    break;

                case 4: setSKU();
                    break;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            switch (intPage)
            {
                case 2:
                    chooseVehicle();
                    break;
                case 3:
                    ChooseColorVinyl();
                    break;
                case 4:
                    ChooseWarehouse();
                    break;
            }
        }

        public void chooseVehicle()
        {
            btnPrevious.Visible = false;
            intPage = 1;
            insertSKUPanel.Controls.Clear();
            cv.Dock = DockStyle.Fill;
            insertSKUPanel.Controls.Add(cv);
        }

        public void setVehicle()
        {
            if (cv.getModelID() != "ModelError")
            {
                ModelID = cv.getModelID();
                BrandName = cv.getBrandName();
                SeriesName = cv.getSeriesName();
                ModelName = cv.getModelName();
                lbBrand.Text = "แบรนด์ : " + BrandName;
                lbSeriesModel.Text = "รุ่น : " + SeriesName + " " + ModelName;
                ChooseColorVinyl();
            }
            else
            {
                MD = new MessageDialog("กรุณาระบุรุ่นรถให้ถูกต้อง");
                MD.ShowDialog();
            }
        }

        public void ChooseColorVinyl()
        {
            btnPrevious.Visible = true;
            intPage = 2;
            insertSKUPanel.Controls.Clear();
            cc.Dock = DockStyle.Fill;
            insertSKUPanel.Controls.Add(cc);
        }

        public void setColorVinyl()
        {
            ColorID = cc.getColorID();
            Piece = cc.getPiece();
            VNID = cc.getVNID();

            if(cc.getPiece()!=0)
            {
                lbColor.Text = cc.getColorName();
                lbIntroPiece.Text = "จำนวน :";
                lbPiece.Text = Piece.ToString();
                lbQN.Text = "ชิ้น";

                if (VNID!="none")
                {
                    if(cc.getVinylPiece()!=0)
                    {
                        lbVinyl.Text = cc.getVinyl();
                        lbIntroPieceVi.Text = "จำนวน :";
                        VNPiece = cc.getVinylPiece();
                        lbPieceVi.Text = VNPiece.ToString();
                        lbQVN.Text = "ชิ้น";
                        ChooseWarehouse();
                    }
                    else
                    {
                        MD = new MessageDialog("กรุณาระบุจำนวนชิ้นด้วย");
                        MD.ShowDialog();
                    }
                }
                else
                {
                    VNPiece = 0;
                    lbVinyl.Text = "";
                    lbIntroPieceVi.Text = "";
                    lbPieceVi.Text = "";
                    lbQVN.Text = "";
                    ChooseWarehouse();
                }
            }
            else
            {
                lbColor.Text = "";
                lbIntroPiece.Text = "";
                lbPiece.Text = "";
                lbQN.Text = "";
                MD = new MessageDialog("กรุณาระบุจำนวนชิ้นด้วย");
                MD.ShowDialog();
            }
        }
        
        public void ChooseWarehouse()
        {
            btnNext.Visible = true;
            btnConfirm.Visible = false;
            intPage = 3;
            insertSKUPanel.Controls.Clear();
            insertSKUPanel.Controls.Clear();
            cw.Dock = DockStyle.Fill;
            insertSKUPanel.Controls.Add(cw);
        }

        public void setWarehouse()
        {
            CompanyID = cw.getCompanyID();
            lbCompany.Text = "โรงงาน : " + cw.getCompany();
            WarehouseID = cw.getWarehouseID();
            lbWarehouse.Text = "คลังสินค้า : " + cw.getWarehouse();
            ChooseSKUPrice();
        }

        public void ChooseSKUPrice()
        {
            intPage = 4;
            btnNext.Visible = true;
            btnConfirm.Visible = false;
            insertSKUPanel.Controls.Clear();
            SKUP.Dock = DockStyle.Fill;
            insertSKUPanel.Controls.Add(SKUP);
        }

        public void setSKU()
        {
            SKU = (SKUP.getSKU()).ToUpper();
            Cost = SKUP.getCost();
            WholeSale = SKUP.getWholeSale();
            Price = SKUP.getPrice();
            Quantity = SKUP.getQuantity();
            Remark = SKUP.getRemark();

            if (SKU != "")
            {
                if (Cost != 0)
                {
                    if (WholeSale != 0)
                    {
                        if (Price != 0)
                        {
                            if(Quantity!=0)
                            {
                                btnConfirm.Visible = true;
                                btnNext.Visible = false;
                                lbiCost.Text = "ราคาทุน";
                                lbiWhole.Text = "ราคาส่ง";
                                lbiPrice.Text = "ราคาขาย";
                                lbSKU.Text = "SKU : " + SKU;
                                lbCost.Text = Cost.ToString();
                                lbWhole.Text = WholeSale.ToString();
                                lbPrice.Text = Price.ToString();
                                lbiQuan.Text = "จำนวนชุด";
                                lbQuan.Text = Quantity.ToString();

                            }
                            else
                            {
                                MD = new MessageDialog("กรุณาใส่จำนวนชุดให้ถูกต้อง");
                                MD.ShowDialog();
                            }
                        }
                        else
                        {
                            MD = new MessageDialog("กรุณาใส่ราคาให้ถูกค้อง");
                            MD.ShowDialog();
                        }
                    }
                    else
                    {
                        MD = new MessageDialog("กรุณาใส่ราคาให้ถูกค้อง");
                        MD.ShowDialog();
                    }
                }
                else
                {
                    MD = new MessageDialog("กรุณาใส่ราคาให้ถูกค้อง");
                    MD.ShowDialog();
                }
            }
            else
            {
                MD = new MessageDialog("กรุณาใส่ SKU");
                MD.ShowDialog();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Conn.Open();
            Cmd = new SqlCommand("insertSKU", Conn);
            Cmd.Parameters.Add(new SqlParameter("@SKU", SKU));
            Cmd.Parameters.Add(new SqlParameter("@ColorID", ColorID));
            Cmd.Parameters.Add(new SqlParameter("@VNID", VNID));
            Cmd.Parameters.Add(new SqlParameter("@Piece", Piece));
            Cmd.Parameters.Add(new SqlParameter("@VinylPiece", VNPiece));
            Cmd.Parameters.Add(new SqlParameter("@Quantity", Quantity));
            Cmd.Parameters.Add(new SqlParameter("@ModelID", ModelID));
            Cmd.Parameters.Add(new SqlParameter("@ProductID", "PD11111"));
            Cmd.Parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            Cmd.Parameters.Add(new SqlParameter("@WarehouseID", WarehouseID));
            Cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
            Cmd.Parameters.Add(new SqlParameter("@Cost", Cost));
            Cmd.Parameters.Add(new SqlParameter("@Wholesale", WholeSale));
            Cmd.Parameters.Add(new SqlParameter("@Price", Price));
            Cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Cmd.ExecuteNonQuery();
                this.Close();
            }
            catch(Exception ex)
            {
                MD = new MessageDialog("บันทึกข้อมูลไม่สำเร็จ กรุณาแก้ไขข้อมูล");
                MD.ShowDialog();
            }
            Conn.Close();
        }
    }
}
