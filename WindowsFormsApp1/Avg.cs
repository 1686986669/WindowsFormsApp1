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
    public partial class Avg : Form
    {
        public Avg()
        {
            InitializeComponent();
        }

        private void Avg_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Avg_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“xsxxDataSet6.AVG”中。您可以根据需要移动或删除它。
            this.aVGTableAdapter.Fill(this.xsxxDataSet6.AVG);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
