using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitapSokagi
{
    public class UC_ProductFactory
    /// <özet>
    /// Bu işlev, parametreye göre UserControl'ü döndürür.
    /// </özet>
    /// <param name="_product">Bu parametre bir üründür.</param>
    {
        public UserControl CreateUC_Product(Product _product)
        {
            if (_product is Book)
            {
                return new UC_Book((Book)_product);
            }
            else
                return null;
        }
    }
}
