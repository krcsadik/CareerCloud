using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills")]
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
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }
        public String Skill { get { return varSkill; } set { varSkill = value; } }
        [Column("Skill_Level")]
        public String SkillLevel { get { return varSkillLevel; } set { varSkillLevel = value; } }
        [Column("Start_Month")]
        public Byte StartMonth { get { return varStartMonth; } set { varStartMonth = value; } }
        [Column("Start_Year")]
        public Int32 StartYear { get { return varStartYear; } set { varStartYear = value; } }
        [Column("End_Month")]
        public Byte EndMonth { get { return varEndMonth; } set { varEndMonth = value; } }
        [Column("End_Year")]
        public Int32 EndYear { get { return varEndYear; } set { varEndYear = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}