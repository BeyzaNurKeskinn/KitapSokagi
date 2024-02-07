using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KitapSokagi
{

    //Kitap veritabanı bağlantıları
    public class Book : Product
    {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Page { get; set; }
        public byte[] CoverPage { get; set; }
        public Book(string _name, string _price, string _ID, byte[] _coverPage)
        {
            base.Name = _name;
            base.Price = _price;
            base.Id = _ID;
            base.Picture = _coverPage;
        }
        public Book(string _name, string _id, string _price, string _isbn, string _author, string _publisher, string _page, byte[] _coverpage)
        {
            base.Name = _name;
            base.Id = _id;
            base.Price = _price;
            this.ISBN = _isbn;
            this.Author = _author;
            this.Publisher = _publisher;
            this.Page = _page;
            this.CoverPage = _coverpage;
        }
        public override string printProperties()
        {
            return "Name:" + base.Name + " Id:" + base.Id + " Price:" + base.Price + " ISBN:" + this.ISBN + " Author:" + this.Author + " Publisher" + this.Publisher + " Page:" + this.Page;
        }
    }
}
