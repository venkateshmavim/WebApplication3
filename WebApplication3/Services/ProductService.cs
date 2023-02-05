using System.Data.SqlClient;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class ProductService
    {

        private static string db_source = "mywebapps.database.windows.net";
        private static string db_user = "demo";
        private static string db_password = "Venkimeg@123";
        private static string db_database = "productdb";


         private SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_source;
            builder.UserID = db_user;
            builder.Password = db_password;
            builder.InitialCatalog = db_database;
            return new SqlConnection(builder.ConnectionString);


        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> productsList = new List<Product>();
            string statement = "SELECT ProductId,ProductName,Quantity from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Product product = new Product();
                    {
                        product.ProductId=reader.GetInt32(0);
                        product.ProductName=reader.GetString(1);
                        product.Quantity=reader.GetInt32(2);
                    };
                    productsList.Add(product);
                }
                conn.Close();
                return productsList;
            }

        }

    }
}
