using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.abstractClass;
using Renci.SshNet;
using MySql.Data.MySqlClient;

namespace DAL.DbBase
{
    abstract class ExecuteQuery : DbBaseInterface
    {
       
        public bool IsImportant(String sql)
        {
            String[] tempStr = sql.Split(' ');
            foreach (String s in tempStr)
            {
                //如果为读则严格模式
                if (s.ToLower().Equals("inner") && s.ToLower().Equals("update") && s.ToLower().Equals("create") && s.ToLower().Equals("alter"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public abstract object create(String str);

    }
}
