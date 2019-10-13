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
    public partial class kandy_branch : Form
    {
        SqlConnection conn;

        private int indexRow;
        public kandy_branch()
        {
            try
            {
                DB_Connection dbobj = new DB_Connection();
                conn = dbobj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant open connection !!" + ex);
            }
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            if (txtitemno.Text.Length <= 0)
            {
                errorProvider1.SetError(txtitemno, "This field cannot be empty");
            }
            else if (cmbbrandname.Text.Length <= 0)
            {
                errorProvider1.SetError(cmbbrandname, "This field cannot be empty");
            }
            else if (txtmodelname.Text.Length <= 0)
            {
                errorProvider1.SetError(txtmodelname, "This field cannot be empty");
            }
            else if (txtversion.Text.Length <= 0)
            {
                errorProvider1.SetError(txtversion, "This field cannot be empty");
            }
            else if (this.dateTimePicker1.Text.Length <= 0)
            {
                errorProvider1.SetError(this.dateTimePicker1, "This field cannot be empty");
            }
            else if (txtprice.Text.Length <= 0)
            {
                errorProvider1.SetError(txtprice, "This field cannot be empty");
            }
            else
            {

                try
                {
                    conn.Close();
                    conn.Open();
                    String InsertQuery = "INSERT INTO Kandy_branch VALUES('" + txtitemno.Text + "','" + cmbbrandname.Text + "', '" + txtmodelname.Text + "','" + txtversion.Text + "', '" + this.dateTimePicker1.Text + "', '" + txtprice.Text + "')";
                    SqlDataAdapter execute = new SqlDataAdapter(InsertQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from Kandy_branch", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtitemno.Text = "";
                cmbbrandname.Text = "";
                txtmodelname.Text = "";
                txtversion.Text = "";
                this.dateTimePicker1.Text = "";
                txtprice.Text = "";
                conn.Close();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtprice.Text.Length <= 0)
            {
                MessageBox.Show("Select a Record to Update", "New User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    conn.Close();
                    conn.Open();
                    String UpdateQuery = "Update Kandy_branch set Brand_Name='" + cmbbrandname.Text + "',Model_Name='" + txtmodelname.Text + "', Version= '" + txtversion.Text + "', Launched_date='" + this.dateTimePicker1.Text + "', Price='" + txtprice.Text + "' where Item_No ='" + txtitemno.Text + "';";
                    SqlDataAdapter execute = new SqlDataAdapter(UpdateQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from Kandy_branch", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtitemno.Text = "";
                cmbbrandname.Text = "";
                txtmodelname.Text = "";
                txtversion.Text = "";
                this.dateTimePicker1.Text = "";
                txtprice.Text = "";
                conn.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                String DeleteQuery = "delete from Kandy_branch where Item_No ='" + txtitemno.Text + "';";
                SqlDataAdapter execute = new SqlDataAdapter(DeleteQuery, conn);
                execute.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("You've deleted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();

                SqlDataAdapter data = new SqlDataAdapter("Select * from Kandy_branch", conn);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtitemno.Text = "";
            cmbbrandname.Text = "";
            txtmodelname.Text = "";
            txtversion.Text = "";
            this.dateTimePicker1.Text = "";
            txtprice.Text = "";
            conn.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
            txtitemno.Text = "";
            cmbbrandname.Text = "";
            txtmodelname.Text = "";
            txtversion.Text = "";
            this.dateTimePicker1.Text = "";
            txtprice.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void kandy_branch_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                SqlDataAdapter sda;
                DataTable dt1;
                sda = new SqlDataAdapter("select * FROM Kandy_branch ORDER BY Item_No DESC", conn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Kandy_branch where Item_No like ('" + txtsearch.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            txtitemno.Text = row.Cells[0].Value.ToString();
            cmbbrandname.Text = row.Cells[1].Value.ToString();
            txtmodelname.Text = row.Cells[2].Value.ToString();
            txtversion.Text = row.Cells[3].Value.ToString();
            dateTimePicker1.Text = row.Cells[4].Value.ToString();
            txtprice.Text = row.Cells[5].Value.ToString();

            /* int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

            txtitemno.Text = selectedRow.Cells[0].ToString();
            cmbbrandname.Text = selectedRow.Cells[1].Value.ToString();
            txtmodelname.Text = selectedRow.Cells[2].Value.ToString();
            txtversion.Text = selectedRow.Cells[3].Value.ToString();
            this.dateTimePicker1.Text = selectedRow.Cells[4].Value.ToString();
            txtprice.Text = selectedRow.Cells[5].Value.ToString();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
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
