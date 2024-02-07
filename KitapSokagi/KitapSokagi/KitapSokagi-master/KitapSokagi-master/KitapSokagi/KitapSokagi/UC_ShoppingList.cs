using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitapSokagi
{
    public partial class UC_ShoppingList : UserControl
    {
        public UC_ShoppingList()
        {
            InitializeComponent();
            lblTOTALPAYMENT.Text = MainWindow.cart.PaymentAmount.ToString() + " TL";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Logger.log("Tüm Ürünleri İptal Et Butonuna Tıklayın.");
            MainWindow.cart.cancelOrder();
            flowLayoutShoppingList.Controls.Clear();
            lblTOTALPAYMENT.Text = "0 TL";
        }
}
}
