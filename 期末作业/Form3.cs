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
    public partial class Form3 : Form
    {
        DataGridView dgPublic;
        int indexPublic;
        public Form3(DataGridView dg,int index)
        {
            dgPublic = dg;
            indexPublic=index;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox_Name.Text = dgPublic.Rows[indexPublic].Cells[1].Value.ToString();
            comboBox_Sex.Text = dgPublic.Rows[indexPublic].Cells[2].Value.ToString();
            textBox_main_Type.Text = dgPublic.Rows[indexPublic].Cells[3].Value.ToString();
            comboBox_Address_1.Text = dgPublic.Rows[indexPublic].Cells[4].Value.ToString();
            comboBox_Address_2.Text = dgPublic.Rows[indexPublic].Cells[5].Value.ToString();
            comboBox_Address_3.Text = dgPublic.Rows[indexPublic].Cells[6].Value.ToString();
            label10.Text = dgPublic.Rows[indexPublic].Cells[8].Value.ToString();
            //dateTimePicker_date.Value = (DateTime)dgPublic.Rows[0].Cells[8].Value;
            comboBox_BoolType.Text = dgPublic.Rows[indexPublic].Cells[7].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model_infAdd_Main.clear();
            Model_infAdd_Main.Name= textBox_Name.Text;
            Model_infAdd_Main.PeopleId= label10.Text;
            Model_infAdd_Main.Sex = comboBox_Sex.Text;
            Model_infAdd_Main.BoolType = comboBox_BoolType.Text;
            Model_infAdd_Main.Type= textBox_main_Type.Text;
            Bll.ChangeByPeopleId();
        }
    }
}
