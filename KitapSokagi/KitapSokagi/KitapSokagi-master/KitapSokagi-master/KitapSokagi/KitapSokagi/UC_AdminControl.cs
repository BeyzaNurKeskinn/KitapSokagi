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
    public partial class UC_AdminControl : UserControl
    {
        public UC_AdminControl()
        {
            InitializeComponent();
        }
        private void btnAdminBook_Click(object sender, EventArgs e)
        {
            Logger.log("Yönetici Defteri Düğmesine Tıklayın.");
            btnAdminBook.BackColor = Color.White;
            btnCustomers.BackColor = System.Drawing.ColorTranslator.FromHtml("#9078A4");
            if (pnladminContainer.Controls["UC_AdminBook"]==null)
            {
                UC_AdminBook ucAB = new UC_AdminBook();
                ucAB.Dock = DockStyle.Fill;
                pnladminContainer.Controls.Add(ucAB);
            }
            pnladminContainer.Controls["UC_AdminBook"].BringToFront();
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Logger.log("Click to Admin Customer Button.");
            btnCustomers.BackColor = Color.White;
            btnAdminBook.BackColor = System.Drawing.ColorTranslator.FromHtml("#9078A4");
            if (pnladminContainer.Controls["UC_AdminCustomer"] == null)
            {
                UC_AdminCustomer ucAC = new UC_AdminCustomer();
                ucAC.Dock = DockStyle.Fill;
                pnladminContainer.Controls.Add(ucAC);
            }
            pnladminContainer.Controls["UC_AdminCustomer"].BringToFront();
        }
    }
}
