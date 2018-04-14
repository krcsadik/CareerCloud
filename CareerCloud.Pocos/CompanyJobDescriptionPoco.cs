using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Company_Jobs_Descriptions")]
    [DataContract]
    public class CompanyJobDescriptionPoco : IPoco
    {
        private Guid varId;
        private Guid varJob;
        private String varJobName;
        private String varJobDescriptions;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("CompanyJobs")]
        [DataMember]
        public Guid Job { get { return varJob; } set { varJob = value; } }

        [Column("Job_Name")]
        [DataMember]
        public String JobName { get { return varJobName; } set { varJobName = value; } }

        [Column("Job_Descriptions")]
        [DataMember]
        public String JobDescriptions { get { return varJobDescriptions; } set { varJobDescriptions = value; } }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }

        public virtual CompanyJobPoco CompanyJobs { get; set; }
    }
}