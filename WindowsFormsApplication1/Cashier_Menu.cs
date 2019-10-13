using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Cashier_Menu : Form
    {
        public Cashier_Menu()
        {
            InitializeComponent();
        }

        private void Cashier_Menu_Load(object sender, EventArgs e)
        {
            hello.Text = GlobalVariablesClass.VariableOne;
        }

        private void btncreateuser_Click(object sender, EventArgs e)
        {
            View_stock_branches View_stock = new View_stock_branches();
            View_stock.Show();
        }

        private void btnstockdetails_Click(object sender, EventArgs e)
        {
            Customer_details CCD = new Customer_details();
            CCD.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {

            login CCD = new login();
            CCD.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
