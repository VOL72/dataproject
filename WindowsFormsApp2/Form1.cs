using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string manager_id,pwd;
            manager_id = textBox1.Text;
            pwd = textBox2.Text;


            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            string str = "select * from manager where manager_id = '" + manager_id + "';";
            MySqlCommand cmd = new MySqlCommand(str, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if(pwd != reader.GetString("password"))
                {
                    MessageBox.Show("密码错误");
                }
                else
                {

                    MessageBox.Show("登陆成功");
                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.Show();
                } 
            }
            else
            {
                MessageBox.Show("用户不存在");
            }
            reader.Close();
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register register = new register();
            register.Show();
        }

        
    }
}
