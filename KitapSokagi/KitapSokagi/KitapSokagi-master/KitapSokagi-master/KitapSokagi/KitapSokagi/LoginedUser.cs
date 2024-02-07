using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KitapSokagi
{
    public class LoginedUser
    {
        private Customer customer;
        private static LoginedUser loginedUser;
        public Customer Customer { get => customer; set => customer = value; }
        public static LoginedUser getInstance()
        {
            if (loginedUser == null)
            {
                loginedUser = new LoginedUser();
            }
            return loginedUser;
        }
    }
}
