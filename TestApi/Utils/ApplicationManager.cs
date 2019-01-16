using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestApi.Utils
{
    public class ApplicationManager
    {
        public static SqlConnection getDb()
        {
            return new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial Catalog=dofactory;Persist Security Info=True;User ID=sa;Password=123");
        }
    }
}