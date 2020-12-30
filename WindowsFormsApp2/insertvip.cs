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
    public partial class insertvip : Form
    {
        public insertvip()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            string sql = "insert into customer (customer_name,customer_level) values ('" + textBox1.Text + "',"+textBox2.Text+")";
            MySqlCommand changePwd = new MySqlCommand(sql, conn);
            int res = changePwd.ExecuteNonQuery();
            if (res == 1)
            {
                MessageBox.Show("添加成功");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
