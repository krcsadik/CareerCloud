using System;
using System.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
 
    public class BaseConnection
    {
        protected string DBConnectionString  { get; set; }
        public BaseConnection()
        {
            DBConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }
    }
}
