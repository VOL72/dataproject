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
    public partial class luru : Form
    {
        public luru()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isbn,bookname,writer,price,type,publisher,number;

            isbn = textBox1.Text;
            bookname = textBox2.Text;
            writer = textBox3.Text;
            price = textBox4.Text;
            type = textBox5.Text;
            publisher = textBox6.Text;
            number = textBox7.Text;
            if (isbn != null)
            { 
                    databaseConnection db = new databaseConnection();
                    MySqlConnection conn = db.GetConnection();
                    string sql = "INSERT INTO bookinfo (isbn,bookname,writer,price,type,publisher,number) VALUES ('" + isbn + "','" + bookname + "','" + writer+ "','" +price+ "','"+ type+ "','"+publisher+ "','"+number+"'"+");";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("录入成功");
                    }
                    else
                    {
                        MessageBox.Show("录入失败");
                    }
                    conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
