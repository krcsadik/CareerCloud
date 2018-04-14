using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    [DataContract]
    public class ApplicantJobApplicationPoco : IPoco
    {
        private Guid varId;
        private Guid varApplicant;
        private Guid varJob;
        private DateTime varApplicationDate;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }

        [ForeignKey("CompanyJobs")]
        [DataMember]
        public Guid Job { get { return varJob; } set { varJob = value; } }

        [Column("Application_Date")]
        [Display(Name = "Application Date")]
        [Required]
        [DataMember]
        public DateTime ApplicationDate { get { return varApplicationDate; } set { varApplicationDate = value; } }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
        public virtual CompanyJobPoco CompanyJobs { get; set; }
    }
}