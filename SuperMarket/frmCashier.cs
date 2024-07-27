using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SuperMarket
{
    public partial class frmCashier : Form
    {
        static string connectionString = Product.connectionString;
        private MySqlConnection connection;
        private MySqlCommand command;
        ProductDAL dal = new ProductDAL(connectionString);
        List<Product> products = new List<Product>();
        bool productFound= false;
        Decimal receiptTotal;
        DateTime currentTime = DateTime.Now;
        string underscoreString = new string('_', 50);
        Dictionary<string,int> storeReceipt = new Dictionary<string,int>();
        public string tableName;
        decimal PaidAmount;
        decimal Change;
        public frmCashier()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            lblWelcome.Text = "Welcome " + Login.currentEmployee;
        }

        private void txtBarcodeSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Simulate a button click
                btnAdd.PerformClick();
                // Optionally, you can prevent the Enter key from producing a beep sound
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBarcodeSearch.Text))
                {
                    throw new Exception("Barcode cannot be empty.");
                }
                receitContent(products, txtBarcodeSearch.Text, lblReceit, lblTotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtBarcodeSearch.Clear();
        }
        private void btnReciet_Click(object sender, EventArgs e)
        {
            if (Change < 0)
            {
                MessageBox.Show("Error amount paid is less than the total",
                    "Error not enough paid");
            }
            else
            {
                storeReceipt.Clear();
                foreach (Product product in products)
                {
                    dal.updateQuantity(product, product.Quantity);
                    storeReceipt[product.Barcode] = product.Quantity;
                }
                string receiptContent = lblReceit.Text + "\n" + underscoreString;
                receiptContent += $"\nTotal:         {receiptTotal}";
                if (PaidAmount != 0)
                {
                    receiptContent += $"\n Paid amount = {PaidAmount}\n Change = {Change}";
                }
                using (StreamWriter writer = new StreamWriter(@"C:\MyFolder\Programming\receipt.txt"))
                {
                    writer.Write(receiptContent);
                }
                createReceiptTable(storeReceipt);
                frmCashier form = new frmCashier();
                form.Show();
                this.Hide();
            }
        }
        void receitContent(List<Product> products, string barcode, Label label1, Label label2)
        {
            try { 
           

            receiptTotal = 0;

            foreach (Product entry in products)
            {
                if (entry.Barcode == barcode)
                {
                    entry.Quantity += 1;
                    productFound = true;
                    entry.total = entry.Price * entry.Quantity;
                    break;
                }
            }
            if (!productFound && barcode !="")
            {
                Product item = dal.SearchProductsByBarcode(barcode);
                products.Add(item);
                item.total = item.Price * item.Quantity;
                if (barcode != "")
                {
                                     
                    cbxItemToRemove.Items.Add(item.Name);
                }
            }

            productFound = false;
                label1.Text = $"Cash Receit\nSuperMarket\n{Login.currentEmployee}\n"
                + currentTime.ToString("yyyy-MM-dd HH:mm") + "\n" + underscoreString
                + "\nQTY       Item         Price        Total \n";
                foreach (Product entry in products)
            {
                label1.Text += $"{entry.Quantity,-9} {entry.Name,-12}" +
                    $" {entry.Price,-14:C} {entry.total,-14:C}\n";
                label1.Text = label1.Text.Replace("XDR", "");
                receiptTotal = receiptTotal += entry.total;
                label2.Text = "\n" + underscoreString + $"\nTotal: {receiptTotal}";
                if (PaidAmount != 0)
                {
                        Change = PaidAmount - receiptTotal;
                        label2.Text += $"\n Paid amount = {PaidAmount}\n Change = {Change}";
                }

            }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Wrong barcode or {e}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnRemoveLast_Click(object sender, EventArgs e)
        {
            cbxItemToRemove.Items.Remove(products.ElementAt(products.Count - 1).Name);
            products.RemoveAt(products.Count - 1);
            receitContent(products,"", lblReceit, lblTotal);
            
        }

        private void cbxItemToRemove_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Product productToRemove = products.Find(p => p.Name == cbxItemToRemove.Text);
            if (productToRemove != null)
            {
                cbxItemToRemove.Items.Remove(productToRemove.Name);
                products.Remove(productToRemove);
            }
            receitContent(products, "", lblReceit, lblTotal);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        void createReceiptTable(Dictionary<string,int> dict)
        {
            currentTime = DateTime.Now;
            connection = new MySqlConnection(connectionString);
            connection.Open();
            tableName = "receipt_" + currentTime.ToString("yyyy_MM_dd_HH_mm_ss");
            string createTableQuery = $"CREATE TABLE `{tableName}` (id INT AUTO_INCREMENT PRIMARY KEY, " +
             "itemBarcode VARCHAR(255), itemQTY INT(3), date varchar(255), " + // Add the date column definition
            "FOREIGN KEY (date) REFERENCES receipts(date))";

            using (MySqlCommand command = new MySqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine($"Table {tableName} created successfully!");
            }
            InsertReceiptIntoReceipts(currentTime.ToString("yyyy-MM-dd HH:mm"), tableName);
            try
            {
                Console.WriteLine(tableName);
                foreach (var item in dict)
                {
                    string query = $"INSERT INTO {tableName} " +
                        $"(itemBarcode, itemQTY, date) " + // Add 'date' column to the column list
                        $"VALUES ('{item.Key}', {item.Value}, '{currentTime.ToString("yyyy-MM-dd HH:mm")}')";
                    Console.WriteLine(query);
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Inserting data: " + ex.Message);
            }
            connection.Close();
        }
        public void InsertReceiptIntoReceipts(string date,string tablename)
        {
            string insertQuery = $"INSERT INTO receipts (receiptName,date) VALUES ('{tablename}','{date}')";
            MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
            insertCommand.ExecuteNonQuery();
        }
            private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPaidAmount.Text != null && txtPaidAmount.Text != "")
                {
                    if (Convert.ToDecimal(txtPaidAmount.Text).GetType() == typeof(decimal))
                    {
                        PaidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                        

                        receitContent(products, "", lblReceit, lblTotal);
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Paid amount can only be numbers");
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtModifyQt_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToInt16(txtModifyQt.Text) <= 0)
                {
                    throw new Exception("Quantity can't be Zero");
                }
                if (txtModifyQt.Text != null && txtModifyQt.Text != "")
                {
                    if (Convert.ToInt16(txtModifyQt.Text).GetType() == typeof(Int16))
                    {
                        products.ElementAt(products.Count - 1).Quantity = Convert.ToInt16(txtModifyQt.Text);

                        receitContent(products, "", lblReceit, lblTotal);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Quanity can only be numbers above 0");
            }
        }
    }
}
