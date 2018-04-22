using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
    [DataContract]
    public class CompanyJobSkillPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("CompanyJobs")]
        [DataMember]
        public Guid Job { get; set; }

        [DataMember]
        public String Skill { get; set; }

        [Column("Skill_Level")]
        [DataMember]
        public String SkillLevel { get; set; }

        [DataMember]
        public Int32 Importance { get; set; }

        [Column("Time_Stamp")]
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        public Byte[] TimeStamp { get; set; }

        public virtual CompanyJobPoco CompanyJobs { get; set; }
    }
}