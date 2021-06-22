using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    class Connection
    {
        public static SqlConnection cn;
        public static int tableIndex;

        public Connection()
        {
            startConnection();
        }

        public static void startConnection()
        {
            cn = new SqlConnection("data source= tcp:mednat.ieeta.pt\\SQLSERVER,8101;initial catalog= p6g5; uid=p6g5; password=1241768583@BD");

        }


        public static bool verifySGBDConnection()
        {
            if (cn == null)
                startConnection();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            return cn.State == ConnectionState.Open;
        }
    }
}
