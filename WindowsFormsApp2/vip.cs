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
    public partial class vip : Form
    {
        public vip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            string sql = "update customer set customer_level = " + textBox2.Text + " where customer_id = " + textBox1.Text ;
            MySqlCommand changePwd = new MySqlCommand(sql, conn);
            int res = changePwd.ExecuteNonQuery();
            if (res == 1)
            {
                MessageBox.Show("修改成功");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            string sql = "insert into customer (customer_name,customer_level) values ('" + textBox3.Text + "',1)";
            MySqlCommand changePwd = new MySqlCommand(sql, conn);
            int res = changePwd.ExecuteNonQuery();
            if (res == 1)
            {
                MessageBox.Show("添加成功");
            }
        }
    }
}
