using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
    [DataContract]
    public class CompanyJobEducationPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("CompanyJobs")]
        [DataMember]
        public Guid Job { get; set; }

        [DataMember]
        public String Major { get; set; }

        [DataMember]
        public Int16 Importance { get; set; }

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