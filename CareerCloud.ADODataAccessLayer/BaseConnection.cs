using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    
    public class BaseConnection
    {
        protected string DBConnectionString  { get; set; }
        public BaseConnection()
        {
            DBConnectionString =    System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }
    }
}
