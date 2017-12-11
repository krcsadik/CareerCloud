using System;
namespace CareerCloud.Pocos
{
    public class ApplicantSkillPoco
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
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }
        public String Skill { get { return varSkill; } set { varSkill = value; } }
        public String SkillLevel { get { return varSkillLevel; } set { varSkillLevel = value; } }
        public Byte StartMonth { get { return varStartMonth; } set { varStartMonth = value; } }
        public Int32 StartYear { get { return varStartYear; } set { varStartYear = value; } }
        public Byte EndMonth { get { return varEndMonth; } set { varEndMonth = value; } }
        public Int32 EndYear { get { return varEndYear; } set { varEndYear = value; } }
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}