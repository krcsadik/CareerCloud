using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
using System.Collections.Generic;
namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
    [DataContract]
    public class SystemCountryCodePoco 
    {
        private String varCode;
        private String varName;
        [Key]
        [DataMember]
        public String Code { get { return varCode; } set { varCode = value; } }

        [Required]
        [DataMember]
        public String Name { get { return varName; } set { varName = value; } }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
    }
}
