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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            luru l1 = new luru();
            l1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sell s1 = new sell();
            s1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            find fi = new find();
            fi.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            update u1 = new update();
            u1.Show();
        }
    }
}
