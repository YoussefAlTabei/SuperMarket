using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public string Category { get; set; }
        public int QuantityInStock { get; set; }
        


    }
    public class ProductDAL
    {
        private string connectionString;
        
        public ProductDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> SearchProductsByName(string barcode)
        {


            List<Product> products = new List<Product>();
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
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Barcode = reader["Barcode"].ToString(),
                                Category = reader["Category"].ToString(),
                                QuantityInStock = Convert.ToInt32(reader["QuantityInStock"])
                                
                            };
                            products.Add(product);
                            
                        }
                    }
                }
            }

            return products;
        }
    }


}
