using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Log")]
    public class SecurityLoginsLogPoco : IPoco
    {
        private Guid varId;
        private Guid varLogin;
        private String varSourceIP;
        private DateTime varLogonDate;
        private Boolean varIsSuccesful;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Login { get { return varLogin; } set { varLogin = value; } }
        [Column("Source_IP")]
        public String SourceIP { get { return varSourceIP; } set { varSourceIP = value; } }
        [Column("Logon_Date")]
        public DateTime LogonDate { get { return varLogonDate; } set { varLogonDate = value; } }
        [Column("Is_Succesful")]
        public Boolean IsSuccesful { get { return varIsSuccesful; } set { varIsSuccesful = value; } }
    }
}
