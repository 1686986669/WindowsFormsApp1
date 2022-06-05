using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main2 : Form
    {
        public Main2()
        {
            InitializeComponent();
        }

        private void Main2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main7 m = new Main7();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main5 m = new Main5();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main4 m = new Main4();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main3 m = new Main3();
            m.Show();
        }

        private void Main2_Load(object sender, EventArgs e)
        {

        }
    }
}
