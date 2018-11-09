using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class Model_infAdd_Other
    {
        private static String tel="";
        private static String healthy="";
        private static String lv="";
        private static String people_inf_main_id = "";
        public static string Tel
        {
            get
            {
                return tel;
            }

            set
            {
                tel = value;
            }
        }

        public static string Healthy
        {
            get
            {
                return healthy;
            }

            set
            {
                healthy = value;
            }
        }

        public static string Lv
        {
            get
            {
                return lv;
            }

            set
            {
                lv = value;
            }
        }

        public static string People_inf_main_id
        {
            get
            {
                return people_inf_main_id;
            }

            set
            {
                people_inf_main_id = value;
            }
        }
    }
}
