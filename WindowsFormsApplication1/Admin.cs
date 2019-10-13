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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            login open = new login();
            open.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login open = new login();
            open.Show();
            this.Hide();
        }

        private void btncreateuser_Click(object sender, EventArgs e)
        {
            New_user open = new New_user();
            open.Show();
            
        }

        private void btnstockdetails_Click(object sender, EventArgs e)
        {
            branches open = new branches();
            open.Show();
            
        }

        private void btnsalesdetails_Click(object sender, EventArgs e)
        {
            
        }

        private void btntransfer_Click(object sender, EventArgs e)
        {
            transfer_stocks open = new transfer_stocks();
            open.Show();
            
        }

        private void btncustomerdetails_Click(object sender, EventArgs e)
        {
            Customer_details open = new Customer_details();
            open.Show();
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            hello.Text = GlobalVariablesClass.VariableOne;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
