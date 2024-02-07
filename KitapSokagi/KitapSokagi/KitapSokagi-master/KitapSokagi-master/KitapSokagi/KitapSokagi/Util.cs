using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace KitapSokagi
{
    public class Util
    {
        public static List<Product> RandomThreeProductList = new List<Product>();
        public static List<Product> BookList = new List<Product>();
        /// <özet>
        /// Bu fonksiyon şifreyi SHA256'ya çevirir.
        /// </özet>
        /// <param name="_customers">Bu parametre, string türünde şifredir.</param>
        public static string ComputeSha256Hash(string password)
        {
            //Şifre gizle 
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        /// <özet>
        /// Bu fonksiyon veri tabanından okunan Kitap Listesini döndürür.
        /// </özet>
        /// <döndürür>Bu işlev Ürün Listesini döndürür</döndürür>
        public static List<Product> FillBooksList()
        {
            Database db = new Database();
            db.BookList();
            return db.getBookList();
        }
        
       
       
        /// <özet>
        /// Bu fonksiyon veri tabanından okunan Müşteri Listesini döndürür.
        /// </özet>
        /// <geri döner>Bu işlev Müşteri Listesini döndürür</geri döner>
        public static List<Customer> FillCustomerList()
        {
            Database db = new Database();
            db.CustomerList();
            return db.getCustomerList();
        }
        /// <özet>
        /// Bu işlev, UserControl Kitaplarını doldurur.
        /// </özet>
        /// <param name="BookList">Bu parametre Ürün Listesidir.</param>
        /// <geri döner>Bu işlev, Kullanıcı Kontrol Kitaplarını döndürür</dönüşler>
        public static UC_Books FillUC_BooksList(List<Product> BookList)
        {
            UC_Books ucB = new UC_Books();
            foreach (Book _book in BookList)
            {
                ucB.flowLayoutBooks.Controls.Add(new UC_Book(_book));
            }
            ucB.Dock = DockStyle.Fill;
            return ucB;
        }
        /// <özet>
        /// Bu işlev, UserControl Müzik CD'lerini doldurur.
        /// </summary> /// <param name="BoMusicCDListokList">Bu parametre Ürün Listesidir.</param>
        /// <geri döner>Bu işlev, Kullanıcı Kontrollü Müzik CD'lerini döndürür.</dönüş>

        /// <özet>
        /// Bu işlev baytı görüntüye dönüştürür.
        /// </özet>
        /// <param name="inputString">Bu parametre, string türünde inputString'dir.</param>
        /// <dönüş>Bu işlev bitmap döndürür.</dönüş>
        public static Bitmap stringToImage(byte[] inputString)
        {
            byte[] imageBytes = inputString;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return new Bitmap(ms);
            }
        }
        /// <özet>
        /// Bu işlev bir görüntüyü yeniden boyutlandırır.
        /// </özet>
        /// <param name="bmp">Bu parametre Bitmap türünde bitmaptir.</param>
        /// <param name="width">Bu parametre genişliktir.</param>
        /// <param name="height">Bu parametre yüksekliktir.</param>
        /// <dönüş>Bu işlev bitmap döndürür.</dönüş>
        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }
            return result;
        }
        /// <özet>
        /// Bu işlev, zamana ve oturum açan kullanıcıya göre karşılama etiketi oluşturur.
        /// </özet>
        /// <döndürür>Bu işlev dize döndürür.</döndür>
        public static string WelcomeLabel()
        {
            string tmpUsername = LoginedUser.getInstance().Customer.Name;
            DateTime date = DateTime.Now;
            if (date.Hour <= 12 && date.Hour >= 05)
            {
                return "Hayırlı Sabahlar:)" + tmpUsername.ToUpper()
                     + "Kitap Sokağına Hoşgeldinizz! ";
            }
            else if (date.Hour <= 18 && date.Hour >= 12)
            {
                return "5dk sonra Geleceğim..." + tmpUsername.ToUpper()
                     + "Kitap Sokağına Hoşgeldinizz! ";
            }
            else if (date.Hour <= 21 && date.Hour >= 18)
            {
                return "Burası Bizim Mekan " + tmpUsername.ToUpper()
                    + "Kitap Sokağına Hoşgeldinizz! ";
            }
            else
            {
                return "Geceniz Hayra Kalsın.." + tmpUsername.ToUpper()
                    + "Kitap Sokağına Hoşgeldinizz!";
            }
        }
        /// <özet>
        /// Bu işlev gösterge tablosunu rastgele üç ürünle doldurur.
        /// </özet>
        /// <geri döner>Bu işlev, Kullanıcı Kontrol Panelini döndürür.</geri döner>
        public static UC_Dashboard FillDashboardScreen()
        {
            List<List<Product>> productList = new List<List<Product>>();
            productList.Add(Util.FillBooksList());
            Random rndm = new Random();
            UC_Dashboard ucD = new UC_Dashboard();
            UC_ProductFactory UCPF = new UC_ProductFactory();

            for (int i = 0; i < productList.Count; i++)
            {
                int random = rndm.Next(productList[i].Count);
                ucD.flowLayoutEditorsChoice.Controls.Add(UCPF.CreateUC_Product
                    (productList[i][random]));
            }
            ucD.Dock = DockStyle.Fill;
            return ucD;
        }
        /// <özet>
        /// Bu işlev alışveriş listesini doldurur.
        /// </özet>
        /// <geri döner>Bu işlev, Kullanıcı Kontrollü Alışveriş Listesini döndürür.</geri döner>
        public static UC_ShoppingList FillShoppingListScreen()
        {
            UC_ShoppingList UCItems = new UC_ShoppingList();
            foreach (ItemToPurchase item in ShoppingCart.ItemsToPurchase)
            {
                UCItems.flowLayoutShoppingList.Controls.Add(new UC_ShoppingItem(item));
            }
            UCItems.Dock = DockStyle.Fill;
            return UCItems;
        }
    }
}
