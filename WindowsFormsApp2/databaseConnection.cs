using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApp2
{
    class databaseConnection
    {
        private String connetStr = "server=127.0.0.1;port=3306;user=root;password=a724352105;database=bookmanager;";

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connetStr);
                conn.Open();
                return conn;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
