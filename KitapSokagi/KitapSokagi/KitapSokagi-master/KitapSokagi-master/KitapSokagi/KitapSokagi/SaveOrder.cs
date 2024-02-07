using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace KitapSokagi
{
    public class SaveOrder
    /// <özet>
    /// Bu fonksiyon sipariş bilgilerini veritabanına kaydeder.
    /// </özet>
    {

        
        public void SaveToDatabase(string cost)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            Database db = new Database();
            db.SaveOrder(cost);
            for (int i = 0; i < ShoppingCart.ItemsToPurchase.Count; i++)
            {
                double totalPrice = Convert.ToDouble((ShoppingCart.ItemsToPurchase[i].Product.Price), provider) * ShoppingCart.ItemsToPurchase[i].Quantity;
                string productName = ShoppingCart.ItemsToPurchase[i].Product.Name;
                int quantity = ShoppingCart.ItemsToPurchase[i].Quantity;
                string unitPrice = ShoppingCart.ItemsToPurchase[i].Product.Price+"TL";
                db.SaveOrderDetail(productName, unitPrice, quantity, totalPrice.ToString()+"TL");
            }
        }
    }
}
