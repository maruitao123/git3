using DAL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public static class Bll
    {
        /*****************联机菜单实现*****************/
        public static void comboBox_Address_1_init(ComboBox cb)
        {
            cb.Items.Clear();
            DataTable dt = Sql.ExecuteQuery("select province from provinces");
            for (int i=0;i<dt.Rows.Count;i++) { 
                cb.Items.Add(dt.Rows[i][0]);
            }
        }
        public static void comboBox_Address_2_init(ComboBox cb,String province)
        {
            cb.Items.Clear();
            DataTable dt = Sql.ExecuteQuery("select city from cities where provinceid=(select provinceid from provinces where province="+"'"+ province + "'" + ")");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb.Items.Add(dt.Rows[i][0]);
            }
        }
        public static void comboBox_Address_3_init(ComboBox cb,String city)
        {
            cb.Items.Clear();
            DataTable dt = Sql.ExecuteQuery("select area,areaid from areas where cityid=(select cityid from cities where city=" + "'" + city + "'" + ")");//"select area from areas where cityid=(select cityid from cities where city="+"'"+ city + "'" + ")"
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb.Items.Add(dt.Rows[i][0].ToString()+ dt.Rows[i][1].ToString());
            }
        }
        /*******************添加（主要）信息的实现*********************/
        public static int add_cz_inf() {
            //Model_infAdd_Main.Ad_1
            //Model_infAdd_Main.Ad_2
            //Model_infAdd_Main.Ad_3
            //Model_infAdd_Main.Age_1
            //Model_infAdd_Main.Age_2
            //Model_infAdd_Main.About
            //Model_infAdd_Main.BoolType
            //Model_infAdd_Main.Date
            //Model_infAdd_Main.PeopleId
            //Model_infAdd_Main.Sex
            //Model_infAdd_Main.Type
            if (Model_infAdd_Main.Mark == true) {
                return Sql.ExecuteUpdata("INSERT INTO permanent_people_inf (NAME,sex,type,province,city,area,bloodType,peopleId,date) VALUES('" + Model_infAdd_Main.Name + "','" + Model_infAdd_Main.Sex + "','" + Model_infAdd_Main.Type + "','" + Model_infAdd_Main.Ad_1 + "','" + Model_infAdd_Main.Ad_2 + "','" + Model_infAdd_Main.Ad_3 + "','" + Model_infAdd_Main.BoolType + "','" + Model_infAdd_Main.PeopleId + "','" + Model_infAdd_Main.Date + "')");
            } else {
                return -1;
            } 
        }
        /*******************添加（次要）信息的实现*********************/
        public static int add_cz_other_inf(){
            if (Model_infAdd_Other.Tel!="" &&  Model_infAdd_Other.Healthy!="") {
                return Sql.ExecuteUpdata("INSERT INTO permanent_people_inf_other (people_inf_main_id,tel,lv) values('"+ Model_infAdd_Other.People_inf_main_id+ "','"+ Model_infAdd_Other.Tel+ "','"+ Model_infAdd_Other.Lv+ "')");
            } else {
                return -1;
            } 
        }
        /*******************多条件查询的实现*********************/
        public static DataTable find_cz_inf() {
            DataTable dt = new DataTable();
            String sqlStr = "";
            String sqlStrSelect = "select * from permanent_people_inf where";
            if (Model_infAdd_Main.Name != "") {
                sqlStr = sqlStr+" and name="+"'"+Model_infAdd_Main.Name+"'";
            }
            if (Model_infAdd_Main.Sex != "")
            {
                sqlStr = sqlStr + " and sex=" + "'" + Model_infAdd_Main.Sex + "'";
            }
            if (Model_infAdd_Main.Type != "")
            {
                sqlStr = sqlStr + " and type=" + "'" + Model_infAdd_Main.Type + "'";
            }
            if (Model_infAdd_Main.PeopleId != "")
            {
                sqlStr = sqlStr + " and peopleId=" + "'" + Model_infAdd_Main.PeopleId + "'";
            }
            if (Model_infAdd_Main.BoolType != "")
            {
                sqlStr = sqlStr + " and bloodType=" + "'" + Model_infAdd_Main.BoolType + "'";
            }
            if (Model_infAdd_Main.Ad_1 != "")
            {
                sqlStr = sqlStr + " and (province like" + "'%" + Model_infAdd_Main.Ad_1 + "%'";
                sqlStr = sqlStr + " or city like" + "'%" + Model_infAdd_Main.Ad_1 + "%'";
                sqlStr = sqlStr + " or area like" + "'%" + Model_infAdd_Main.Ad_1 + "%')";
            }
            int year = DateTime.Now.Year;
            if (Model_infAdd_Main.Age_1 != "")
            {
                sqlStr = sqlStr + " and year(date)<=" + "'" + (year-Convert.ToInt32(Model_infAdd_Main.Age_1)).ToString() + "'";
            }
            if (Model_infAdd_Main.Age_2!= "")
            {
                sqlStr = sqlStr + " and year(date)>'" + (year - Convert.ToInt32(Model_infAdd_Main.Age_2)).ToString() + "'";
            }
            MessageBox.Show(sqlStrSelect + sqlStr.Substring(4));
            dt = Sql.ExecuteQuery(sqlStrSelect + sqlStr.Substring(4));//sqlStrSelect + sqlStr.Substring(3)
           
            return dt;
        }
        //根据身份证id修改可修改值
        public static int ChangeByPeopleId() {
            return Sql.ExecuteUpdata("UPDATE permanent_people_inf SET name='"+Model_infAdd_Main.Name+ "',sex='" + Model_infAdd_Main.Sex + "',type='" + Model_infAdd_Main.Type + "',bloodType='" + Model_infAdd_Main.BoolType + "' WHERE peopleId='" + Model_infAdd_Main.PeopleId + "'");
        }
        //根据id修改可修改值
        public static int ChangeById()
        {
            return Sql.ExecuteUpdata("UPDATE permanent_people_inf_other SET tel='" + Model_infAdd_Other.Tel + "',lv='" + Model_infAdd_Other.Lv + "' WHERE  people_inf_main_id = '" + Model_infAdd_Other.People_inf_main_id + "'");
        }
        //查询x-y年的人口数量（男女）
        public static DataTable findCount(int x,int y,String sex)
        {
            int year = DateTime.Now.Year;
            return Sql.ExecuteQuery("select count(*) from permanent_people_inf where year(date)<='" + (year-x) + "' and year(date)>'" + (year-y) + "' and sex='" + sex+"'");
        }
        public static DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)//PageIndex表示第几页，PageSize表示每页的记录数
        {
            if (PageIndex == 0)
                return dt;//0页代表每页数据，直接返回

            DataTable newdt = dt.Copy();
            newdt.Clear();//copy dt的框架

            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;//源数据记录数小于等于要显示的记录，直接返回dt

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }
            return newdt;
        }
    }
}
