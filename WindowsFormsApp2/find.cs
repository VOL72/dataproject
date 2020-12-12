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
    public partial class find : Form
    {
        public find()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databaseConnection db = new databaseConnection();
            MySqlConnection conn = db.GetConnection();
            try
            {
                string sql = "select * from bookinfo where " + comboBox1.Text + " like '%" + textBox1.Text + "%'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = reader.GetString("isbn");
                    this.dataGridView1.Rows[index].Cells[1].Value = reader.GetString("bookname");
                    this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("writer");
                    this.dataGridView1.Rows[index].Cells[3].Value = reader.GetInt32("price");
                    this.dataGridView1.Rows[index].Cells[4].Value = reader.GetString("type");
                    this.dataGridView1.Rows[index].Cells[5].Value = reader.GetString("publisher");
                    this.dataGridView1.Rows[index].Cells[6].Value = reader.GetInt32("number");
                }

            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
