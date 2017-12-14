using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco 
    {
        private String varCode;
        private String varName;
        [Key]
        public String Code { get { return varCode; } set { varCode = value; } }
        public String Name { get { return varName; } set { varName = value; } }
    }
}
