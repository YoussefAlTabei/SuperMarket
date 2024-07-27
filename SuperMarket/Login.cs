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

    public partial class Login : Form
    {

        string connectionString = Product.connectionString;
        List<Employee> employees = new List<Employee>();
        public static string currentEmployee;
        public Login()
        {
            InitializeComponent();
            getNamesAndPw();
            Console.Write(Product.connectionString);
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool loginSucc = false;
            foreach (Employee employee in employees)
            {
                if (employee.Name == txtName.Text && employee.Password == txtPassword.Text) 
                {
                    if (employee.Role == "manager")
                    {
                        frmManagerView frmManagerView = new frmManagerView();
                        frmManagerView.Show();
                        this.Hide();
                    }
                    else
                    {
                        currentEmployee = employee.Name;
                        frmCashier form1 = new frmCashier();
                        form1.Show();
                        this.Hide();
                    }
                    loginSucc = true;
                }
            }
            if (!loginSucc ) 
            {
                MessageBox.Show("Incorrect Name or Password");
            }

        }
        void getNamesAndPw()
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "select * from employees";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                Name = reader["Name"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                            employees.Add(employee);
                        }
                    }
                }
            }
        }
    }
}
