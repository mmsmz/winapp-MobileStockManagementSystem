using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class branches : Form
    {
      //  SqlConnection conn;
        public branches()
        {
            InitializeComponent();
        }

        private void btnclmbo_Click(object sender, EventArgs e)
        {
            colombo_branch open = new colombo_branch();
            open.Show();
            
        }

        private void btnkandy_Click(object sender, EventArgs e)
        {
            kandy_branch open = new kandy_branch();
            open.Show();
            
        }

        private void btngalle_Click(object sender, EventArgs e)
        {
            galle_branch open = new galle_branch();
            open.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
