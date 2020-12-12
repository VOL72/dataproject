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
    public partial class sell : Form
    {
        public sell()
        {
            InitializeComponent();
            a();
        }
        public void a()
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            try
            {
                string sql = "select * from bookinfo";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = reader.GetString("isbn");
                    this.dataGridView1.Rows[index].Cells[1].Value = reader.GetString("bookname");
                    this.dataGridView1.Rows[index].Cells[2].Value = reader.GetInt32("price");
                    this.dataGridView1.Rows[index].Cells[3].Value = reader.GetInt32("number");

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void button1_Click(object sender, EventArgs e)
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            try
            {
                int a = int.Parse(textBox2.Text);
                int b=0 ;
                string str = "select number from bookinfo where=" + "'" + textBox1.Text + "'";
                MySqlCommand c1 = new MySqlCommand(str, conn);
                MySqlDataReader r1 = c1.ExecuteReader();
                if (r1.Read())
                {
                    b = r1.GetInt32("number");
                }
                int c = b - a;
                string number = c.ToString();  
                string s1 = "update bookinfo set number=" + number + " where bookname=" + "'" +textBox1.Text+ "'";
                MySqlCommand c2 = new MySqlCommand(s1, conn);
                c2.ExecuteNonQuery();
                string sql = "select * from bookinfo";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = reader.GetString("isbn");
                    this.dataGridView1.Rows[index].Cells[1].Value = reader.GetString("bookname");
                    this.dataGridView1.Rows[index].Cells[2].Value = reader.GetInt32("price");
                    this.dataGridView1.Rows[index].Cells[3].Value = reader.GetInt32("number");

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }  

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

