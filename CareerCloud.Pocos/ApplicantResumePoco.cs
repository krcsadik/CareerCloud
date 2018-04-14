using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Resumes")]
    [DataContract]
    public class ApplicantResumePoco : IPoco
    {
        private Guid varId;
        private Guid varApplicant;
        private String varResume;
        private DateTime? varLastUpdated;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }

        [Required]
        [DataMember]
        public String Resume { get { return varResume; } set { varResume = value; } }

        [Column("Last_Updated")]
        [Display(Name = "Last Updated")]
        [DataMember]
        public DateTime? LastUpdated { get { return varLastUpdated; } set { varLastUpdated= value; } }

        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
    }
}
