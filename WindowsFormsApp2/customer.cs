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
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
            c();
            d();
        }
        public void c()
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            try
            {
                string sql = "select * from customer";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = reader.GetInt32("customer_id");
                    this.dataGridView1.Rows[index].Cells[1].Value = reader.GetString("customer_name");
                    this.dataGridView1.Rows[index].Cells[2].Value = reader.GetInt32("customer_level");

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

        public void d()
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            try
            {
                string sql = "select * from level";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int index = this.dataGridView2.Rows.Add();
                    this.dataGridView2.Rows[index].Cells[0].Value = reader.GetInt32("customer_level");
                    this.dataGridView2.Rows[index].Cells[1].Value = reader.GetFloat("discount");

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

        private void button1_Click(object sender, EventArgs e)
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            try
            {
                string s3 = "update customer set " + comboBox1.Text + "= '" + textBox2.Text + "' where " + "customer_id='" + textBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(s3, conn);
                cmd.ExecuteNonQuery();
                string s4 = "select * from customer";
                MySqlCommand cmd1 = new MySqlCommand(s4, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = reader.GetInt32("customer_id");
                    this.dataGridView1.Rows[index].Cells[1].Value = reader.GetString("customer_name");
                    this.dataGridView1.Rows[index].Cells[2].Value = reader.GetInt32("customer_level");
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertvip iv = new insertvip();
            iv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            try
            {
                string sql = "update level set discount= '" + textBox4.Text + "' where " + "customer_level='" + textBox3.Text + "'";
                MySqlCommand c1 = new MySqlCommand(sql, conn);
                c1.ExecuteNonQuery();
                string s1 = "select * from level";
                MySqlCommand c2 = new MySqlCommand(s1, conn);
                MySqlDataReader reader = c2.ExecuteReader();
                dataGridView2.Rows.Clear();
                while (reader.Read())
                {
                    int index = this.dataGridView2.Rows.Add();
                    this.dataGridView2.Rows[index].Cells[0].Value = reader.GetInt32("customer_level");
                    this.dataGridView2.Rows[index].Cells[1].Value = reader.GetFloat("discount");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
