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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SuperMarket
{
    public partial class frmViewEmployeess : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        List<List<Object>> editedCells = new List<List<Object>>();
        public frmViewEmployeess()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadDataIntoDataGridView();
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;

        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = Product.connectionString;
            connection = new MySqlConnection(connectionString);
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM employees";
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void refreshTable()
        {
            if (dataTable != null)
            {
                dataTable.Clear();
            }

            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            cbxItemToRemove.Items.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Name"].Value != null && row.Cells["idEmployees"].Value != null)
                {
                    string name = row.Cells["Name"].Value.ToString();
                    double idEmployee = Convert.ToDouble(row.Cells["idEmployees"].Value);

                    cbxItemToRemove.Items.Add(idEmployee+": "+name); // Add name to combo box
                }
            }
        }
         void insertItem(string name, string password, string role,decimal salary)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO employees (Name,Password,Role,Salary) VALUES ('{name}', '{password}','{role}',{salary});";
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
                Console.WriteLine(dataGridView1.Rows[rowIndex].Cells[0].Value);
                List<Object> cell = new List<Object>();
                cell.Add(editedCell.Value);
                cell.Add(dataGridView1.Columns[editedCell.ColumnIndex].Name);
                cell.Add(dataGridView1.Rows[rowIndex].Cells[0].Value);
                
                editedCells.Add(cell);

            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                foreach (List<Object> list in editedCells)
                {
                    string updateQuery;
                    updateQuery = $"UPDATE employees SET {list[1]} = '{list[0]}' WHERE idEmployees = {list[2]}";
                    Console.WriteLine(updateQuery);
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.ExecuteNonQuery();
                    MessageBox.Show("Database updated successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating database: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                editedCells.Clear();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to permanantly Remove this Employee", "Remove employee",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            {
                removeEmp();
            }
        }
        private void removeEmp()
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM employees WHERE idEmployees = {cbxItemToRemove.Text.First()};";
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

        private void frmViewEmployeess_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                insertItem(txtName.Text, txtPw.Text, cbxRole.Text, Convert.ToDecimal(txtSalary.Text));
                refreshTable();
            }
            catch (FormatException)
            {
                MessageBox.Show("Fields can't be empty or have the wrong format");
            }
            catch (Exception ex)
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
    }
}
