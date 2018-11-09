using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbBase
{
    //接口类 在这里的主要任务就是用来承接 不同子类的实例
    interface DbBaseInterface
    {
        object create(String str);
    }
}
