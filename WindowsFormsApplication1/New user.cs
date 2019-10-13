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
using System.Security.Cryptography;


namespace WindowsFormsApplication1
{
    public partial class New_user : Form
    {
        SqlConnection conn;
        public New_user()
        {
            try
            {

                DB_Connection dbObj = new DB_Connection();
                conn = dbObj.getConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Can't Open Connection!! " + ex);
            }
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtcon_password_TextChanged(object sender, EventArgs e)
        {

            if (txtpassword.Text == txtcon_password.Text)
            {
                label7.ForeColor = Color.Yellow;
                label7.Text = "Login";
            }
            else
            {
                label7.ForeColor = Color.White;
                label7.Text = "Wrong Password";
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtusername.Text.Length <= 0)
            {
                errorProvider1.SetError(txtusername, "All fields cannot be empty");
            }
            else if (comboBox1.Text.Length <= 0)
            {
                errorProvider1.SetError(comboBox1, "All fields cannot be empty");
            }
            else if (txtpassword.Text.Length <= 0)
            {
                errorProvider1.SetError(txtpassword, "All fields cannot be empty");
            }
            else if (txtcon_password.Text.Length <= 0)
            {
                errorProvider1.SetError(txtcon_password, "All fields cannot be empty");
            }
            else
            {

                try
                {
                    String password = txtpassword.Text;
                    // byte[] hash = null;

                    using (SHA1 sha1 = SHA1.Create())
                    {
                        // sha1.Initialize();
                        byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < hash.Length; ++i)
                        {
                            sb.Append(hash[i].ToString("x2"));
                        }
                        password = sb.ToString();
                    }

                    conn.Open();

                    String InsertQuery = "INSERT INTO Main_Login VALUES('" + txtusername.Text + "','" + password + "', '" + comboBox1.Text + "')";

                    SqlDataAdapter execute = new SqlDataAdapter(InsertQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from Main_Login", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;

                    txtusername.Text = "";
                    comboBox1.Text = "";
                    txtpassword.Text = "";
                    txtcon_password.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();

            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtcon_password.Text == "")
            {
                MessageBox.Show("Please select a row to Update", " Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    String password = txtpassword.Text;
                    // byte[] hash = null;

                    using (SHA1 sha1 = SHA1.Create())
                    {
                        // sha1.Initialize();
                        byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < hash.Length; ++i)
                        {
                            sb.Append(hash[i].ToString("x2"));
                        }
                        password = sb.ToString();
                    }

                    conn.Close();
                    conn.Open();
                    String UpdateQuery = "Update Main_Login set User_Name='" + txtusername.Text + "', User_Type ='" + comboBox1.Text + "' WHERE Password='" + password + "';";
                    SqlDataAdapter execute = new SqlDataAdapter(UpdateQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from Main_Login", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;

                    txtusername.Text = "";
                    comboBox1.Text = "";
                    txtpassword.Text = "";
                    txtcon_password.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtcon_password.Text == "")
            {
                MessageBox.Show("Please select a row to Delete", " Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Close();
                    conn.Open();
                    String DeleteQuery = "delete from Main_Login where User_Name ='" + txtusername.Text + "';";
                    SqlDataAdapter execute = new SqlDataAdapter(DeleteQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've deleted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from Main_Login", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;

                    txtusername.Text = "";
                    comboBox1.Text = "";
                    txtpassword.Text = "";
                    txtcon_password.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Admin_Menu open = new Admin_Menu();
            open.Show();
            this.Hide();
        }

        private void New_user_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                SqlDataAdapter sda;
                DataTable dt1;
                sda = new SqlDataAdapter("select * FROM Main_Login", conn);
                dt1 = new DataTable();
                sda.Fill(dt1);
                dataGridView1.DataSource = dt1;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            
            txtusername.Text = selectedRow.Cells[0].Value.ToString();
            comboBox1.Text = selectedRow.Cells[2].Value.ToString();
            txtpassword.Text = selectedRow.Cells[1].Value.ToString();
            txtcon_password.Text = selectedRow.Cells[1].Value.ToString();

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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
