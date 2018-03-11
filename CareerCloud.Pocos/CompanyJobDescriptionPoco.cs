using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Company_Jobs_Descriptions")]
    public class CompanyJobDescriptionPoco : IPoco
    {
        private Guid varId;
        private Guid varJob;
        private String varJobName;
        private String varJobDescriptions;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        [ForeignKey("CompanyJobs")]
        public Guid Job { get { return varJob; } set { varJob = value; } }
        [Column("Job_Name")]
        public String JobName { get { return varJobName; } set { varJobName = value; } }
        [Column("Job_Descriptions")]
        public String JobDescriptions { get { return varJobDescriptions; } set { varJobDescriptions = value; } }
        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
        public virtual CompanyJobPoco CompanyJobs { get; set; }
    }
}