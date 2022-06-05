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
    public partial class Main5 : Form
    {
        public Main5()
        {
            InitializeComponent();
        }

        private void Main5_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“xsxxDataSet3.Student”中。您可以根据需要移动或删除它。
            this.studentTableAdapter.Fill(this.xsxxDataSet3.Student);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            String StuID = textBox1.Text.Trim();//读取文本框的值
            String StuName = textBox2.Text.Trim();
            String StuSex = textBox3.Text.Trim();
            String StuSdept = textBox5.Text.Trim();
            int StuAge = int.Parse(textBox4.Text.Trim());
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456");
            try
            {
                con.Open();
                string insertStr = "INSERT INTO  Student (Sno,Sname,Ssex,Sdept,Sage)    " +
                    "VALUES ('" + StuID + "','" + StuName + "','" + StuSex + "','" + StuSdept + "'," + StuAge + ")";
                SqlCommand cmd = new SqlCommand(insertStr, con);//通过sql语句对表添加数值
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
                textBox4.Text = "";
                textBox5.Text = "";
            }
            this.studentTableAdapter.Fill(this.xsxxDataSet3.Student);//刷新表

        }

        private void button2_Click(object sender, EventArgs e)//删
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456");
            try
            {
                con.Open();
                string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string delete_by_id = "delete from Student where Sno=" + select_id;//sql删除语句
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
            this.studentTableAdapter.Fill(this.xsxxDataSet3.Student);


        }

        private void button4_Click(object sender, EventArgs e)//改，只能修改名字
        {
            String StuID = textBox1.Text.Trim();
            String StuName = textBox2.Text.Trim();

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456");
            try
            {
                con.Open();
                string insertStr = "UPDATE Student SET Sname = '" + StuName + "' WHERE Sno = '" + StuID + "'";
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
            }
            this.studentTableAdapter.Fill(this.xsxxDataSet3.Student);

        }

        private void button5_Click(object sender, EventArgs e)//查
        {
            String StuID = textBox1.Text.Trim();
            String conn = "Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from Student where Sno='" + StuID + "'";
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
