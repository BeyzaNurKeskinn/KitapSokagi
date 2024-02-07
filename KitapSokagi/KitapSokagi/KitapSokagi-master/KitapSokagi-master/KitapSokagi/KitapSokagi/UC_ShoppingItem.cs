using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace KitapSokagi
{
    public partial class UC_ShoppingItem : UserControl
    {
        string ID;
        byte[] picBox;
        Product Temp_product;
        public static bool CancelControl = false;
        public static bool TotalPaymentControl = false;
        public NumberFormatInfo provider = new NumberFormatInfo();
        public UC_ShoppingItem(ItemToPurchase purchase)
        {
            InitializeComponent();
            try
            {
                provider.NumberDecimalSeparator = ".";
                lblName.Text = purchase.Product.Name;
                lblProductQuantitiy.Text = purchase.Quantity.ToString();
                lblUnitPrice.Text = purchase.Product.Price + " TL";
                lblTotalPrice.Text = ((purchase.Quantity * double.Parse(purchase.Product.Price, provider)) + " TL").ToString();
                picCoverPage.Image = Util.ResizeBitmap(Util.stringToImage(purchase.Product.Picture),
                    picCoverPage.Width, picCoverPage.Height);
                ID = purchase.Product.Id;
                picBox = purchase.Product.Picture;
                Temp_product = purchase.Product;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Logger.log("Sepete Eklemek İçin Tıklayınız " + lblName.Text + " Button.");
            try
            {
                provider.NumberDecimalSeparator = ".";
                lblProductQuantitiy.Text = (int.Parse(lblProductQuantitiy.Text) + 1).ToString();
                lblTotalPrice.Text = ((double.Parse(Temp_product.Price, provider) * (int.Parse(lblProductQuantitiy.Text))) + " TL").ToString();
                ItemToPurchase item = new ItemToPurchase();
                item.Product = Temp_product;
                item.Quantity = 1;
                MainWindow.cart.addProduct(item);
                TotalPaymentControl = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSubtractProduct_Click(object sender, EventArgs e)
        {
            Logger.log("Sepetten Çıkarmak İçin Tıklayın " + lblName.Text + " Button.");
            try
            {
                if (int.Parse(lblProductQuantitiy.Text) > 0)
                {
                    lblProductQuantitiy.Text = (int.Parse(lblProductQuantitiy.Text) - 1).ToString();
                    lblTotalPrice.Text = ((double.Parse(Temp_product.Price) * (int.Parse(lblProductQuantitiy.Text))) + " TL").ToString();
                    ItemToPurchase item = new ItemToPurchase();
                    item.Product = Temp_product;
                    item.Quantity = 1;
                    MainWindow.cart.removeProduct(item);
                    TotalPaymentControl = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancelItem_Click(object sender, EventArgs e)
        {
            Logger.log("İptal etmek için tıklayın" + lblName.Text + " Button.");
            try
            {
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("Ürünü iptal etmek istediğinizden emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    CancelControl = true;
                    for (int i = 0; i < int.Parse(lblProductQuantitiy.Text); i++)
                    {
                        ItemToPurchase item = new ItemToPurchase();
                        item.Product = Temp_product;
                        item.Quantity = 1;
                        MainWindow.cart.removeProduct(item);
                        Util.FillShoppingListScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.log("Exception: " + ex.Message);
            }
        }
    }
}
