using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Resumes")]
    [DataContract]
    public class ApplicantResumePoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get; set; }

        [Required]
        [DataMember]
        public String Resume { get; set; }

        [Column("Last_Updated")]
        [Display(Name = "Last Updated")]
        [DataMember]
        public DateTime? LastUpdated { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
    }
}
