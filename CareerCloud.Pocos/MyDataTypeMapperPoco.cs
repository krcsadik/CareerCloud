using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{

    public class MyDataTypeMapperPoco 
    {
        private String varSQLServerDatabaseEnginetype;
        private String varNETFrameworktype;
        [Column("SQLServer_Database_Engine_type")]
        public String SQLServerDatabaseEnginetype { get { return varSQLServerDatabaseEnginetype; } set { varSQLServerDatabaseEnginetype = value; } }
        [Column("NET_Framework_type")]
        public String NETFrameworktype { get { return varNETFrameworktype; } set { varNETFrameworktype = value; } }
    }
}