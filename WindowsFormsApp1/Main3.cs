using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main3 : Form
    {
        public Main3()
        {
            InitializeComponent();
        }

        private void Main3_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Main3_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“xsxxDataSet5.SC”中。您可以根据需要移动或删除它。
            this.sCTableAdapter.Fill(this.xsxxDataSet5.SC);

        }

        private void button1_Click(object sender, EventArgs e)//增
        {
            String sno = textBox1.Text.Trim();
            String cno = textBox2.Text.Trim();
            int gra = int.Parse(textBox3.Text.Trim());
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456");
            try
            {
                con.Open();
                string insertStr = "INSERT INTO  SC (Sno,Cno,Grade)    " +
                    "VALUES ('" + sno + "','" + cno + "','" + gra + "')";
                SqlCommand cmd = new SqlCommand(insertStr, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("输入数据违反要求!");
            }
            finally
            {
                con.Dispose();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            this.sCTableAdapter.Fill(this.xsxxDataSet5.SC);
        }


            private void button2_Click(object sender, EventArgs e)//删
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456");
            try
            {
                con.Open();
                string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string select_cn = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string delete_by_id = "delete from SC where Sno=" + select_id + "and Cno=" + select_cn;//sql删除语句
                SqlCommand cmd = new SqlCommand(delete_by_id, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("请正确选择行!");
            }
            finally
            {
                con.Dispose();

            }
            this.sCTableAdapter.Fill(this.xsxxDataSet5.SC);


        }

        private void button3_Click(object sender, EventArgs e)//改
        {
            String sno = textBox1.Text.Trim();
            String cno = textBox2.Text.Trim();

            int gra = int.Parse(textBox3.Text.Trim());
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456");
            try
            {
                con.Open();
                string insertStr = "UPDATE SC SET Grade='" + gra + "' WHERE Sno = '" + sno + "' AND Cno = '" + cno + "'";
                SqlCommand cmd = new SqlCommand(insertStr, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("输入数据违反要求!");
            }
            finally
            {
                con.Dispose();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            this.sCTableAdapter.Fill(this.xsxxDataSet5.SC);

            

        }

        private void button5_Click(object sender, EventArgs e)//查
        {
            String sno = textBox1.Text.Trim();
            String conn = "Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from SC where Sno='" + sno + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView1.DataSource = bindingSource;
            }
            catch
            {
                MessageBox.Show("查询语句有误，请认真检查SQL语句!");
            }
            finally
            {
                sqlConnection.Close();
                textBox1.Text = "";
            }

        }

        private void button4_Click(object sender, EventArgs e)//avg
        {
            string connString = "Data Source=.;Initial Catalog=xsxx;Persist Security Info=True;User ID=sa;Password=123456";//数据库连接字符串
            SqlConnection connection = new SqlConnection(connString);//创建connection对象
            string sql1 = "EXEC COURSE_AVG";//编写SQL命令
            SqlCommand sqlCommand1 = new SqlCommand(sql1, connection);
            connection.Open();
            sqlCommand1.ExecuteNonQuery();
            connection.Close();
            Avg avg = new Avg();
            avg.Show();

        }

        private void button6_Click(object sender, EventArgs e)//返回
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
