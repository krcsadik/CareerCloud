using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Company_Jobs_Descriptions")]
    [DataContract]
    public class CompanyJobDescriptionPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("CompanyJobs")]
        [DataMember]
        public Guid Job { get; set; }

        [Column("Job_Name")]
        [DataMember]
        public String JobName { get; set; }

        [Column("Job_Descriptions")]
        [DataMember]
        public String JobDescriptions { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get; set; }

        public virtual CompanyJobPoco CompanyJobs { get; set; }
    }
}