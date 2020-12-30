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
    public partial class changepwd : Form
    {
        public changepwd()
        {
            InitializeComponent();
        }
        //修改密码
        private void button1_Click(object sender, EventArgs e)
        {
            login login = new login();
            string manager_id = login.managerId;
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            string str = "select * from manager where manager_id = '" + manager_id + "';";
            MySqlCommand cmd = new MySqlCommand(str, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (textBox1.Text != reader.GetString("password"))
                {
                    MessageBox.Show("密码错误");
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    if (textBox2.Text == textBox3.Text)
                    {
                        string updataSql = "update manager set password ='" + textBox2.Text + "';";
                        MySqlCommand changePwd = new MySqlCommand(updataSql, conn);
                        int res = changePwd.ExecuteNonQuery();
                        if (res == 1)
                        {
                            MessageBox.Show("密码修改成功");
                        }
                        changePwd.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("二次确认密码失败，请重新输入");
                    }
                }
            }
            else
            {
                MessageBox.Show("用户不存在");
            }
            reader.Close();
            conn.Close();
        }

        private void changepwd_Load(object sender, EventArgs e)
        {

        }
    }
}
