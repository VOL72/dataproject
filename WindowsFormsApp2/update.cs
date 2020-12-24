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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
            b();
        }
        public void b()
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
                    this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("writer");
                    this.dataGridView1.Rows[index].Cells[3].Value = reader.GetFloat("price");
                    this.dataGridView1.Rows[index].Cells[4].Value = reader.GetString("type");
                    this.dataGridView1.Rows[index].Cells[5].Value = reader.GetString("publisher");
                    this.dataGridView1.Rows[index].Cells[6].Value = reader.GetInt32("number");
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
                string sql = "update bookinfo set " +comboBox1.Text+"= '"+textBox2.Text+"' where " + comboBox1.Text + " = '" + textBox1.Text + "' and isbn='"+textBox3.Text+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                string s1 = "select * from bookinfo";
                MySqlCommand cmd1 = new MySqlCommand(s1, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = reader.GetString("isbn");
                    this.dataGridView1.Rows[index].Cells[1].Value = reader.GetString("bookname");
                    this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("writer");
                    this.dataGridView1.Rows[index].Cells[3].Value = reader.GetFloat("price");
                    this.dataGridView1.Rows[index].Cells[4].Value = reader.GetString("type");
                    this.dataGridView1.Rows[index].Cells[5].Value = reader.GetString("publisher");
                    this.dataGridView1.Rows[index].Cells[6].Value = reader.GetInt32("number");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
