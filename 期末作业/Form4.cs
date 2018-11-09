using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期末作业
{
    public partial class Form4 : Form
    {
        public Form4(int id)
        {
            InitializeComponent();
            Model_infAdd_Other.People_inf_main_id = id.ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            Model_infAdd_Other.Tel = textBox_Tel.Text;
            Model_infAdd_Other.Healthy = comboBox_Body.Text;
            Model_infAdd_Other.Lv = comboBox_Lv.Text;
            Bll.ChangeById();
        }
    }
}
