using DAL.DbBase;
using DAL.factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Sql
    {

        public static int ExecuteUpdata(String sql) {
            FactoryInterface fi = BuildClass.build("ExecuteUpdata");//BuildClass.build("ExecuteQuery");
            return (int)fi.create().create(sql);
        }
        public static DataTable ExecuteQuery(String sql)
        {
            FactoryInterface fi = BuildClass.build("ExecuteQuery");//BuildClass.build("ExecuteQuery");
            return (DataTable)fi.create().create(sql);
        }
    }
}
