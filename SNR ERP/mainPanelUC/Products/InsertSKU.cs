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

namespace SNR_ERP
{
    public partial class InsertSKU : Form
    {
        ChooseVehicle cv= new ChooseVehicle();
        ChooseColorVinyl cc = new ChooseColorVinyl();
        SKUandPrice SKUP = new SKUandPrice();

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

        MessageDialog MD;

        int intPage = 0;
        public InsertSKU()
        {
            InitializeComponent();
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

                case 3: setSKU();
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
                    ChooseSKUPrice();
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
                        ChooseSKUPrice();
                    }
                    else
                    {
                        MD = new MessageDialog("กรุณาระบุจำนวนชิ้นด้วย");
                        MD.ShowDialog();
                    }
                }
                else
                {
                    lbVinyl.Text = "";
                    lbIntroPieceVi.Text = "";
                    lbPieceVi.Text = "";
                    lbQVN.Text = "";
                    ChooseSKUPrice();
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
        public void ChooseSKUPrice()
        {
            intPage = 3;
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
            if(SKU!="")
            {
                if(Cost!=0)
                {
                    if(WholeSale!=0)
                    {
                        if(Price!=0)
                        {
                            lbiCost.Text = "ราคาทุน";
                            lbiWhole.Text = "ราคาส่ง";
                            lbiPrice.Text = "ราคาขาย";
                            lbSKU.Text = "SKU : " + SKU;
                            lbCost.Text = Cost.ToString();
                            lbWhole.Text = WholeSale.ToString();
                            lbPrice.Text = Price.ToString();
                            ChooseWarehouse();
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

        public void ChooseWarehouse()
        {
            intPage = 4;
            insertSKUPanel.Controls.Clear();
        }
    }
}
