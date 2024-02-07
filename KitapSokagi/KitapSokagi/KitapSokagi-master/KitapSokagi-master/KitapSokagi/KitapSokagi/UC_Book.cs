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
    public partial class UC_Book : UserControl
    {
        string ID;
        byte[] picBox;
        public UC_Book(Book _book)
        {
            InitializeComponent();
            lblBookName.Text = _book.Name;
            lblAuthor.Text = _book.Author;
            lblPublisher.Text = _book.Publisher;
            lblPageNumber.Text = _book.Page;
            lblISBN.Text = _book.ISBN;
            lblPrice.Text = _book.Price;
            ID = _book.Id;
            picCoverPage.Image = Util.ResizeBitmap(Util.stringToImage(_book.CoverPage),
                picCoverPage.Width, picCoverPage.Height);
            picBox = _book.CoverPage;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Logger.log("Click to Add to Cart " + lblBookName.Text + " Book Button.");
            lblProductNumber.Text = (int.Parse(lblProductNumber.Text) + 1).ToString();
            ItemToPurchase item = new ItemToPurchase();
            item.Product = new Book(lblBookName.Text, lblPrice.Text, ID, picBox);
            item.Quantity = 1;
            MainWindow.cart.addProduct(item);
        }
        private void btnSubtractProduct_Click(object sender, EventArgs e)
        {
            Logger.log("Click to Delete from Cart " + lblBookName.Text + " Book Button.");
            if (int.Parse(lblProductNumber.Text) > 0)
            {
                lblProductNumber.Text = (int.Parse(lblProductNumber.Text) - 1).ToString();
                ItemToPurchase item = new ItemToPurchase();
                item.Product = new Book(lblBookName.Text, lblPrice.Text, ID, picBox);
                item.Quantity = 1;
                MainWindow.cart.removeProduct(item);
            }
        }
    }
}
