using DAL.DbBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.factory
{
    //利用反射创建对象
    class BuildClass
    {
        public static FactoryInterface build(String name) {
            //FactoryInterface fi = new ExecuteQueryFactory(); //"DAL.factory.ExecuteQueryFactory";
            //return fi; ;
            Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
            return (FactoryInterface)assembly.CreateInstance(DbBaseClassName.getPath(name));
        }
    }
}
