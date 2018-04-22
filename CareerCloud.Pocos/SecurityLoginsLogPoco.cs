using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Log")]
    [DataContract]
    public class SecurityLoginsLogPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        [ForeignKey("SecurityLogins")]
        public Guid Login { get; set; }

        [DataMember]
        [Column("Source_IP")]
        [Display(Name = "Source IP")]
        public String SourceIP { get; set; }

        [DataMember]
        [Column("Logon_Date")]
        [Display(Name = "Logon Date")]
        public DateTime LogonDate { get; set; }

        [DataMember]
        [Column("Is_Succesful")]
        [Display(Name = "Is Successful")]
        public Boolean IsSuccesful { get; set; }

        public virtual SecurityLoginPoco SecurityLogins { get; set; }
    }
}
