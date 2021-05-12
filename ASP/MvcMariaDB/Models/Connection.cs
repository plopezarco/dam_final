using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcMariaDB.Models
{
    public class Connection
    {
        public static string connString = ConfigurationManager.ConnectionStrings["GenshinConnectionString"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(connString);
        public static string Connect()
        {
            string connection_error = "";
            try { conn.Open(); }
            catch (Exception ex)
            { connection_error = ex.Message; }
            return connection_error;
        }
        public static string Disconnect()
        {
            string connection_error = "";
            try { conn.Close(); }
            catch (Exception ex)
            { connection_error = ex.Message; }
            return connection_error;
        }

    }
}