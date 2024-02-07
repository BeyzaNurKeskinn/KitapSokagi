using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSokagi
{
    public class ItemToPurchase
    {
        private Product product;
        private int quantity;
        public Product Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
