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
    public partial class galle_branch : Form
    {
        SqlConnection conn;
        public galle_branch()
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
                    String UpdateQuery = "Update Galle_branch set Brand_Name='" + cmbbrandname.Text + "',Model_Name='" + txtmodelname.Text + "', Version= '" + txtversion.Text + "', Launched_date='" + this.dateTimePicker1.Text + "', Price='" + txtprice.Text + "' where Item_No ='" + txtitemno.Text + "';";
                    SqlDataAdapter execute = new SqlDataAdapter(UpdateQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from Galle_branch", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;
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
            try
            {
                conn.Close();
                conn.Open();
                String DeleteQuery = "delete from Galle_branch where Model_Name ='" + txtmodelname.Text + "';";
                SqlDataAdapter execute = new SqlDataAdapter(DeleteQuery, conn);
                execute.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("You've deleted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();

                SqlDataAdapter data = new SqlDataAdapter("Select * from Galle_branch", conn);
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
                    String InsertQuery = "INSERT INTO Galle_branch VALUES('" + txtitemno.Text + "','" + cmbbrandname.Text + "', '" + txtmodelname.Text + "','" + txtversion.Text + "', '" + this.dateTimePicker1.Text + "', '" + txtprice.Text + "')";
                    SqlDataAdapter execute = new SqlDataAdapter(InsertQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from Galle_branch", conn);
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

        private void label8_Click(object sender, EventArgs e)
        {
            txtitemno.Text = "";
            cmbbrandname.Text = "";
            txtmodelname.Text = "";
            txtversion.Text = "";
            this.dateTimePicker1.Text = "";
            txtprice.Text = "";
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            conn.Close();
            try
            {
                conn.Open();
                SqlCommand selectCommand = new SqlCommand("Select * from Galle_branch where Item_No = @Item_no", conn);
                selectCommand.Parameters.Add(new SqlParameter("Item_no", txtsearch.Text.ToString()));
                SqlDataReader reader = selectCommand.ExecuteReader();
                bool rowFound = reader.HasRows;

                if (rowFound)
                {
                    while (reader.Read())
                    {
                        txtitemno.Text = reader.GetString(0).ToString();
                        cmbbrandname.Text = reader.GetString(1).ToString();
                        txtmodelname.Text = reader.GetString(2).ToString();
                        txtversion.Text = reader.GetString(3).ToString();
                        
                        this.dateTimePicker1.Text = reader.GetDateTime(4).ToString();
                        txtprice.Text = reader.GetString(5).ToString();
                        reader.Close();




                        SqlDataAdapter data = new SqlDataAdapter("Select * from Galle_branch", conn);
                        DataTable dt = new DataTable();
                        data.Fill(dt);
                        dataGridView1.DataSource = dt;

                        /* SqlDataAdapter sda;
                         DataTable dt1;
                         sda = new SqlDataAdapter("select * FROM colombo_branch ",conn);
                         dt1 = new DataTable();
                         sda.Fill(dt1);
                         dataGridView.DataSource = dt1;*/
                        MessageBox.Show("Search Found", "Form", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    
                }


                else
                {
                    MessageBox.Show("User Not Found", "Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                reader.Close();
                reader.Close();
                conn.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            branches open = new branches();
            open.Show();
            this.Hide();
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void galle_branch_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                SqlDataAdapter sda;
                DataTable dt1;
                sda = new SqlDataAdapter("select * FROM Galle_branch", conn);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            txtitemno.Text = selectedRow.Cells[0].Value.ToString();
            cmbbrandname.Text = selectedRow.Cells[1].Value.ToString();
            txtmodelname.Text = selectedRow.Cells[2].Value.ToString();
            txtversion.Text = selectedRow.Cells[3].Value.ToString();
            this.dateTimePicker1.Text = selectedRow.Cells[4].Value.ToString();
            txtprice.Text = selectedRow.Cells[5].Value.ToString();
        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Galle_branch where Item_No like ('" + txtsearch.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
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
