using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
    [DataContract]
    public class CompanyJobSkillPoco : IPoco
    {
        private Guid varId;
        private Guid varJob;
        private String varSkill;
        private String varSkillLevel;
        private Int32 varImportance;
        private Byte[] varTimeStamp;

        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("CompanyJobs")]
        [DataMember]
        public Guid Job { get { return varJob; } set { varJob = value; } }

        [DataMember]
        public String Skill { get { return varSkill; } set { varSkill = value; } }

        [Column("Skill_Level")]
        [DataMember]
        public String SkillLevel { get { return varSkillLevel; } set { varSkillLevel = value; } }

        [DataMember]
        public Int32 Importance { get { return varImportance; } set { varImportance = value; } }

        [Column("Time_Stamp")]
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
        public virtual CompanyJobPoco CompanyJobs { get; set; }
    }
}