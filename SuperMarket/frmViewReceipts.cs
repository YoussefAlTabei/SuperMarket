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
namespace SuperMarket
{
    public partial class frmViewReceipts : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        List<string> receiptNames = new List<string>();
        string currenReceipt;
        List<Product> receiptItems = new List<Product>();

        public frmViewReceipts()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            getReceiptsNames(cbxReceiptNames);

        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = Product.connectionString;
            connection = new MySqlConnection(connectionString);
        }
        private void LoadDataIntoDataGridView(string receipt)
        {
            try
            {
                connection.Open();
                string query = "SELECT Name,Barcode,itemQTY, Price ,(itemQTY * Price) AS Total" +
                               $" FROM {receipt}" +
                               $" JOIN products ON {receipt}.itemBarcode = products.Barcode;";

                command = new MySqlCommand(query, connection);
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                refreshTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        void getReceiptsNames(ComboBox cbx)
        {
            try
            {
                connection.Open();
                string query = "SELECT receiptName FROM receipts";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object value = reader["receiptName"];
                    receiptNames.Add(value.ToString());
                }

                reader.Close();
                cbx.Items.Clear();
                foreach (string item in receiptNames)
                {
                    cbx.Items.Add(item);
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
        }
        void refreshTable()
        {
            try
            {
                if (dataTable != null)
                {
                    dataTable.Clear();
                }
                if (adapter == null)
                {
                    throw new ArgumentNullException("No receipt selected");
                }
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                cbxRefund.Items.Clear();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Product product = new Product();
                    if (row != null && row.Cells["Name"].Value != null)
                    {
                        //Create a list<Products>
                        product.Name = row.Cells["Name"].Value.ToString();
                        product.Barcode = row.Cells["Barcode"].Value.ToString();
                        product.Quantity = Convert.ToInt16(row.Cells["ItemQTY"].Value);
                        receiptItems.Add(product);
                        cbxRefund.Items.Add(row.Cells["Name"].Value.ToString());
                    }
                }
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxReceiptNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnShowReceipt_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView(cbxReceiptNames.Text);
            currenReceipt = cbxReceiptNames.Text;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManagerView frmManagerView = new frmManagerView();
            frmManagerView.Show();
            this.Hide();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            Product product = getProduct(cbxRefund.Text); 
            deleteItem(product);
            refundToStock(product);
            refreshTable();

        }
        Product getProduct(string name)
        {
            foreach (Product item in receiptItems) 
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            
                return null;
            
        }
        void deleteItem(Product prd)
        {
            using (MySqlConnection connection = new MySqlConnection(Product.connectionString))
            {
                try
                {
                    connection.Open();
                    if (prd == null)
                    {
                        throw new ArgumentNullException("You must select an item to refund");
                    }
                    string query = $"DELETE FROM {currenReceipt} WHERE itemBarcode = {prd.Barcode}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                refreshTable();
            }
        }
        void refundToStock(Product product)
        {
            try
            {
                ProductDAL dal = new ProductDAL(Product.connectionString);
                if (dal == null || product == null)
                {
                    throw new ArgumentNullException("dal, product is null");
                }
                dal.updateQuantity(product, product.Quantity);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Product.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"Drop table {cbxReceiptNames.Text};";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: wtf" + ex.Message);
                }
            }
        }
    }
}
