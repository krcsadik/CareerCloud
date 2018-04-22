using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills")]
    [DataContract]
    public class ApplicantSkillPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get; set;}

        [Required]
        [DataMember]
        public String Skill { get; set;}

        [Column("Skill_Level")]
        [DataMember]
        [Display(Name = "Skill Level")]
        [Required]
        public String SkillLevel {get; set;}

        [Display(Name = "start Month")]
        [Column("Start_Month")]
        [Required]
        [DataMember]
        public Byte StartMonth { get; set; }

        [Column("Start_Year")]
        [Display(Name = "Start Year")]
        [Required]
        [DataMember]
        public Int32 StartYear { get; set; }

        [Column("End_Month")]
        [Display(Name = "End Month")]
        [Required]
        [DataMember]
        public Byte EndMonth { get; set; }

        [Column("End_Year")]
        [Display(Name = "End Year")]
        [Required]
        [DataMember]
        public Int32 EndYear { get; set; }

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