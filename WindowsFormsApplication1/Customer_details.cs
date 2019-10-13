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
    public partial class Customer_details : Form
    {
        SqlConnection conn;
        private int indexRow;
        public Customer_details()
        {
            try
            {
                DB_Connection dbobj = new DB_Connection();
                conn = dbobj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant open connection !! " + ex);
            }
            InitializeComponent();
        }

        private void btnaddd_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtcustomername.Text.Length <= 0)
            {
                MessageBox.Show("Select a Record to Update", "New User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Close();
                    conn.Open();
                    String UpdateQuery = "Update Customer_Details set Customer_name='" + txtcustomername.Text + "', Address= '" + txtaddress.Text + "', NIC='" + txtnicno.Text + "',Email='" + txtemail.Text + "',Contact_no='" + txtcontactno.Text + "',  Create_Date='" + label11.Text + "' where Invoice_no ='" + txtinvoiceno.Text + "';";
                    SqlDataAdapter execute = new SqlDataAdapter(UpdateQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from Customer_Details ORDER BY Invoice_No DESC", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtinvoiceno.Text = "";
                txtcustomername.Text = "";
                txtaddress.Text = "";
               // label11.Text = "";
                txtnicno.Text = "";
                txtemail.Text = "";
                txtcontactno.Text = "";
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
          
        }

        private void Customer_details_Load(object sender, EventArgs e)
        {

            DateTime dateTime = DateTime.Now;
            label11.Text = dateTime.ToString();


            SqlDataAdapter data = new SqlDataAdapter("Select * from Customer_Details ORDER BY Invoice_No DESC", conn);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                String DeleteQuery = "delete from Customer_Details where Invoice_no ='" + txtinvoiceno.Text + "';";
                SqlDataAdapter execute = new SqlDataAdapter(DeleteQuery, conn);
                execute.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("You've deleted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();

                SqlDataAdapter data = new SqlDataAdapter("Select * from Customer_Details", conn);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtinvoiceno.Text = "";
            txtcustomername.Text = "";
            txtaddress.Text = "";
            
            txtnicno.Text = "";
            txtemail.Text = "";
            txtcontactno.Text = "";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Menu open = new Admin_Menu();
            open.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
            {

            }

            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            txtinvoiceno.Text = row.Cells[0].Value.ToString();
            txtcustomername.Text = row.Cells[1].Value.ToString();
            txtaddress.Text = row.Cells[2].Value.ToString();
            txtnicno.Text = row.Cells[3].Value.ToString();
            txtemail.Text = row.Cells[4].Value.ToString();
            txtcontactno.Text = row.Cells[5].Value.ToString();
          //  label11.Text = row.Cells[6].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_INSERT_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtcustomername.Text.Length <= 0)
            {
                errorProvider1.SetError(txtcustomername, "CustomerName Cannot be empty");
            }
            if (txtinvoiceno.Text.Length <= 0)
            {
                errorProvider1.SetError(txtinvoiceno, "Invoice Number Cannot be empty");
            }
            else
            {
                try
                {
                    conn.Close();
                    conn.Open();
                    
                    String UpdateQuery = "INSERT Customer_Details VALUES('" + txtinvoiceno.Text + "', '" + txtcustomername.Text + "', '" + txtaddress.Text + "', '" + txtnicno.Text + "', '" + txtemail.Text + "', '" + txtcontactno.Text + "', '" + label11.Text + "')";
                    SqlDataAdapter execute = new SqlDataAdapter(UpdateQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from Customer_Details", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtinvoiceno.Text = "";
                txtcustomername.Text = "";
                txtaddress.Text = "";
               // label11.Text = "";
                txtnicno.Text = "";
                txtemail.Text = "";
                txtcontactno.Text = "";
                conn.Close();
            }
        }
    }
}
