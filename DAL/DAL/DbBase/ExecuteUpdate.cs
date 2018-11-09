using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbBase
{
    abstract class ExecuteUpdate : DbBaseInterface
    {       
        public abstract object create(String str);
    }
}
