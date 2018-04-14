using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Educations")]
    [DataContract]
    public class ApplicantEducationPoco : IPoco
    {
        private Guid varId;
        private Guid varApplicant;
        private String varMajor;
        private String varCertificateDiploma;
        private DateTime? varStartDate;
        private DateTime? varCompletionDate;
        private Byte? varCompletionPercent;
        private Byte[] varTimeStamp;

        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }

        [Required]
        [DataMember]
        public String Major { get { return varMajor; } set { varMajor = value; } }

        [Column("Certificate_Diploma")]
        [DataMember]
        [Display(Name = "Certificate / Diploma")]
        public String CertificateDiploma { get { return varCertificateDiploma; } set { varCertificateDiploma = value; } }

        [Column("Start_Date")]
        [Display(Name = "Start Date")]
        [DataMember]
        public DateTime? StartDate { get { return varStartDate; } set { varStartDate = value; } }

        [Display(Name = "Completion Date")]
        [Column("Completion_Date")]
        [DataMember]
        public DateTime? CompletionDate { get { return varCompletionDate; } set { varCompletionDate = value; } }

        [Display(Name = "Completion Percent")]
        [Column("Completion_Percent")]
        [DataMember]
        public Byte? CompletionPercent { get { return varCompletionPercent; } set { varCompletionPercent = value; } }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }

        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
    }
}
