using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = Sql.ExecuteQuery("SELECT * from permanent_people_inf where sex = '男'");
            MessageBox.Show(dt.Rows[0][0].ToString());

        }
    }
}
