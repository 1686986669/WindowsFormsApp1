﻿using System;
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
    public partial class Main4 : Form
    {
        public Main4()
        {
            InitializeComponent();
        }

        private void Main4_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“xsxxDataSet4.Course”中。您可以根据需要移动或删除它。
            this.courseTableAdapter.Fill(this.xsxxDataSet4.Course);

        }

        private void Main4_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)//删
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456");
            try
            {
                con.Open();
                string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string delete_by_id = "delete from Course where Cno=" + select_id;//sql删除语句
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
            this.courseTableAdapter.Fill(this.xsxxDataSet4.Course);
        }

        

        private void button1_Click(object sender, EventArgs e)//增，暂时无法实现增加一条cpno为null的数据
        {
            String cno = textBox1.Text.Trim();
            String cn = textBox2.Text.Trim();
            String cpo = textBox3.Text.Trim();
            int cd = int.Parse(textBox4.Text.Trim());
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456");
            try
            {
                con.Open();
                string insertStr = "INSERT INTO  Course (Cno,Cname,Cpno,Ccredit)    " +
                    "VALUES ('" + cno + "','" + cn + "','" + cpo + "','" + cd + "')";
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
                textBox4.Text = "";
            }
            this.courseTableAdapter.Fill(this.xsxxDataSet4.Course);

        }

        private void button3_Click(object sender, EventArgs e)//改
        {
            String cno = textBox1.Text.Trim();
            String cn = textBox2.Text.Trim();

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456");
            try
            {
                con.Open();
                string insertStr = "UPDATE Course SET Cname = '" + cn + "' WHERE Cno = '" + cno + "'";
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
            this.courseTableAdapter.Fill(this.xsxxDataSet4.Course);

        }

        private void button4_Click(object sender, EventArgs e)//只支持id的查
        {
            String cno = textBox1.Text.Trim();
            String conn = "Data Source=.;Initial Catalog=xsxx;User ID=sa;Password=123456";
            SqlConnection sqlConnection = new SqlConnection(conn);  //实例化连接对象
            try
            {
                sqlConnection.Open();
                String select_by_id = "select * from Course where Cno='" + cno + "'";
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

        private void button5_Click(object sender, EventArgs e)//返回
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
