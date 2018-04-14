using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills")]
    [DataContract]
    public class ApplicantSkillPoco : IPoco
    {
        private Guid varId;
        private Guid varApplicant;
        private String varSkill;
        private String varSkillLevel;
        private Byte varStartMonth;
        private Int32 varStartYear;
        private Byte varEndMonth;
        private Int32 varEndYear;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }

        [Required]
        [DataMember]
        public String Skill { get { return varSkill; } set { varSkill = value; } }

        [Column("Skill_Level")]
        [DataMember]
        [Display(Name = "Skill Level")]
        [Required]
        public String SkillLevel { get { return varSkillLevel; } set { varSkillLevel = value; } }

        [Display(Name = "start Month")]
        [Column("Start_Month")]
        [Required]
        [DataMember]
        public Byte StartMonth { get { return varStartMonth; } set { varStartMonth = value; } }

        [Column("Start_Year")]
        [Display(Name = "Start Year")]
        [Required]
        [DataMember]
        public Int32 StartYear { get { return varStartYear; } set { varStartYear = value; } }

        [Column("End_Month")]
        [Display(Name = "End Month")]
        [Required]
        [DataMember]
        public Byte EndMonth { get { return varEndMonth; } set { varEndMonth = value; } }

        [Column("End_Year")]
        [Display(Name = "End Year")]
        [Required]
        [DataMember]
        public Int32 EndYear { get { return varEndYear; } set { varEndYear = value; } }

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