using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
    public class CompanyJobEducationPoco : IPoco
    {
        private Guid varId;
        private Guid varJob;
        private String varMajor;
        private Int32 varImportance;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Job { get { return varJob; } set { varJob = value; } }
        public String Major { get { return varMajor; } set { varMajor = value; } }
        public Int32 Importance { get { return varImportance; } set { varImportance = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}