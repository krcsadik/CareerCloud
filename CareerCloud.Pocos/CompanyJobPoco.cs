using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
using System.Collections.Generic;
namespace CareerCloud.Pocos
{
    [Table("Company_Jobs")]
    [DataContract]
    public class CompanyJobPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("CompanyProfiles")]
        [DataMember]
        public Guid Company { get; set; }

        [Column("Profile_Created")]
        [Display(Name="Posting Date")]
        [DataMember]
        public DateTime ProfileCreated { get; set; }

        [Column("Is_Inactive")]
        [DataMember]
        public Boolean IsInactive { get; set; }

        [Column("Is_Company_Hidden")]
        [DataMember]
        public Boolean IsCompanyHidden { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual ICollection<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public virtual ICollection<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
        public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobsDescriptions { get; set; }

    }
}