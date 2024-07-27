using MySql.Data.MySqlClient;
using System;
using System.Configuration;
namespace SuperMarket
{
    public class Product
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public string Category { get; set; }
        public int QuantityInStock { get; set; }
        public int Quantity { get; set; }
        public decimal total {get; set; } 
        public Product()
        {
            Quantity = 1;
            
        }

    }
    public class ProductDAL
    {
        private string connectionString;
        
        public ProductDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Product SearchProductsByBarcode(string barcode)
        {


            Product products = new Product();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"SELECT * FROM Products WHERE Barcode = '{barcode}'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]) - Convert.ToDecimal(reader["Disscount"]),
                                Barcode = reader["Barcode"].ToString(),
                                Category = reader["Category"].ToString(),
                                QuantityInStock = Convert.ToInt32(reader["QuantityInStock"])
                                
                        };
                            products = product;

                        }
                    }
                }
            }
            if (products.Barcode == null)
            {
                throw new ArgumentNullException("Product doesn't exist");
            }
            return products;
        }
        public void updateQuantity(Product product, int quantity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE Products SET QuantityInStock = QuantityInStock -{quantity} WHERE Barcode = {product.Barcode}";
                Console.WriteLine("Total amount: "+product.QuantityInStock.ToString(),"To - :"+quantity);
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }


}
