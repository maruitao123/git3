using DAL.DbBase;
using DAL.StaticConInf;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.abstractClass
{
    class ExecuteUpdate : DAL.DbBase.ExecuteUpdate
    {
        
        public override object create(String sqlStr)
        {
            con_inf ci = con_inf.getci();
            int count = 0;
            ci.conn_master.Open();
            MySqlCommand cmd = new MySqlCommand(sqlStr, ci.conn_master);
            count = cmd.ExecuteNonQuery();
            ci.conn_master.Close();
            return count;
        }
    }
}
