using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.StaticConInf
{
    public  class con_inf
    {
        //主服务器连接参数
        public string SSHHost_master = "132.232.28.129";
        public int SSHPort_master = 22;
        public string SSHUser_master = "root";
        public string SSHPassword_master = "mrt12345678.";
        public string SqlIPA_master = "127.0.0.1";
        public string SqlHost_master = "172.27.0.3";
        public uint Sqlport_master = 3306;
        public string SqlConn_master;
        public PasswordConnectionInfo connectionInfo_master;
        public SshClient client_master;
        public ForwardedPortLocal portFwdL_master;
        public MySqlConnection conn_master;
        public MySqlDataAdapter myDataAdapter_master;
        //从服务器参数
        public string SSHHost_node_1 = "118.24.58.139";
        public int SSHPort_node_1 = 22;
        public string SSHUser_node_1 = "root";
        public string SSHPassword_node_1 = "mrt12345678.";
        public string SqlIPA_node_1 = "127.0.0.1";
        public string SqlHost_node_1 = "10.100.100.6";
        public uint Sqlport_node_1 = 3305;
        public string SqlConn_node_1;
        public PasswordConnectionInfo connectionInfo_node_1;
        public SshClient client_node_1;
        public ForwardedPortLocal portFwdL_node_1;
        public MySqlConnection conn_node_1;
        public MySqlDataAdapter myDataAdapter_node_1;
        private con_inf()
        {
            //主
            SqlConn_master = "Database=person;Data Source=" + SqlIPA_master + ";Port=" + Sqlport_master + ";User Id=itoffice;Password=mrt123A/;CharSet=utf8";//这里的密码root是登陆数据库密码
            connectionInfo_master = new PasswordConnectionInfo(SSHHost_master, SSHPort_master, SSHUser_master, SSHPassword_master);
            client_master = new SshClient(connectionInfo_master);

            client_master.Connect();
            portFwdL_master = new ForwardedPortLocal(SqlIPA_master, Sqlport_master, SqlHost_master, Sqlport_master); //映射到本地端口
            client_master.AddForwardedPort(portFwdL_master);

                portFwdL_master.Start();
           


            conn_master = new MySqlConnection(SqlConn_master);
            myDataAdapter_master = new MySqlDataAdapter();
            //从
            SqlConn_node_1 = "Database=person;Data Source=" + SqlIPA_node_1 + ";Port=" + Sqlport_node_1 + ";User Id=itoffice;Password=mrt123A/;CharSet=utf8";//这里的密码root是登陆数据库密码
            connectionInfo_node_1 = new PasswordConnectionInfo(SSHHost_node_1, SSHPort_node_1, SSHUser_node_1, SSHPassword_node_1);
            client_node_1 = new SshClient(connectionInfo_node_1);

            client_node_1.Connect();
            portFwdL_node_1 = new ForwardedPortLocal(SqlIPA_node_1, Sqlport_node_1, SqlHost_node_1, Sqlport_node_1); //映射到本地端口
            client_node_1.AddForwardedPort(portFwdL_node_1);

                portFwdL_node_1.Start();


            conn_node_1 = new MySqlConnection(SqlConn_node_1);
            myDataAdapter_node_1 = new MySqlDataAdapter();

        }

        private static con_inf ci = new con_inf();

        public static con_inf getci()
        {
            return ci;
        }
    }
}
