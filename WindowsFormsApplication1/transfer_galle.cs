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
    public partial class transfer_galle : Form
    {
        SqlConnection conn;

        private int indexRow;

        public transfer_galle()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlauncheddate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtversion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmodulename_TextChanged(object sender, EventArgs e)
        {

        }

        private void btngalle_Click(object sender, EventArgs e)
        {
            if (!(txtitemno.Text.Equals("")))
            {
                try
                {
                    conn.Close();
                    conn.Open();
                    string search = "SELECT * FROM Galle_branch WHERE Item_No = '" + txtitemno.Text + "'";
                    SqlDataAdapter exe = new SqlDataAdapter(search, conn);
                    SqlDataReader data1 = exe.SelectCommand.ExecuteReader();

                    string ItemNo = null;
                    string BrandName = null;
                    string ModelName = null;
                    string Version = null;
                    string LaunchedDate = null;
                    string Price = null;

                    while (data1.Read())
                    {
                        ItemNo = data1.GetString(0).ToString();
                        BrandName = data1.GetString(1).ToString();
                        ModelName = data1.GetString(2).ToString();
                        Version = data1.GetString(3).ToString();
                        LaunchedDate = data1.GetString(4).ToString();
                        Price = data1.GetString(5).ToString();
                    }
                    data1.Close();
                    conn.Close();

                    if (!(txtitemno.Text.Equals("")))
                    {
                        conn.Open();
                        string insert = "INSERT INTO colombo_branch VALUES('" + ItemNo + "', '" + BrandName + "','" + ModelName + "', '" + Version + "', '" + LaunchedDate + "', '" + Price + "')";
                        SqlDataAdapter func = new SqlDataAdapter(insert, conn);
                        func.SelectCommand.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("You have transfered the data to Colombo Branch Successfully ", "Successfully Transfered", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        conn.Open();
                        SqlCommand deleteCommand = new SqlCommand("delete from Galle_branch where Item_No=@Item_No", conn);
                        deleteCommand.Parameters.Add(new SqlParameter("Item_No", txtitemno.Text.ToString().Trim()));
                        deleteCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                    conn.Close();
                    DisplayData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                }
                conn.Close();
            }
        }

        private void btnkandy_Click(object sender, EventArgs e)
        {
            if (!(txtitemno.Text.Equals("")))
            {
                try
                {
                    conn.Close();
                    conn.Open();
                    string search = "SELECT * FROM Galle_branch WHERE Item_No = '" + txtitemno.Text + "'";
                    SqlDataAdapter exe = new SqlDataAdapter(search, conn);
                    SqlDataReader data1 = exe.SelectCommand.ExecuteReader();

                    string ItemNo = null;
                    string BrandName = null;
                    string ModelName = null;
                    string Version = null;
                    string LaunchedDate = null;
                    string Price = null;

                    while (data1.Read())
                    {
                        ItemNo = data1.GetString(0).ToString();
                        BrandName = data1.GetString(1).ToString();
                        ModelName = data1.GetString(2).ToString();
                        Version = data1.GetString(3).ToString();
                        LaunchedDate = data1.GetString(4).ToString();
                        Price = data1.GetString(5).ToString();
                    }
                    data1.Close();
                    conn.Close();

                    if (!(txtitemno.Text.Equals("")))
                    {
                        conn.Open();
                        string insert = "INSERT INTO Kandy_branch VALUES('" + ItemNo + "', '" + BrandName + "','" + ModelName + "', '" + Version + "', '" + LaunchedDate + "', '" + Price + "')";
                        SqlDataAdapter func = new SqlDataAdapter(insert, conn);
                        func.SelectCommand.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("You have transfered the data to Kandy Branch Successfully ", "Successfully Transfered", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        conn.Open();
                        SqlCommand deleteCommand = new SqlCommand("delete from Galle_branch where Item_No=@Item_No", conn);
                        deleteCommand.Parameters.Add(new SqlParameter("Item_No", txtitemno.Text.ToString().Trim()));
                        deleteCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                    conn.Close();
                    DisplayData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                }
                conn.Close();
            }
        }

        private void DisplayData()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Galle_branch", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void cmbbrandname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            transfer_stocks open = new transfer_stocks();
            open.Show();
            this.Hide();
        }

        private void transfer_galle_Load(object sender, EventArgs e)
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
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            txtitemno.Text = row.Cells[0].Value.ToString();

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Galle_branch where Item_No like ('" + textBox1.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login open = new login();
            open.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            transfer_stocks open = new transfer_stocks();
            open.Show();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
