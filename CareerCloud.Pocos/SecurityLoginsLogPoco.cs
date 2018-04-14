using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Log")]
    [DataContract]
    public class SecurityLoginsLogPoco : IPoco
    {
        private Guid varId;
        private Guid varLogin;
        private String varSourceIP;
        private DateTime varLogonDate;
        private Boolean varIsSuccesful;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [DataMember]
        [ForeignKey("SecurityLogins")]
        public Guid Login { get { return varLogin; } set { varLogin = value; } }

        [DataMember]
        [Column("Source_IP")]
        [Display(Name = "Source IP")]
        public String SourceIP { get { return varSourceIP; } set { varSourceIP = value; } }

        [DataMember]
        [Column("Logon_Date")]
        [Display(Name = "Logon Date")]
        public DateTime LogonDate { get { return varLogonDate; } set { varLogonDate = value; } }

        [DataMember]
        [Column("Is_Succesful")]
        [Display(Name = "Is Successful")]
        public Boolean IsSuccesful { get { return varIsSuccesful; } set { varIsSuccesful = value; } }

        public virtual SecurityLoginPoco SecurityLogins { get; set; }
    }
}
