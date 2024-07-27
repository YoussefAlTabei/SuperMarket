using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class frmManagerView : Form
    {
        public frmManagerView()
        {
            InitializeComponent();
        }

        private void btnViewStatistics_Click(object sender, EventArgs e)
        {
            frmStatistics frmStatistics = new frmStatistics();
            frmStatistics.Show();
            this.Hide();
        }

        private void btnViewReceipts_Click(object sender, EventArgs e)
        {
            frmViewReceipts frm = new frmViewReceipts();
            frm.Show();
            this.Hide();
        }

        private void btnViewEmp_Click(object sender, EventArgs e)
        {
            frmViewEmployeess frm = new frmViewEmployeess();
            frm.Show();
            this.Hide();
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            frmViewData frm = new frmViewData();
            frm.Show();
            this.Hide();

        }
    }
}
