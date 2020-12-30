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
            float discount = 0;
            string levelSql = "select customer_level from customer where customer_id=" + textBox3.Text + ";";
            MySqlCommand selectLevel = new MySqlCommand(levelSql, conn);
            MySqlDataReader result = selectLevel.ExecuteReader();
            int level = 0;

            if (result.Read())
            {
                level = result.GetInt32("customer_level");
            }
            result.Close();
            //textBox4.Text = level.ToString();
            string discountSql = "select discount from customer_level where customer_level=" + level.ToString() + ";";
            MySqlCommand selectDiscount = new MySqlCommand(discountSql, conn);
            MySqlDataReader getDiscount = selectDiscount.ExecuteReader();

            if (getDiscount.Read())
            {
                discount = getDiscount.GetFloat("discount");
            }
            getDiscount.Close();
            //textBox4.Text = discount.ToString();
            try
            {
                int number = int.Parse(textBox2.Text);
                string isbn = textBox1.Text;
                string s1 = "update bookinfo set number=number-" + number + " where isbn=" + "'" + isbn + "'";
                MySqlCommand c2 = new MySqlCommand(s1, conn);
                c2.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
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
                reader.Close();

                float price = 0;
                string priceSql = "select price from bookinfo where isbn='" + isbn + "';";
                MySqlCommand selectPrice = new MySqlCommand(priceSql, conn);
                MySqlDataReader getPrice = selectPrice.ExecuteReader();
                               
                if (getPrice.Read())
                {
                    price = getPrice.GetFloat("price");
                }
                getPrice.Close();
                //textBox4.Text = price.ToString();
                float num = number;
                float totalPrice = num * price * discount;
                //textBox4.Text = totalPrice.ToString();
                //string insertOrder = "insert into order (order_id,customer_id,isbn,time,amount,number) values (null,'" + textBox3.Text + "','" + isbn + "','" + DateTime.Now.ToLocalTime().ToString() + "'," + totalPrice.ToString() + "," + number.ToString() + ");";
                //textBox4.Text = DateTime.Now.ToLocalTime();
                string insertOrder = "insert into `bookmanager`.`bookorder` (`order_id`, `customer_id`, `isbn`, `time`, `amount`, `number`)values(NULL, '" + textBox3.Text + "', '" + isbn + "', '" + DateTime.Now.ToLocalTime().ToString() + "', '"+ totalPrice.ToString() + "', '" + number.ToString() + "');";
                MySqlCommand addOrder = new MySqlCommand(insertOrder, conn);
                int res = addOrder.ExecuteNonQuery();
                if(res == 1)
                {
                    MessageBox.Show("订单创建成功");
                }
                else
                {
                    MessageBox.Show("订单创建失败");
                }
                string isenough = "select sum(amount) from bookorder where customer_id = '" + textBox3.Text + "'";
                MySqlCommand vip = new MySqlCommand(isenough, conn);
                MySqlDataReader isvip = vip.ExecuteReader();
                if (isvip.Read())
                {
                    float money = isvip.GetFloat("sum(amount)");
                    if(money > 100 && money <= 200 && level < 1)
                    {
                        MessageBox.Show("可以将该会员升级为1级");
                    }
                    else if (money > 200 && money <= 300 && level < 2)
                    {
                        MessageBox.Show("可以将会员升为2级");
                    }
                    else if (money > 300 && money <= 400 && level < 3)
                    {
                        MessageBox.Show("可以将会员升为3级");
                    }
                    else if (money > 400 && money <= 500 && level < 4)
                    {
                        MessageBox.Show("可以将会员升为4级");
                    }
                    else if (money > 500 && level < 5)
                    {
                        MessageBox.Show("可以将会员升为5级");
                    }
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

        private void button3_Click(object sender, EventArgs e)
        {
            insertvip iv = new insertvip();
            iv.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

