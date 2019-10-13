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
    public partial class View_stock_branches : Form
    {
        public View_stock_branches()
        {
            InitializeComponent();
        }

        private void btnstockcolombo_Click(object sender, EventArgs e)
        {
            View_colombo open = new View_colombo();
            open.Show();
            
        }

        private void btnstockkandy_Click(object sender, EventArgs e)
        {
            View_kandy open = new View_kandy();
            open.Show();
        }

        private void btnstockgalle_Click(object sender, EventArgs e)
        {
            View_galle open = new View_galle();
            open.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login open = new login();
            open.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            
        }

        private void View_stock_branches_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         //   this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
       
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
