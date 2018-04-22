using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Educations")]
    [DataContract]
    public class ApplicantEducationPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get; set; }

        [Required]
        [DataMember]
        public String Major { get; set; }

        [Column("Certificate_Diploma")]
        [DataMember]
        [Display(Name = "Certificate / Diploma")]
        public String CertificateDiploma { get; set; }

        [Column("Start_Date")]
        [Display(Name = "Start Date")]
        [DataMember]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Completion Date")]
        [Column("Completion_Date")]
        [DataMember]
        public DateTime? CompletionDate { get; set; }

        [Display(Name = "Completion Percent")]
        [Column("Completion_Percent")]
        [DataMember]
        public Byte? CompletionPercent { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
    }
}
