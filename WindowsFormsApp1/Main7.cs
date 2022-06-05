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
    public partial class Main7 : Form
    {
        public Main7()
        {
            InitializeComponent();
        }

        private void Main7_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Main7_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“xsxxDataSet2.SysLog1”中。您可以根据需要移动或删除它。
            this.sysLog1TableAdapter.Fill(this.xsxxDataSet2.SysLog1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main2 m2 = new Main2();
            m2.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
