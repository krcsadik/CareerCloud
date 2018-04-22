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
        [Key]
        [DataMember]
        public String Code { get; set; }

        [Required]
        [DataMember]
        public String Name { get; set; }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
    }
}
