using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace KitapSokagi
{
    public class ShoppingCart
    {
        private static List<ItemToPurchase> itemsToPurchase = new List<ItemToPurchase>();
        private string CustomerId;
        private double paymentAmount;
        private string paymentType;
        /// <özet>
        /// Bu işlevler alıcılar ve ayarlayıcılardır.
        /// </özet>
        public string CustomerId1 { get => CustomerId; set => CustomerId = value; }
        public double PaymentAmount { get => paymentAmount; set => paymentAmount = value; }
        public string PaymentType { get => paymentType; set => paymentType = value; }
        public static List<ItemToPurchase> ItemsToPurchase { get => itemsToPurchase; set => itemsToPurchase = value; }

        public NumberFormatInfo provider = new NumberFormatInfo();
        public ShoppingCart(string _CustomerId, double _paymentAmount, string _paymentType, List<ItemToPurchase> _ItemsToPurchase)
        {
            CustomerId = _CustomerId; ///Bu parametre müşterinin kimliğidir.</ param >
            paymentAmount = _paymentAmount;///Bu parametre ödeme tutarıdır.</ param >
            paymentType = _paymentType;///Bu parametre ödeme türüdür.</param>
            ItemsToPurchase = _ItemsToPurchase;///Bu parametre, satın alma sayfasındaki öğedir.</ param >
        }
        /// <özet>
        /// Bu fonksiyon satın alınacak ürünleri yazdırır.
        /// </özet>
        public string printProducts()
        {
            string ProductInfo = "";
            foreach (var item in ItemsToPurchase)
            {
                ProductInfo += "Ürün adı :" + item.Product.Name + Environment.NewLine
                    + "Ürün Id :" + item.Product.Id + Environment.NewLine
                    + "Ürün maliyeti:" + item.Product.Price + Environment.NewLine
                    + "ürün sayısı :" + item.Quantity + Environment.NewLine;
            }
            return ProductInfo;
        }/// <özet>
         /// Bu fonksiyon alışveriş sitesinden alınacak ürünü alışveriş sepetine ekler.
         /// </özet>
         /// Bu parametre alışveriş sepetine eklenen üründür.</param>
        public void addProduct(ItemToPurchase addProduct)
        {
            try
            {
                provider.NumberDecimalSeparator = ".";
                foreach (ItemToPurchase item in ItemsToPurchase)
                {
                    if (item.Product.Name == addProduct.Product.Name)
                    {
                        paymentAmount += addProduct.Quantity * double.Parse(item.Product.Price, provider);
                        item.Quantity += addProduct.Quantity;
                        return;
                    }
                }
                ItemsToPurchase.Add(addProduct);
                paymentAmount += addProduct.Quantity * double.Parse(addProduct.Product.Price, provider);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void removeProduct(ItemToPurchase removeProduct)
        {
            try
            {
                provider.NumberDecimalSeparator = ".";

                foreach (ItemToPurchase item in ItemsToPurchase)
                {
                    if (item.Product.Name == removeProduct.Product.Name)
                    {
                        if (item.Quantity > removeProduct.Quantity)
                        {
                            paymentAmount -= removeProduct.Quantity * double.Parse(item.Product.Price, provider);
                            item.Quantity -= removeProduct.Quantity;
                            return;
                        }
                        else
                        {
                            paymentAmount -= item.Quantity * double.Parse(item.Product.Price, provider);
                            ItemsToPurchase.Remove(item);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <özet>
        /// Bu fonksiyon, alışveriş sitesinden satın alınacak ürünü alışveriş sepetine kaldırır.
        /// </özet>
        /// <param name="addProduct">Bu parametre alışveriş sepetinden silinen üründür.</param>
        public void placeOrder()
        {
            paymentAmount = 0;
            ItemsToPurchase.Clear();
        }
        public void cancelOrder()
        {
            paymentAmount = 0;
            ItemsToPurchase.Clear();
        }
        public void sendInvoidcebyEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kitapsokagi@gmail.com");
                mail.To.Add(LoginedUser.getInstance().Customer.Email);
                mail.Subject = "Kitap Sokağı Faturası";
                mail.Body = "İşte faturanız. Bizi tercih ettiğiniz için teşekkürler.";
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("kitapsokagi@gmail.com", "zrmwvjwlqdljlisu");
                SmtpServer.EnableSsl = true;
                Attachment item = new Attachment("InvoicePDF.pdf");
                mail.Attachments.Add(item);
                SmtpServer.Send(mail);
                MessageBox.Show("Faturanız e-posta adresinize gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public string sendInvoicebySMS()
        {
            return ("Mesajınız telefon numaranıza gönderildi.");
        }
    }
}
