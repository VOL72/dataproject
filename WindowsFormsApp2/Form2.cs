using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            login login = new login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, pwd1,pwd2;

            username = textBox1.Text.ToString();
            pwd1 = textBox2.Text.ToString();
            pwd2 = textBox3.Text.ToString();
            if(username != null) { 
                if(pwd1 == pwd2 && pwd1 != null)
                {
                    databaseConnection db = new databaseConnection();
                    MySqlConnection conn = db.GetConnection();
                    string sql = "INSERT INTO manager (manager_id,password,power) VALUES ('" + username + "','" + pwd1 + "','"+"销售人员'"+");";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int result = cmd.ExecuteNonQuery();
                    if(result == 1)
                    {
                        MessageBox.Show("注册成功");
                    }
                    else
                    {
                        MessageBox.Show("注册失败");
                    }
                    conn.Close();
                }
            }
        }
    }
}
