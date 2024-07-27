using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperMarket
{
    public partial class frmViewData : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        static string connectionString = Product.connectionString;
         List<List<Object>> editedCells = new List<List<Object>>();
        Dictionary<string, double> nameBarcodeDict = new Dictionary<string, double>();
        ProductDAL dal = new ProductDAL(connectionString);
        public frmViewData()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadDataIntoDataGridView();
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

        private void frmViewData_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM Products";
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
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (rowIndex >= 0 && columnIndex >= 0)
            {
                DataGridViewCell editedCell = dataGridView1.Rows[rowIndex].Cells[columnIndex];
                object editedValue = editedCell.Value;
                Console.WriteLine(editedCell.Value);
                Console.WriteLine(dataGridView1.Columns[editedCell.ColumnIndex].Name);
                Console.WriteLine(dataGridView1.Rows[rowIndex].Cells[2].Value);
                List<Object> cell = new List<Object>();
                cell.Add(editedCell.Value);
                cell.Add(dataGridView1.Columns[editedCell.ColumnIndex].Name);
                cell.Add(dataGridView1.Rows[rowIndex].Cells[2].Value);
                editedCells.Add(cell);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                foreach (List<Object> list in editedCells)
                {
                    string updateQuery;
                    updateQuery = $"UPDATE products SET {list[1]} = '{list[0]}' WHERE Barcode = {list[2]}";
                    Console.WriteLine(updateQuery);
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.ExecuteNonQuery();
                    
                }
                MessageBox.Show("Database updated successfully");
            }
            catch  (System.Collections.Generic.KeyNotFoundException)
            {
                MessageBox.Show("Item doesn't exist");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating database: " + ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                editedCells.Clear();
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            addItem item = new addItem(txtBarcode, txtCategory, txtName, txtPrice, txtQuantity);
            item.insertItem();
            refreshTable();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM Products WHERE Barcode = {nameBarcodeDict[cbxItemToRemove.Text]};";
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting data: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            refreshTable();
        }
        void refreshTable()
        {
            if (dataTable != null)
            {
                dataTable.Clear();
            }
            
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            nameBarcodeDict.Clear();
            cbxItemToRemove.Items.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Name"].Value != null && row.Cells["Barcode"].Value != null)
                {
                    string name = row.Cells["Name"].Value.ToString();
                    double barcode = Convert.ToDouble(row.Cells["Barcode"].Value);

                    cbxItemToRemove.Items.Add(name); // Add name to combo box

                    // Add to dictionary
                    if (!nameBarcodeDict.ContainsKey(name))
                    {
                        nameBarcodeDict.Add(name, barcode);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManagerView frmManagerView = new frmManagerView();
            frmManagerView.Show();
            this.Hide();
        }
    }
}

