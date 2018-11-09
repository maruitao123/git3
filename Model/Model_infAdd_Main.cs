using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model
{
    public static class Model_infAdd_Main
    {
        static bool mark = true;
        static String name = "";
        static String sex = "";
        //省市区
        static String ad_1 = "";
        static String ad_2 = "";
        static String ad_3 = "";

        static String boolType = "";
        static String peopleId = "";
        static String date = "";
        static String type = "";
        static String age_1 = "";
        static String age_2 = "";
        public static void clear() {
            //先将实体类全部制空
            name = "";
            ad_1 = "";
            ad_2 = "";
            ad_3 = "";
            boolType = "";
            date = "";
            peopleId = "";
            sex = "";
            type = "";
            age_1 = "";
            age_2 = "";
        }
        static public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if ((value.Trim() == null || value.Trim() == "" || value.Length >= 10)&&Mark==true)
                {
                    MessageBox.Show("姓名为空或不符合规定");
                    Mark = false;
                }
                else
                {
                    name = value;
                }
            }
        }

        static public string Sex
        {
            get
            {
                return sex;
            }

            set
            {
                if ((value.Trim() == null || value.Trim() == "" || value.Length >= 10)&& Mark == true)
                {
                    MessageBox.Show("性别为空或不符合规定");
                    Mark = false;
                }
                else
                {
                    sex = value;
                }
            }
        }

        static public string Ad_1
        {
            get
            {
                return ad_1;
            }

            set
            {
                if ((value.Trim() == null || value.Trim() == "" || value.Length >= 50)&& Mark == true)
                {
                    MessageBox.Show("地址为空或不符合规定");
                    Mark = false;
                }
                else
                {
                    ad_1 = value;
                }
            }
        }

        static public string Ad_2
        {
            get
            {
                return ad_2;
            }

            set
            {
                if ((value.Trim() == null || value.Trim() == "" || value.Length >= 50)&& Mark == true)
                {
                    MessageBox.Show("地址为空或不符合规定");
                    Mark = false;
                }
                else
                {
                    ad_2 = value;
                }
            }
        }

        static public string Ad_3
        {
            get
            {
                return ad_3;
            }

            set
            {
                if ((value.Trim() == null || value.Trim() == "" || value.Length >= 50)&& Mark == true)
                {
                    MessageBox.Show("地址为空或不符合规定");
                    Mark = false;
                }
                else
                {
                    ad_3 = value;
                }
            }
        }

        static public string BoolType
        {
            get
            {
                return boolType;
            }

            set
            {
                if ((value.Trim() == null || value.Trim() == "" || value.Length >= 10)&& Mark == true)
                {
                    MessageBox.Show("血型为空或不符合规定");
                    Mark = false;
                }
                else
                {
                    boolType = value;
                }
            }
        }

        static public string PeopleId
        {
            get
            {
                return peopleId;
            }

            set
            {
                if ((value.Trim() == null || value.Trim() == "" || value.Length >= 19)&& Mark == true)
                {
                    MessageBox.Show("身份证为空或不符合规定");
                    Mark = false;
                }
                else
                {
                    peopleId = value;
                }
            }
        }

        static public string Date
        {
            get
            {
                return date;
            }

            set
            {
                if ((value.Trim() == null || value.Trim() == "")&& Mark == true)
                {
                    MessageBox.Show("日期为空或不符合规定");
                    Mark = false;
                }
                else
                {
                    date = value;
                }
            }
        }
        static public string Type
        {
            get
            {
                return type;
            }

            set
            {
                if ((value.Trim() == null || value.Trim() == "")&& Mark == true)
                {
                    MessageBox.Show("民族为空或不符合规定");
                    Mark = false;
                }
                else
                {
                    type = value;
                }
            }
        }

        public static bool Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }

        public static string Age_1
        {
            get
            {
                return age_1;
            }

            set
            {
                age_1 = value;
            }
        }

        public static string Age_2
        {
            get
            {
                return age_2;
            }

            set
            {
                age_2 = value;
            }
        }
        // String 
    }
}
