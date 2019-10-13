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
    public partial class transfer_stocks : Form
    {
        public transfer_stocks()
        {
            InitializeComponent();
        }

        private void btntransferdetails_Click(object sender, EventArgs e)
        {
            transfer_colombo open = new transfer_colombo();
            open.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transfer_kandy open = new transfer_kandy();
            open.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            transfer_galle open = new transfer_galle();
            open.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login open = new login();
            open.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
