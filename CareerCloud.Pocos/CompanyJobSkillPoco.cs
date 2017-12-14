using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
    public class CompanyJobSkillPoco : IPoco
    {
        private Guid varId;
        private Guid varJob;
        private String varSkill;
        private String varSkillLevel;
        private Int32 varImportance;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Job { get { return varJob; } set { varJob = value; } }
        public String Skill { get { return varSkill; } set { varSkill = value; } }
        [Column("Skill_Level")]
        public String SkillLevel { get { return varSkillLevel; } set { varSkillLevel = value; } }
        public Int32 Importance { get { return varImportance; } set { varImportance = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}