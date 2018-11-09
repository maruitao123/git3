using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbBase
{
    class DbBaseClassName
    {
        public static Dictionary<string, string> oscar = new Dictionary<string, string>();
        static DbBaseClassName() {
            oscar.Add("ExecuteQuery", "DAL.factory.ExecuteQueryFactory");
            oscar.Add("ExecuteUpdata", "DAL.factory.ExecuteUpdataFactory");
        }
        public static void setPath(String name,String path) {
            oscar.Add(name, path);
        }
        public static String getPath(String name) {

            return oscar[name];
        }
    }
}
