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
    public partial class login : Form
    {
        SqlConnection conn;
        public login()
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

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtusername.Text.Length <= 0)
            {
                errorProvider1.SetError(txtusername, "This field cannot be empty");
            }
            else if (txtusername.Text.Length <= 0)
            {
                errorProvider1.SetError(txtusername, "This field cannot be empty");
            }
            else if (txtpassword.Text.Length <= 0)
            {
                errorProvider1.SetError(txtpassword, "This field cannot be empty");
            }
            else
            {

                try
                {
                    SqlCommand selectCommand = new SqlCommand(" Select * from Main_Login where User_Name=@UserId and Password=@PASS", conn);
                    selectCommand.Parameters.Add(new SqlParameter("UserId", txtusername.Text.ToString()));
                    String password = "";

                    using (SHA1 sha1 = SHA1.Create())
                    {
                        //sha1.Initialize();
                        byte[] data = sha1.ComputeHash(Encoding.UTF8.GetBytes(txtpassword.Text));

                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < data.Length; ++i)
                        {
                            sb.Append(data[i].ToString("x2"));
                        }

                        password = sb.ToString();
                    }

                    selectCommand.Parameters.Add(new SqlParameter("PASS", password));

                    string UserType = null;
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    bool rowfound = reader.HasRows;
                    if (rowfound)
                    {
                        while (reader.Read())
                        {
                            UserType = reader[2].ToString().Trim();

                            if (UserType == "Administrator")
                            {
                                GlobalVariablesClass.VariableOne = txtusername.Text;
                                MessageBox.Show("Welcome ", "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Admin_Menu frm = new Admin_Menu();
                                frm.Show();

                                this.Hide();
                            }
                          
                            else if (UserType == "Stock Controller")
                            {
                                GlobalVariablesClass.VariableOne = txtusername.Text;
                                MessageBox.Show("Welcome ", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                StockController_Menu frm = new StockController_Menu();
                                frm.Show();
                                this.Hide();
                            }
                            else if (UserType == "Cashier")
                            {
                                GlobalVariablesClass.VariableOne = txtusername.Text;
                                MessageBox.Show("Welcome ", "Cashier Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cashier_Menu frm = new Cashier_Menu();
                                frm.Show();
                                this.Hide();
                            }
                          
                        }

                    }

                    else
                    {
                        MessageBox.Show(" Invalid User Or Password ", "Login ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("error login " + ex);
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
