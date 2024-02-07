using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace KitapSokagi
{
    class DbConnection
    {
        private SqlConnection connect;

        public SqlConnection Connect { get => connect; set => connect = value; }
        public void Connection()
        {
            var connectionString = @"Data Source=Beyza\Beyza;Initial Catalog=Kitaplar; Integrated Security =True";//veritabanını oluşturduktan sonra buraya bağlantı dizesini girin
            connect = new SqlConnection(connectionString);
        }
        public void Open()
        {
            connect.Open();
        }
        public void Close()
        {
            connect.Close();
        }
    }
}
