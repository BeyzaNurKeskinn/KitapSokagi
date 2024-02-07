using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace KitapSokagi
{


    //veritabanı bağlantıları
    class Database
    {
        private DbConnection connection = new DbConnection();
        private DataTable customerTable = new DataTable();
        private DataTable bookTable = new DataTable();
        private DataTable billTable = new DataTable();
        private DataTable billDetailTable = new DataTable();
        private Customer customer;
        private Book book;

        private List<Product> books = new List<Product>();

        private List<Customer> customers = new List<Customer>();
        public void CustomerList()
        {
            try
            {
                customerTable.Clear();
                connection.Connection();
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Customer", connection.Connect);
                da.Fill(customerTable);
                connection.Close();
                for (int i = 0; i < customerTable.Rows.Count; i++)
                {
                    customer = new Customer(customerTable.Rows[i]["ID"].ToString(), customerTable.Rows[i]["Name"].ToString(), customerTable.Rows[i]["Address"].ToString(), customerTable.Rows[i]["Email"].ToString(), customerTable.Rows[i]["Username"].ToString(), customerTable.Rows[i]["Password"].ToString());
                    customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddCustomer(Customer customer)
        {
            try
            {
                connection.Connection();
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into Tbl_Customer(Name,Address,Email,Username,Password)values (@Name,@Address,@Email,@Username,@Password)", connection.Connect);
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Username", customer.Username);
                command.Parameters.AddWithValue("@Password", customer.Password);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Registration successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateCustomer(Customer customer)
        {
            try
            {
                connection.Connection();
                connection.Open();
                SqlCommand command = new SqlCommand("Update Tbl_Customer set Name=@Name,Address=@Address,Email=@Email,Username=@Username,Password=@Password where ID=@CustomerId", connection.Connect);
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Username", customer.Username);
                command.Parameters.AddWithValue("@Password", customer.Password);
                command.Parameters.AddWithValue("@CustomerId", customer.CustomerID);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Update successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BookList()
        {
            try
            {
                bookTable.Clear();
                connection.Connection();
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Book", connection.Connect);
                da.Fill(bookTable);
                connection.Close();
                for (int i = 0; i < bookTable.Rows.Count; i++)
                {
                    book = new Book(bookTable.Rows[i]["Name"].ToString(), bookTable.Rows[i]["ID"].ToString(), bookTable.Rows[i]["Price"].ToString(), bookTable.Rows[i]["ISBN"].ToString(), bookTable.Rows[i]["Author"].ToString(), bookTable.Rows[i]["Publisher"].ToString(), bookTable.Rows[i]["Page"].ToString(), (byte[])bookTable.Rows[i]["CoverPage"]);
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddBook(Book book)
        {
            try
            {
                connection.Connection();
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into Tbl_Book(ID,Name,Price,ISBN,Author,Publisher,Page,Coverpage) values(@Id,@Name,@Price,@Isbn,@Author,@Publisher,@Page,@Coverpage)", connection.Connect);
                command.Parameters.AddWithValue("@Id", book.Id);
                command.Parameters.AddWithValue("@Name", book.Name);
                command.Parameters.AddWithValue("@Price", book.Price);
                command.Parameters.AddWithValue("@Isbn", book.ISBN);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Publisher", book.Publisher);
                command.Parameters.AddWithValue("@Page", book.Page);
                command.Parameters.AddWithValue("@Coverpage", book.CoverPage);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Registration successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateBook(Book book)
        {
            try
            {
                connection.Connection();
                connection.Open();
                SqlCommand command = new SqlCommand("Update Tbl_Book set Name=@Name,Price=@Price,ISBN=@Isbn,Author=@Author,Publisher=@Publisher,Page=@Page,CoverPage=@Coverpage where ID=@ProductId", connection.Connect);
                command.Parameters.AddWithValue("@Name", book.Name);
                command.Parameters.AddWithValue("@Price", book.Price);
                command.Parameters.AddWithValue("@Isbn", book.ISBN);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Publisher", book.Publisher);
                command.Parameters.AddWithValue("@Page", book.Page);
                command.Parameters.AddWithValue("@Coverpage", book.CoverPage);
                command.Parameters.AddWithValue("@ProductId", book.Id);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Update successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeleteBook(Book book)
        {
            try
            {
                connection.Connection();
                connection.Open();
                SqlCommand command = new SqlCommand("Delete from Tbl_Book where ID=@ProductId", connection.Connect);
                command.Parameters.AddWithValue("@ProductId", book.Id);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Book deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        public void OrderList()
        {
            try
            {
                billTable.Clear();
                connection.Connection();
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select Date,TotalPrice,ID from Tbl_Bill where CustomerId=" + LoginedUser.getInstance().Customer.CustomerID, connection.Connect);
                da.Fill(billTable);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void OrderDetailList(int id)
        {
            try
            {
                billDetailTable.Clear();
                connection.Connection();
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select ProductName,UnitPrice,Quantity,TotalPrice from Tbl_BillProduct where BillId=" + id, connection.Connect);
                da.Fill(billDetailTable);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int billId;
        public void SaveOrder(string totalPrice)
        {
            try
            {
                connection.Connection();
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into Tbl_Bill(CustomerId,Date,TotalPrice) values(@CustomerId,@Date,@TotalPrice)", connection.Connect);
                command.Parameters.AddWithValue("@CustomerId", int.Parse(LoginedUser.getInstance().Customer.CustomerID));
                command.Parameters.AddWithValue("@Date", DateTime.Now);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                command.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("SELECT TOP 1 * FROM Tbl_Bill ORDER BY ID DESC", connection.Connect);
                billId = (int)cmd2.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SaveOrderDetail(string productName, string unitPrice, int quantity, string totalPrice)
        {
            try
            {
                connection.Connection();
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into Tbl_BillProduct(BillId,ProductName,UnitPrice,Quantity,TotalPrice) values(@BillId,@ProductName,@UnitPrice,@Quantity,@TotalPrice)", connection.Connect);
                command.Parameters.AddWithValue("@BillId", billId);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
  
        public List<Customer> getCustomerList()
        {
            return customers;
        }
    
        public List<Product> getBookList()
        {
            return books;
        }
       
        public DataTable getOrderSource()
        {
            return billTable;
        }
   
        public DataTable getOrderDetailSource()
        {
            return billDetailTable;
        }
    }
}
