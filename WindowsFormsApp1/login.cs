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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void xslogin_Click(object sender, EventArgs e)
        {
            Form_login1 form_login1 = new Form_login1(); //学生登陆窗体
            form_login1.Show();//跳转至学生登陆窗体
            this.Hide();  //隐藏原窗体
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void adminlogin_Click(object sender, EventArgs e)
        {
            Form_login2 form_login2 = new Form_login2();//管理员登陆窗体
            form_login2.Show();//跳转至管理员登陆窗体
            this.Hide();//隐藏原窗体
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
