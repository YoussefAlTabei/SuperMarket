using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SuperMarket
{
    internal class addItem
    {
        string connectionString = "server = localhost; database = market; uid = root; password = TabeiyoussEf9";
        private MySqlConnection connection;
        private MySqlCommand command;
        
        public string Name { get; set; }    
        public string Category { get; set; }
        public double Barcode { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public addItem(TextBox barcode,TextBox category,TextBox name,TextBox price , TextBox quantity)
        {
            try
            {
                Name = name.Text;
                Category = category.Text;
                Barcode = Convert.ToDouble(barcode.Text);
                Price = Convert.ToDecimal(price.Text);
                Quantity = Convert.ToInt32(quantity.Text);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void insertItem()
        {
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = $"INSERT INTO products (Name, Category, Barcode, Price, QuantityInStock) VALUES ('{Name}', '{Category}',{Barcode},{Price},{Quantity});";
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Inserting data: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
