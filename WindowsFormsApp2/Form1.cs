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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            dataGridView1.Rows.Clear();
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();

            string sql = "select * from bookorder;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = reader.GetInt32("order_id");
                this.dataGridView1.Rows[index].Cells[1].Value = reader.GetInt32("customer_id");
                this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("isbn");
                this.dataGridView1.Rows[index].Cells[3].Value = reader.GetDateTime("time").ToString();
                this.dataGridView1.Rows[index].Cells[4].Value = reader.GetInt32("amount");
                this.dataGridView1.Rows[index].Cells[5].Value = reader.GetFloat("number");
            }
            reader.Close();
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from bookorder where time between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "'";
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = reader.GetInt32("order_id");
                this.dataGridView1.Rows[index].Cells[1].Value = reader.GetInt32("customer_id");
                this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("isbn");
                this.dataGridView1.Rows[index].Cells[3].Value = reader.GetDateTime("time").ToString();
                this.dataGridView1.Rows[index].Cells[4].Value = reader.GetInt32("amount");
                this.dataGridView1.Rows[index].Cells[5].Value = reader.GetFloat("number");
            }
            reader.Close();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from bookorder where QUARTER(time)=QUARTER(now());";
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = reader.GetInt32("order_id");
                this.dataGridView1.Rows[index].Cells[1].Value = reader.GetInt32("customer_id");
                this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("isbn");
                this.dataGridView1.Rows[index].Cells[3].Value = reader.GetDateTime("time").ToString();
                this.dataGridView1.Rows[index].Cells[4].Value = reader.GetInt32("amount");
                this.dataGridView1.Rows[index].Cells[5].Value = reader.GetFloat("number");
            }
            reader.Close();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM bookorder WHERE DATE_FORMAT( TIME, '%Y%m' ) = DATE_FORMAT( CURDATE( ) , '%Y%m' )";
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = reader.GetInt32("order_id");
                this.dataGridView1.Rows[index].Cells[1].Value = reader.GetInt32("customer_id");
                this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("isbn");
                this.dataGridView1.Rows[index].Cells[3].Value = reader.GetDateTime("time").ToString();
                this.dataGridView1.Rows[index].Cells[4].Value = reader.GetInt32("amount");
                this.dataGridView1.Rows[index].Cells[5].Value = reader.GetFloat("number");
            }
            reader.Close();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            string sql = "SELECT bookinfo.bookname ,SUM(bookorder.number) FROM bookorder,bookinfo WHERE bookorder.isbn = bookinfo.isbn GROUP BY bookinfo.bookname ORDER BY bookinfo.bookname DESC limit 5";
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int index = this.dataGridView3.Rows.Add();
                this.dataGridView3.Rows[index].Cells[0].Value = reader.GetString("bookname");
                this.dataGridView3.Rows[index].Cells[1].Value = reader.GetInt32("sum(bookorder.number)");
            }
            reader.Close();
            conn.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Init();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "select sum(amount) from bookorder;";
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = "总销售额为" + reader.GetFloat("sum(amount)").ToString();
            }
            reader.Close();
            conn.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sql = "select sum(amount) from bookorder  where QUARTER(time)=QUARTER(now());;";
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox2.Text = "本季度销售额为" + reader.GetFloat("sum(amount)").ToString();
            }
            reader.Close();
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "select sum(amount) from bookorder WHERE DATE_FORMAT( TIME, '%Y%m' ) = DATE_FORMAT( CURDATE( ) , '%Y%m' )";
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox3.Text = "本季度销售额为" + reader.GetFloat("sum(amount)").ToString();
            }
            reader.Close();
            conn.Close();
        }
    }
}
