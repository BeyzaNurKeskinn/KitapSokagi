using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KitapSokagi
{
    public abstract class Product
    {

        //Ürün Sayfası
        public string Name { get; set; }
        public string Id { get; set; }
        public string Price { get; set; }
        public byte[] Picture { get; set; }
        public abstract string printProperties();
    }
}
