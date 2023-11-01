using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KICS.Content.Utils
{
    public class AppSettings
    {
        public static SqlConnection Connection()
        {
            string conn = @"Data Source=.;Initial Catalog=KICS;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(conn);
            return sqlConnection;
        }
    }
}