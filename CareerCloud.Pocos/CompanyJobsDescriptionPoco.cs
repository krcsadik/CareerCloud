using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Company_Jobs_Descriptions")]
    public class CompanyJobsDescriptionPoco : IPoco
    {
        private Guid varId;
        private Guid varJob;
        private String varJobName;
        private String varJobDescriptions;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Job { get { return varJob; } set { varJob = value; } }
        [Column("Job_Name")]
        public String JobName { get { return varJobName; } set { varJobName = value; } }
        [Column("Job_Descriptions")]
        public String JobDescriptions { get { return varJobDescriptions; } set { varJobDescriptions = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}