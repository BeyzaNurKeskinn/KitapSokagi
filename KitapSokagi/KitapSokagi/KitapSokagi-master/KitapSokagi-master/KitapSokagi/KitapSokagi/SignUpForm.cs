using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KitapSokagi
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }
        private void CreateAccount()
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                bool control = false;
                bool isEmail = Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                Database db = new Database();
                db.CustomerList();
                List<Customer> _cuslist = db.getCustomerList();
                foreach (Customer _customer in _cuslist)
                {
                    if (_customer.Username == txtUsername.Text)
                    {
                        MessageBox.Show("Kullanıcı adı zaten alınmış.Kullanıcı adınızı değiştirin.");
                        control = true;
                    }
                }
                if (control == false && isEmail == true)
                {
                    Customer newCustomer = new Customer("",
                    txtName.Text, txtAddress.Text, txtEmail.Text, txtUsername.Text, Util.ComputeSha256Hash(txtPassword.Text));
                    newCustomer.saveCustomer();
                    CreateAccount();
                }
                if (isEmail == false)
                {
                    MessageBox.Show("E-posta adresiniz doğrulanmadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
