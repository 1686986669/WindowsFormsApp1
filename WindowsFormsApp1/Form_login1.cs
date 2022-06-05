using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_login1 : Form
    {
        public Form_login1()
        {
            InitializeComponent();
        }

        private void Form_login1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public string code;//储存生成验证码

        private void button1_Click(object sender, EventArgs e)//登陆
        {
            string username = textBox1.Text.Trim();  //取出账号
            string password = EncryptWithMD5(textBox2.Text.Trim());  //取出密码并加密

            string myConnString = "Data Source=.;Initial Catalog=xsxx;Persist Security Info=True;User ID=sa;Password=123456";

            SqlConnection sqlConnection = new SqlConnection(myConnString);  //实例化连接对象
            sqlConnection.Open();

            string sql = "select ID,PassWord from StudentUser where ID = '" + username + "' and PassWord = '" + password + "'";                                            //编写SQL命令
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();//读取数据

            if (sqlDataReader.HasRows && textBox3.Text == code)//验证是否有该用户及密码且验证码正确
            {
                MessageBox.Show("欢迎使用！");             //登录成功
                Main1 main1 = new Main1();
                main1.GetId(username);
                main1.Show();//显示下一界面
                this.Hide();
            }
            else if (sqlDataReader.HasRows && textBox3.Text != code)
            {
                MessageBox.Show("验证码错误，登录失败！");
                return;
            }
            else
            {
                MessageBox.Show("账号密码有误，登录失败！");
                return;
            }
            sqlDataReader.Close();
            //string loginlog = "insert into SysLog1 values ( '" + username + "' , 'Student','" + DateTime.Now + "' , '" + "Login" + "')";
            string loginlog = "INSERT INTO  SysLog1(UserID, dentity, DateAndTime, UserOperation)    " +
                    "VALUES ('" + username + "','" + "Student" + "','" + DateTime.Now + "','" + "Login" + "')"; //编写SQL命令,把登陆信息存入登录日志
            SqlCommand cmd = new SqlCommand(loginlog, sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            


        }
        private string EncryptWithMD5(string source)//MD5加密
        {
            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
            }
            return strbul.ToString();
        }

        private void button2_Click(object sender, EventArgs e)//返回到login界面
        {
            this.Hide();
            login lg = new login();
            lg.Show();
        }

        private void Form_login1_Load(object sender, EventArgs e)
        {
            // 随机实例化
            Random ran = new Random();
            int number;
            char code1;
            //取五个数 
            for (int i = 0; i < 5; i++)
            {
                number = ran.Next();
                if (number % 2 == 0)
                    code1 = (char)('0' + (char)(number % 10));
                else
                    code1 = (char)('A' + (char)(number % 26)); //转化为字符 

                this.code += code1.ToString();
            }

            label5.Text = code;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
