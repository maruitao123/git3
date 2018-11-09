using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.abstractClass;
using DAL.DbBase;

namespace DAL.factory
{
    class ExecuteUpdataFactory : FactoryInterface
    {
        public DbBaseInterface create()
        {
            abstractClass.ExecuteUpdate eq = new abstractClass.ExecuteUpdate() ;
            return  eq;
        }
    }
}
