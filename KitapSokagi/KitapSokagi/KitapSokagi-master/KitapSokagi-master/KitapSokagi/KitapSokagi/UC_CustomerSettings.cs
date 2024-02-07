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
    public partial class UC_CustomerSettings : UserControl
    {
        public UC_CustomerSettings()
        {
            InitializeComponent();
        }

        private void btnEnableUptadeChangePasswordPanel_Click(object sender, EventArgs e)
        {
            pnlChangePassword.Visible = true;
        }

        private void btnUptadeCustomerInformations_Click(object sender, EventArgs e)
        {
            Logger.log("Müşteri Bilgilerini Güncellemek İçin Tıklayın Buton.");
            if(Util.ComputeSha256Hash(txtBoxPasswordControl.Text)
                == LoginedUser.getInstance().Customer.Password)
            {
                Database db = new Database();
                string ID = LoginedUser.getInstance().Customer.CustomerID;
                db.UpdateCustomer(new Customer(ID, txtBoxCustomerName.Text, txtBoxCustomerAddress.Text,
                    txtBoxCustomerEmail.Text, txtBoxCustomerUsername.Text, 
                    Util.ComputeSha256Hash(txtBoxPasswordControl.Text)));
            }
            else
            {
                MessageBox.Show("Lütfen Doğru Parolayı Girin.");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Logger.log("Şifre Değiştirme Butonuna Tıklayın.");
            if (Util.ComputeSha256Hash(txtBoxCustomerOldPassword.Text)
                 == LoginedUser.getInstance().Customer.Password)
            {
                LoginedUser.getInstance().Customer.Password = 
                    Util.ComputeSha256Hash(txtBoxCustomerNewPassword.Text);
                Database db = new Database();
                db.UpdateCustomer(LoginedUser.getInstance().Customer);
            }
            else
            {
                MessageBox.Show("Lütfen Eski Parolayı Doğru Girin.");
            }
        }

        private void UC_CustomerSettings_Load(object sender, EventArgs e)
        {
            Customer tmpCust = LoginedUser.getInstance().Customer;
            txtBoxCustomerName.Text = tmpCust.Name;
            txtBoxCustomerUsername.Text = tmpCust.Username;
            txtBoxCustomerAddress.Text = tmpCust.Address;
            txtBoxCustomerEmail.Text = tmpCust.Email;
        }
    }
}
