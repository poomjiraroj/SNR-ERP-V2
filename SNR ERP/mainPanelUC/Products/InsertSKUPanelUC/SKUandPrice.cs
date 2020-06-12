using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNR_ERP.mainPanelUC.Products.InsertSKUPanelUC
{
    public partial class SKUandPrice : UserControl
    {
        public SKUandPrice()
        {
            InitializeComponent();
        }

        public String getSKU()
        {
            try
            {
                return txtSKU.Text;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public double getCost()
        {
            try
            {
                return Convert.ToDouble(txtCost.Text);
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public double getWholeSale()
        {
            try
            {
                return Convert.ToDouble(txtWholesale.Text);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Double getPrice()
        {
            try
            {
                return Convert.ToDouble(txtPrice.Text);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int getQuantity()
        {
            try
            {
                return Convert.ToInt32(txtQuantity.Text);
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public String getRemark()
        {
            return txtRemark.Text;
        }
    }
}
