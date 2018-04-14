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
        private Guid varId;
        private Guid varCompany;
        private DateTime varProfileCreated;
        private Boolean varIsInactive;
        private Boolean varIsCompanyHidden;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("CompanyProfiles")]
        [DataMember]
        public Guid Company { get { return varCompany; } set { varCompany = value; } }

        [Column("Profile_Created")]
        [Display(Name="Posting Date")]
        [DataMember]
        public DateTime ProfileCreated { get { return varProfileCreated; } set { varProfileCreated = value; } }

        [Column("Is_Inactive")]
        [DataMember]
        public Boolean IsInactive { get { return varIsInactive; } set { varIsInactive = value; } }

        [Column("Is_Company_Hidden")]
        [DataMember]
        public Boolean IsCompanyHidden { get { return varIsCompanyHidden; } set { varIsCompanyHidden = value; } }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }

        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual ICollection<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public virtual ICollection<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
        public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobsDescriptions { get; set; }

    }
}