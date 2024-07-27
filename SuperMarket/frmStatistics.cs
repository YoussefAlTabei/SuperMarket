using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static SuperMarket.frmStatistics;
namespace SuperMarket
{
    public partial class frmStatistics : Form
    {
        private MySqlConnection connection;
        static string connectionString = Product.connectionString;
        private DataTable table = new DataTable();
        List<Product> products = new List<Product>();
        List<string> listOfReceipts = new List<string>();
        public frmStatistics()
        {
            InitializeComponent();
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("TotalQuantity", typeof(int));
            table.Columns.Add("TotalPrice", typeof(decimal));
            connection = new MySqlConnection(connectionString);
            retreiveAllData();
            Array enumValues = Enum.GetValues(typeof(Months));

            // Add each enum value to the ComboBox
            foreach (Months month in enumValues)
            {
                cbxMonth.Items.Add(month);
            }
            foreach (string item in listOfReceipts)
            {

                string[] split = item.Split('_');
                if (!cbxYear.Items.Contains(split[1]))
                {
                    cbxYear.Items.Add(split[1]);
                }
            }
            getBusiestMonth();

        }
        public enum Months
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        void retreiveAllData()
        {

            try
            {
                connection.Open();
                string receiptNamesQuery = "SELECT DISTINCT receiptName FROM receipts";
                MySqlCommand receiptNamesCommand = new MySqlCommand(receiptNamesQuery, connection);
                using (MySqlDataReader receiptNamesReader = receiptNamesCommand.ExecuteReader())
                {
                    while (receiptNamesReader.Read())
                    {
                        listOfReceipts.Add(receiptNamesReader["receiptName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            foreach (Product product in products)
            {
                table.Rows.Add(product.Name, product.Quantity, product.Price * product.Quantity);
            }
            dataGridView1.DataSource = table;
        }
        void fillList(MySqlDataReader reader, Product product)
        {
            
            product.Name = reader["Name"].ToString();
            product.Price = Convert.ToDecimal(reader["Price"]);
            product.Quantity = Convert.ToInt32(reader["itemQTY"]);
            products.Add(product);
        }
        void getMostSold(Label lbl)
        {
            int highest =0;
            string mostSoldName=null;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (highest < Convert.ToInt32(row.Cells["TotalQuantity"].Value))
                {
                    highest = Convert.ToInt32(row.Cells["TotalQuantity"].Value);
                    mostSoldName = row.Cells["Product"].Value.ToString();
                }
                lbl.Text = $"{mostSoldName} which sold {highest} items";
            }
        }
        void getHighestProfit(Label lbl)
        {
            decimal highest = 0;
            string mostSoldName= null;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (highest < Convert.ToDecimal(row.Cells["TotalPrice"].Value))
                {
                    highest = Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                    mostSoldName = row.Cells["Product"].Value.ToString();
                }
            }
            lbl.Text = $"{mostSoldName} which generated {highest}$";
        }
        void getMonthData(Months month, int year)
        {
            table.Clear();
            dataGridView1.DataSource = table;
            bool foundMonth = false;
            try
            {
                connection.Open();
                foreach (string receipt in listOfReceipts)
                {
                    string[] split = receipt.Split('_');
                    int monthValue = (int)month;
                    if (Convert.ToInt16(split[2]) != monthValue || year != Convert.ToInt16(split[1]))
                    {
                        continue;
                    }
                    foundMonth = true;
                    string productsQuery = $"SELECT Name, itemQTY, Price " +
                                            $"FROM {receipt} " +
                                            $"JOIN products ON {receipt}.itemBarcode = products.Barcode ";
                    MySqlCommand productsCommand = new MySqlCommand(productsQuery, connection);
                    using (MySqlDataReader productsReader = productsCommand.ExecuteReader())
                    {

                        while (productsReader.Read())
                        {
                            Product product = new Product();
                            bool productInList = false;
                            int index = 0;
                            foreach (Product item in products)
                            {

                                if (item.Name == productsReader["Name"].ToString())
                                {
                                    productInList = true;
                                }
                                index++;
                            }
                            if (products == null)
                            {
                                fillList(productsReader, product);
                            }

                            else if (!productInList)
                            {
                                fillList(productsReader, product);
                            }
                            else
                            {

                                products[0].Quantity += product.Quantity;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            foreach (Product product in products)
            {
                table.Rows.Add(product.Name, product.Quantity, product.Price * product.Quantity);
            }
            if (!foundMonth)
            {
                MessageBox.Show("Month doesn't exist in database", "Error not found");
            }
            dataGridView1.DataSource = table;
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            try
            {
                Months selectedMonth = (Months)Enum.Parse(typeof(Months), cbxMonth.Text);
                getMonthData(selectedMonth, Convert.ToInt16(cbxYear.Text));
                getMostSold(lblMostSold);
                getHighestProfit(lblHighestPrice);
            }
            catch  (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManagerView frmManagerView = new frmManagerView();
            frmManagerView.Show();
            this.Hide();
        }
        void getBusiestMonth()
        {
            List<int> listOfMonths = new List<int>();
            foreach (var name in listOfReceipts)
            {
                string[] getMonth = name.Split('_');
                Console.WriteLine(Convert.ToInt16(getMonth[2]));
                listOfMonths.Add(Convert.ToInt16(getMonth[2]));
            }
            var mostFrequentMonth = listOfMonths
            .GroupBy(month => month)
            .OrderByDescending(group => group.Count())
            .First()
            .Key;

            lblBusiest.Text= mostFrequentMonth.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }   
}
