using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KitapSokagi
{

    //Veritabanı müşteri bağlantıları
    public class Customer
    {
        private string customerID;
        private string name;
        private string address;
        private string email;
        private string username;
        private string password;
        public static int id = 1;
        public Customer(string customerID, string name, string address, string email, string username, string password)
        {
            this.CustomerID = customerID;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string printCustomerDetails()
        {
            return "CustomerID:" + CustomerID + " " + "Name:" + Name + " " + "Address:" + Address + " " +
                "Email:" + Email + " " + "Username" + Username + " " + "Password:" + Password;
        }
        public bool IsValid(string Username, string Password)
        {
            return this.Username.Equals(Username) && this.Password.Equals(Util.ComputeSha256Hash(Password));
        }
        public void saveCustomer()
        {
            Database db = new Database();
            db.AddCustomer(this);
        }
    }
}
