using DAL.DbBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.factory
{
    interface FactoryInterface
    {
        DbBaseInterface create();
    }
}
