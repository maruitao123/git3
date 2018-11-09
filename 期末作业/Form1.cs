using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期末作业
{
    public partial class Form1 : Form
    {


        bool mark = false;

        int i = 0;


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadStart childref = new ThreadStart(conFun);
            Thread childThread = new Thread(childref);
            childThread.Start();
        }
        void conFun() {
            Sql.ExecuteQuery("SELECT * from `user` WHERE `name` = '" + textBox1.Text + "' AND `password`='" + textBox2.Text + "'");
            mark = true;
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            //模拟登录耗时
            DataTable dt = new DataTable();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                dt = Sql.ExecuteQuery("SELECT * from `user` WHERE `name` = '"+textBox1.Text+"' AND `password`='"+textBox2.Text+"'");
                if (dt.Rows.Count>=1)
                {
                    Form2 form = new Form2(); 
                    form.Show();
                    this.Hide();
                    MessageBox.Show("登陆成功");
                }
                else {
                    MessageBox.Show("失败");
                }

            }
            else {
                MessageBox.Show("空");
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mark == false)
            {
                toolStripLabel1.Text = "正在连接服务器" + i + "秒";
                i++;
            }
            else {
                toolStripLabel1.Text = "已连接";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
