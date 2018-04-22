using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    [DataContract]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get; set; }

        [ForeignKey("CompanyJobs")]
        [DataMember]
        public Guid Job { get; set; }

        [Column("Application_Date")]
        [Display(Name = "Application Date")]
        [Required]
        [DataMember]
        public DateTime ApplicationDate { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get; set;
        }
        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
        public virtual CompanyJobPoco CompanyJobs { get; set; }
    }
}