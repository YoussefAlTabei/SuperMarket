using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class Form1 : Form
    {
        ProductDAL dal = new ProductDAL("server = localhost; database=market;uid=root;password=TabeiyoussEf9;");
        Dictionary<Product, int> product = new Dictionary<Product, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

             product.Add( dal.SearchProductsByName(txtBarcodeSearch.Text),1);

            // Iterate over the list of products and perform operations
            foreach (Product product in products)
            {
                // Perform operations with the product object
               label1.Text += ($"Barcode: {txtBarcodeSearch.Text}, Product Name: {product.Name}, Price: {product.Price}, Quantity: {product.QuantityInStock} \n");
            }
            Console.WriteLine(products.Count());
        }

        private void txtBarcodeSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
