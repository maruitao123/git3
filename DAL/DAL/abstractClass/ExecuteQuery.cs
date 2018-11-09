using DAL.DbBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Renci.SshNet;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using DAL.StaticConInf;

namespace DAL.abstractClass
{
    class ExecuteQuery : DAL.DbBase.ExecuteQuery
    {
        public override object create(string str)
        {
            con_inf ci = con_inf.getci();
            if (IsImportant(str))
            {
                //计时
                Stopwatch st = new Stopwatch();
                st.Start();


                DataTable dt = new DataTable();

                ci.conn_master.Open();

                ci.myDataAdapter_master.SelectCommand = new MySqlCommand(str, ci.conn_master);

                ci.myDataAdapter_master.Fill(dt);

                ci.conn_master.Close();

                st.Stop();
                return dt;
            }
            else
            {


                Stopwatch st = new Stopwatch();
                st.Start();


                DataTable dt = new DataTable();

                ci.conn_node_1.Open();

                ci.myDataAdapter_node_1.SelectCommand = new MySqlCommand(str, ci.conn_node_1);

                ci.myDataAdapter_node_1.Fill(dt);

                ci.conn_node_1.Close();

                st.Stop();
                return dt;

            }
        }
    }
}
