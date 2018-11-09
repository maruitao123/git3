using System;
using System.Windows.Forms;
using BLL;
using Model;
using System.Data;
using WindowsFormsApplication26;
using System.Drawing;

namespace 期末作业
{
    public partial class Form2 : Form
    {
        private DataTable dt;
        int pageIdex=1;
        int MaxpageIdex = 0;
        int index = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //UI 初始化 隐藏部分Panel
            group_1_panel.Hide();
            group_2_panel.Hide();
            group_3_panel.Hide();
            //联级菜单 初始化第一个bombox
            Bll.comboBox_Address_1_init(comboBox_Address_1);
        }
        /***************侧边导航切换*3*******************/
        private void group_1_button_Click_1(object sender, EventArgs e)
        {
            if (group_1_panel.Visible)
            {
                group_1_panel.Hide();
            }
            else
            {
                group_1_panel.Show();
            }
        }
        private void group_2_button_Click(object sender, EventArgs e)
        {

            if (group_2_panel.Visible)
            {
                group_2_panel.Hide();
            }
            else
            {
                group_2_panel.Show();
            }
        }
        private void group_3_button_Click(object sender, EventArgs e)
        {
            if (group_3_panel.Visible)
            {
                group_3_panel.Hide();
            }
            else
            {
                group_3_panel.Show();
            }
        }
        /*************mian_panel显示切换***************/
        private void group_1_item_1_Click(object sender, EventArgs e)
        {
            if (!main_panel_1.Visible)
            {
                main_panel_1.Hide();
                main_panel_2.Hide();
                main_panel_3.Hide();
                main_panel_6.Hide();
                main_panel_7.Hide();
                main_panel_1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!main_panel_2.Visible)
            {
                main_panel_1.Hide();
                main_panel_2.Hide();
                main_panel_3.Hide();
                main_panel_6.Hide();
                main_panel_7.Hide();
                main_panel_2.Show();
            }
           
        }

        private void group_2_item_1_Click(object sender, EventArgs e)
        {
            if (!main_panel_3.Visible)
            {
                main_panel_1.Hide();
                main_panel_2.Hide();
                main_panel_3.Hide();
                main_panel_6.Hide();
                main_panel_7.Hide();
                main_panel_3.Show();
            }
        }

        private void group_3_item_2_Click(object sender, EventArgs e)
        {
            if (!main_panel_6.Visible)
            {
                main_panel_1.Hide();
                main_panel_2.Hide();
                main_panel_3.Hide();
                main_panel_6.Hide();
                main_panel_7.Hide();
                main_panel_6.Show();
            }
        }

        private void group_3_item_3_Click(object sender, EventArgs e)
        {
            if (!main_panel_7.Visible)
            {
                main_panel_1.Hide();
                main_panel_2.Hide();
                main_panel_3.Hide();
                main_panel_6.Hide();
                main_panel_7.Hide();
                main_panel_7.Show();
            }
        }

        //联级菜单
        private void comboBox_Address_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Address_2.Text = "";
            comboBox_Address_3.Text = "";
            //当省级菜单发生变化时加载市级数据
            Bll.comboBox_Address_2_init(comboBox_Address_2, comboBox_Address_1.SelectedItem.ToString());
            comboBox_Address_3.Items.Clear();
        }

        private void comboBox_Address_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Address_3.Text = "";
            //当市级菜单发生变化时加载区级数据
            Bll.comboBox_Address_3_init(comboBox_Address_3, comboBox_Address_2.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model_infAdd_Main.clear();
            //mark=true 时要求实体不能出现空值
            Model_infAdd_Main.Mark = true;
            /*****给实体类赋值*****/
            Model_infAdd_Main.Name = textBox_Name.Text;
            Model_infAdd_Main.Ad_1 = comboBox_Address_1.Text;
            Model_infAdd_Main.Ad_2 = comboBox_Address_2.Text;
            Model_infAdd_Main.Ad_3 = comboBox_Address_3.Text;
            Model_infAdd_Main.BoolType = comboBox_BoolType.Text;//Model_infAdd_Main.Date = 
            dateTimePicker_date.CustomFormat = "yyyy-MM-dd";
            dateTimePicker_date.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_date.ShowUpDown = true;
            Model_infAdd_Main.Date = dateTimePicker_date.Text;
            Model_infAdd_Main.PeopleId = textBox_People_Id.Text;
            Model_infAdd_Main.Sex = comboBox_Sex.Text;
            Model_infAdd_Main.Type = textBox_main_Type.Text;
            Model_infAdd_Other.Tel = textBox_Tel.Text;
            Model_infAdd_Other.Healthy = comboBox_Body.Text;
            Model_infAdd_Other.Lv = comboBox_Lv.Text;        
            //添加  
            Bll.add_cz_inf();
            //添加后查询 验证是否成功
            Model_infAdd_Main.Mark = false;
            Model_infAdd_Main.clear();
            Model_infAdd_Main.PeopleId = textBox_People_Id.Text;
            DataTable dtTemp = Bll.find_cz_inf();
            if (dtTemp.Rows.Count>0)
            {
                Model_infAdd_Other.People_inf_main_id = dtTemp.Rows[0][0].ToString();

               
                Model_infAdd_Other.Tel= textBox_Tel.Text;
                Model_infAdd_Other.Healthy = comboBox_Body.Text;
                Model_infAdd_Other.Lv = comboBox_Lv.Text;
                if (comboBox_Body.Text == "健康") {
                    Model_infAdd_Other.Lv = 0+"";
                }
                Bll.add_cz_other_inf();
                MessageBox.Show("添加成功");
            }
            else if(Model_infAdd_Main.Mark!=false){
                MessageBox.Show("失败");
            }
        }
        private void submit_Click(object sender, EventArgs e)
        {

            Model_infAdd_Main.clear();
            //mark=false 时要求实体可以出现空值
            Model_infAdd_Main.Mark = true;
            if (checkBox_Sb_Name.Checked == true){
                Model_infAdd_Main.Name = textBox_Sb_Name.Text;
            }


            if (checkBox_Sb_Sex.Checked == true)
            {
                Model_infAdd_Main.Sex = textBox_Sb_Sex.Text;
            }


            if (checkBox_Sb_Address.Checked == true)
            {
                Model_infAdd_Main.Ad_1 = textBox_Sb_Address.Text;
            }

            if (checkBox_Sb_Age.Checked == true)
            {
                Model_infAdd_Main.Age_1 = textBox_Sb_age_1.Text;
                Model_infAdd_Main.Age_2 = textBox_Sb_age_2.Text;
            }


            if (checkBox_Sb_Id.Checked == true)
            {
                Model_infAdd_Main.PeopleId = textBox_Sb_id.Text;
            }


            if (checkBox_Sb_BloodType.Checked == true)
            {
                Model_infAdd_Main.BoolType = textBox_Sb_BloodType.Text;
            }


            if (checkBox_Sb_Type.Checked == true)
            {
                Model_infAdd_Main.Type = textBox_Sb_Type.Text;
            }
            //给数据源dt
            dt = Bll.find_cz_inf();
            dataGridView1.DataSource = Bll.GetPagedTable(dt,1,10);
            //计算总行数
            MaxpageIdex = dt.Rows.Count;
            label15.Text = "1"+"/"+((dt.Rows.Count/10)+1).ToString();
        }

        private void textBox_Sb_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int index  = dataGridView1.CurrentRow.Index;
            Form4 f4 = new Form4((Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value.ToString())));
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("没有数据");
                return;
            }
            else {
                f4.Show();

            }
        }
        //翻页
        private void button14_Click(object sender, EventArgs e)
        {
            if (pageIdex <= (MaxpageIdex/10))
            {
                dataGridView1.DataSource = Bll.GetPagedTable(dt, ++pageIdex, 10);
                label15.Text = pageIdex + "/" + label15.Text.Split('/')[1];
            }
            else {
                MessageBox.Show("已经是最后一( •̀ ω •́ )y了");
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (pageIdex > 1)
            {
                dataGridView1.DataSource = Bll.GetPagedTable(dt, --pageIdex, 10);
              
                label15.Text= pageIdex+"/"+label15.Text.Split('/')[1];
            }
            else
            {
                MessageBox.Show("已经是最后一( •̀ ω •́ )y了");
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            pageIdex = 1;
            dataGridView1.DataSource = Bll.GetPagedTable(dt, 1, 10);
            label15.Text = pageIdex + "/" + label15.Text.Split('/')[1];
        }
        private void button8_Click(object sender, EventArgs e)
        {           
            int index = dataGridView1.CurrentRow.Index;
            Form3 f3 = new Form3(dataGridView1,index);
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("没有数据");
                return;
            }
            else
            {
                f3.Show();
            }
           
        }
       
        private void main_panel_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_Body_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Body.Text == "不健康")
            {
                comboBox_Lv.Enabled = true;
            }
            else {
                comboBox_Lv.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Model_infAdd_Main.Mark = false;
            Model_infAdd_Main.Name = textBox_Name.Text="";
            Model_infAdd_Main.Ad_1 = comboBox_Address_1.Text = "";
            Model_infAdd_Main.Ad_2 = comboBox_Address_2.Text = "";
            Model_infAdd_Main.Ad_3 = comboBox_Address_3.Text = "";
            Model_infAdd_Main.BoolType = comboBox_BoolType.Text = "";
            Model_infAdd_Main.Date  = "";
            dateTimePicker_date.Text = "";
            Model_infAdd_Main.PeopleId = textBox_People_Id.Text = "";
            Model_infAdd_Main.Sex = comboBox_Sex.Text = "";
            Model_infAdd_Main.Type = textBox_main_Type.Text = "";
            Model_infAdd_Other.Tel = textBox_Tel.Text = "";
            Model_infAdd_Other.Healthy = comboBox_Body.Text = "";
            Model_infAdd_Other.Lv = comboBox_Lv.Text = "";
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dt = Bll.find_cz_inf();
            dataGridView1.DataSource = Bll.GetPagedTable(dt, pageIdex, 10);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image img = null;
            
            DataTable dtTemp = new DataTable();
            int maxCount=0;
            float newMaxCount = 1;
            if (comboBox1.SelectedItem.ToString() == "近5年数据") {
                index++;
                maxCount = 0;
                newMaxCount = 1;
                String[] Count1 = new string[5];
                String[] Count2 = new string[5];
                int[] intCount1 = new int[5];
                int[] intCount2 = new int[5];
                for (int i=0;i<5;i++) {
                    dtTemp = Bll.findCount(i, i+1, "男");
                    Count1[i] = dtTemp.Rows[0][0].ToString();
                    if (Convert.ToInt32(Count1[i]) > maxCount) {
                        maxCount = Convert.ToInt32(Count1[i]);
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    dtTemp = Bll.findCount(i, i + 1, "女");
                    Count2[i] = dtTemp.Rows[0][0].ToString();
                    if (Convert.ToInt32(Count2[i]) > maxCount)
                    {
                        maxCount = Convert.ToInt32(Count2[i]);
                    }
                }
                int j = 0;
                j = maxCount.ToString().Length;
              
                for (int i = 0; i <j; i++) {
                    newMaxCount = newMaxCount * 10;
                }
               
                for (int i = 0; i < 5; i++)
                {
                    intCount1[i] = (int)((Convert.ToInt32(Count1[i])/newMaxCount)*100);                 
                }
                for (int i = 0; i < 5; i++)
                {
                    intCount2[i] = (int)((Convert.ToInt32(Count2[i]) / newMaxCount) * 100);
                }
                String[] n = { "0", "10", "20", "30", "40", "50", "60", "70", "80", "90" };
                String[] m = { "5","4","3","2","1"};
            CreateImageClass c = new CreateImageClass();
                c.M = m;
                c.N = n;
                c.CreateImage("一个统计图", intCount1, intCount2,index);
                img = Image.FromFile(@"C:\Users\Administrator\Desktop\love_max"+index+".jpg");

                pictureBox1.Image = img;
            }
            else if (comboBox1.SelectedItem.ToString() == "近10年数据")
            {
     

                maxCount = 0;
                index++;
                newMaxCount = 1;
                String[] Count1 = new string[10];
                String[] Count2 = new string[10];
                int[] intCount1 = new int[10];
                int[] intCount2 = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    dtTemp = Bll.findCount(i, i + 1, "男");
                    Count1[i] = dtTemp.Rows[0][0].ToString();
                    if (Convert.ToInt32(Count1[i]) > maxCount)
                    {
                        maxCount = Convert.ToInt32(Count1[i]);
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    dtTemp = Bll.findCount(i, i + 1, "女");
                    Count2[i] = dtTemp.Rows[0][0].ToString();
                    if (Convert.ToInt32(Count2[i]) > maxCount)
                    {
                        maxCount = Convert.ToInt32(Count2[i]);
                    }
                }
                int j = 0;
                j = maxCount.ToString().Length;

                for (int i = 0; i < j; i++)
                {
                    newMaxCount = newMaxCount * 10;
                }

                for (int i = 0; i < 10; i++)
                {
                    intCount1[i] = (int)((Convert.ToInt32(Count1[i]) / newMaxCount) * 100);
                }
                for (int i = 0; i < 10; i++)
                {
                    intCount2[i] = (int)((Convert.ToInt32(Count2[i]) / newMaxCount) * 100);
                }
                String[] n = { "0", "10", "20", "30", "40", "50", "60", "70", "80", "90" };
                String[] m = { "10", "9", "8", "7", "6" ,"5","4","3","2","1"};
                CreateImageClass c = new CreateImageClass();
                c.M = m;
                c.N = n;
                c.CreateImage("一个统计图", intCount1, intCount2,index);

                img = Image.FromFile(@"C:\Users\Administrator\Desktop\love_max"+index+".jpg");
                pictureBox1.Image = img;
                
            } 
        }
    }
}
