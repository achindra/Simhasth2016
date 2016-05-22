using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ResourceManager.WebAPI
{
    public class Constants
    {
        private static string _connectionString;

        public static string DbConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
                }
                return _connectionString;
            }
        }
    }
}