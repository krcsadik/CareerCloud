using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
    [DataContract]
    public class CompanyJobEducationPoco : IPoco
    {
        private Guid varId;
        private Guid varJob;
        private String varMajor;
        private Int16 varImportance;
        private Byte[] varTimeStamp;

        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("CompanyJobs")]
        [DataMember]
        public Guid Job { get { return varJob; } set { varJob = value; } }

        [DataMember]
        public String Major { get { return varMajor; } set { varMajor = value; } }

        [DataMember]
        public Int16 Importance { get { return varImportance; } set { varImportance = value; } }

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