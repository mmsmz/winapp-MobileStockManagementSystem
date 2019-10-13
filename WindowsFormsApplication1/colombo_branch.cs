﻿using System;
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
    public partial class colombo_branch : Form
    {
        SqlConnection conn;
        private int indexRow;

        public colombo_branch()
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
                    String InsertQuery = "INSERT INTO colombo_branch VALUES('" + txtitemno.Text + "','" + cmbbrandname.Text + "', '" + txtmodelname.Text + "','" + txtversion.Text + "', '" + this.dateTimePicker1.Text + "', '" + txtprice.Text + "')";
                    SqlDataAdapter execute = new SqlDataAdapter(InsertQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from colombo_branch", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView.DataSource = dt;
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

        private void colombo_branch_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                SqlDataAdapter sda;
                DataTable dt1;
                sda = new SqlDataAdapter("select * FROM colombo_branch ORDER BY Item_No DESC", conn);
                dt1 = new DataTable();
                sda.Fill(dt1);
                dataGridView.DataSource = dt1;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    String UpdateQuery = "Update colombo_branch set Brand_Name='" + cmbbrandname.Text + "',Model_Name='" + txtmodelname.Text + "', Version= '" + txtversion.Text + "', Launched_date='" + this.dateTimePicker1.Text + "', Price='" + txtprice.Text + "' where Item_No ='" + txtitemno.Text + "';";
                    SqlDataAdapter execute = new SqlDataAdapter(UpdateQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from colombo_branch", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView.DataSource = dt;
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
            if (txtitemno.Text.Length <= 0)
            {
                MessageBox.Show("Select a Record to Delete", "New User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    conn.Close();
                    conn.Open();
                    String DeleteQuery = "delete from colombo_branch where Item_No ='" + txtitemno.Text + "';";
                    SqlDataAdapter execute = new SqlDataAdapter(DeleteQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've deleted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select * from colombo_branch", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtitemno.Text = "";
                cmbbrandname.Text = "";
                txtmodelname.Text = "";
                txtversion.Text = "";
                this.dateTimePicker1.Text = null;
                txtprice.Text = "";
                conn.Close();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
          
        }

      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            cmbbrandname.Text = "";
            txtmodelname.Text = "";
            txtversion.Text = "";
            this.dateTimePicker1.Text = "";
            txtprice.Text = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {
            txtitemno.Text = "";
            cmbbrandname.Text= "";
            txtmodelname.Text = "";
            txtversion.Text = "";
            this.dateTimePicker1.Text = "";
            txtprice.Text = "";
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*DataView dv = new DataView();
            dv.RowFilter = string.Format("Model_Name like '%{0}%'", txtsearch.Text);
            dataGridView.DataSource = dv;*/



        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            branches open = new branches();
            open.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Colombo_branch where Item_No like ('" + txtsearch.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView.DataSource = dt;
            conn.Close();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView.Rows[indexRow];

            txtitemno.Text = row.Cells[0].Value.ToString();
            cmbbrandname.Text = row.Cells[1].Value.ToString();
            txtmodelname.Text = row.Cells[2].Value.ToString();
            txtversion.Text = row.Cells[3].Value.ToString();
            dateTimePicker1.Text = row.Cells[4].Value.ToString();
            txtprice.Text = row.Cells[5].Value.ToString();

        }

        private void txtitemno_TextChanged(object sender, EventArgs e)
        {
            
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
