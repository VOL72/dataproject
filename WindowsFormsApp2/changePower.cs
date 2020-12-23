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
    public partial class changePower : Form
    {
        public changePower()
        {
            InitializeComponent();
        }
        //权限设置
        private void button1_Click(object sender, EventArgs e)
        {
            login login = new login();
            if(login.power != "管理员")
            {
                MessageBox.Show("您没有该权限");
            }
            else { 
                databaseConnection db = new databaseConnection();
                MySqlConnection conn = db.GetConnection();
                string checkUser = "select power from manager where manager_id = '" + textBox1.Text + "';";
                MySqlCommand check = new MySqlCommand(checkUser, conn);
                MySqlDataReader reader = check.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    string updataPower = "update manager set power = '管理员' where manager_id = '" + textBox1.Text + "';";
                    MySqlCommand updata = new MySqlCommand(updataPower, conn);
                    int res = updata.ExecuteNonQuery();
                    if(res == 1)
                    {
                        MessageBox.Show("权限修改成功");
                    }
                    else
                    {
                        MessageBox.Show("失败");
                    }
                    updata.Dispose();
                    conn.Close();
                }
            }
        }
    }
}
