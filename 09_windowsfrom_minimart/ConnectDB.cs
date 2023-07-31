using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//กำหนดการใข้คลาสการเชื่อมต่่อ sql server

namespace _09_windowsfrom_minimart
{
    class ConnectDB
    {
        public SqlConnection SqlCon()
        {
            string server = "";//ชื่อ server
            string strDb = @"MiniMart";
            string strConn = string.Format(@"Data Source={0};Initial Catalog={1};"
                                             + "Integrated Security=True", server, strDb);

            return new SqlConnection(strConn);
        }
    }
}
