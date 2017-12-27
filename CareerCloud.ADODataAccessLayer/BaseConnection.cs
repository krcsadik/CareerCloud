using System;
using System.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
 
    public class BaseConnection
    {
        protected string DBConnectionString  { get; set; }
        public BaseConnection()
        {
            //ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["dbconnection"];
            DBConnectionString = @"Data Source=KARACA_HOME\SQL2016DEV;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //DBConnectionString = ConfigurationManager.AppSettings["dbconnection"];
        }
    }
}
