using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class DB_Connection
    {
   
        public SqlConnection getConnection()
        {
            SqlConnection conn = null; ;
            try
            {
                conn = new SqlConnection("data source= DESKTOP-LKEG8FM\\SQLEXPRESS;initial catalog= abc_company ; Integrated Security=True;");
             
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Open Connection !" + ex);
            }
            return conn;
        }

    }
}
