using DAL.abstractClass;
using DAL.DbBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.factory
{
    class ExecuteQueryFactory:FactoryInterface
    {
       
        public DbBaseInterface create(){
            DbBaseInterface eq = new abstractClass.ExecuteQuery();
            return eq;
        }
    }
}
