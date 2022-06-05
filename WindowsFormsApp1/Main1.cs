using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main1 : Form
    {
        public Main1()
        {
            InitializeComponent();
        }

        string Id;
        public void GetId(string id)//上个窗体调用此函数，将id值传过来
        {
            label3.Text = id;
            label3.Refresh();
            Id = id;
        }


        private void Main1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Main1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“xsxxDataSet.Course”中。您可以根据需要移动或删除它。
            this.courseTableAdapter.Fill(this.xsxxDataSet.Course);
            // TODO: 这行代码将数据加载到表“xsxxDataSet1.SC”中。您可以根据需要移动或删除它。
            this.sCTableAdapter.Fill(this.xsxxDataSet1.SC);
            string name, sex, dept, tel;
            int age;
            string connString = "Data Source=.;Initial Catalog=xsxx;Persist Security Info=True;User ID=sa;Password=123456";//数据库连接字符串
            SqlConnection conn = new SqlConnection(connString);//创建connection对象
            conn.Open();//打开数据库  

            //创建数据库命令  
            SqlCommand cmd = conn.CreateCommand();
            //创建查询语句  
            cmd.CommandText = "select * from Student where Sno = '" + Id + "';select * from StudentUser where ID = '" + Id + "'";
            //从数据库中读取数据流存入reader中  
            SqlDataReader reader = cmd.ExecuteReader();

            //从reader中读取下一行数据,如果没有数据,reader.Read()返回flase  
            while (reader.Read())
            {
                name = reader.GetString(reader.GetOrdinal("Sname"));
                sex = reader.GetString(reader.GetOrdinal("Ssex"));
                age = reader.GetInt16(reader.GetOrdinal("Sage"));
                dept = reader.GetString(reader.GetOrdinal("Sdept"));

                label5.Text = name;
                label5.Refresh();
                label7.Text = sex;
                label9.Text = age.ToString();
                label11.Text = dept;
                break;
            }
            reader.NextResult();//执行下一句操作


            //从reader中读取下一行数据,如果没有数据,reader.Read()返回flase  
            while (reader.Read())
            {

                tel = reader.GetString(reader.GetOrdinal("UserMobile"));

                label13.Text = tel;
                break;
            }

            reader.Close();


            SqlDataAdapter dap = new SqlDataAdapter("select * from SC where Sno='" + Id + "'", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView4.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            conn.Close();
            int i = 0;
            int x = 0, h = 0;
            int a;
            for (; i < ds.Tables[0].Rows.Count; i++)//读取DataSet中的指定数据
            {
                x += int.Parse(ds.Tables[0].Rows[i][2].ToString());
                if (int.Parse(ds.Tables[0].Rows[i][2].ToString()) > 59)
                    h++;
            }
            a = x / i;
            label17.Text = h.ToString();
            label19.Text = a.ToString();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//单击退出，则退出程序
        {
            this.Close();
            Main2 m2 = new Main2();
            m2.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = "Data Source=.;Initial Catalog=xsxx;Persist Security Info=True;User ID=sa;Password=123456";//数据库连接字符串
                SqlConnection connection = new SqlConnection(connString);//创建connection对象

                //打开数据库连接
                connection.Open();
                //创建SQL语句
                string sql = "select UserPhoto from StudentUser where ID = '" + Id + "'";
                //创建SqlCommand对象
                SqlCommand command = new SqlCommand(sql, connection);
                //创建DataAdapter对象
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                //创建DataSet对象
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "StudentUser");
                int c = dataSet.Tables["StudentUser"].Rows.Count;
                if (c > 0)
                {
                    Byte[] mybyte = new byte[0];
                    mybyte = (Byte[])(dataSet.Tables["StudentUser"].Rows[c - 1]["UserPhoto"]);
                    MemoryStream ms = new MemoryStream(mybyte);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                else
                    pictureBox1.Image = null;
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
