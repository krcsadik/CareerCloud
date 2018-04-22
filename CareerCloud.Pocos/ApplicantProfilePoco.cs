using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
using System.Collections.Generic;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
    [DataContract]
    public class ApplicantProfilePoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("SecurityLogins")]
        [ScaffoldColumn(false)]
        [DataMember]
        public Guid Login { get; set; }

        [Column("Current_Salary")]
        [Display(Name="Current Salary")]
        [DataMember]
        public Decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")]
        [Display(Name = "Current Rate")]
        [DataMember]
        public Decimal? CurrentRate { get; set; }

        [DataMember]
        public String Currency { get; set; }

        [Column("Country_Code")]
        [ForeignKey("SystemCountryCodes")]
        [DataMember]
        public String Country { get; set; }

        [Column("State_Province_Code")]
        [DataMember]
        public String Province { get; set; }

        [Column("Street_Address")]
        [DataMember]
        public String Street { get; set; }

        [Column("City_Town")]
        [DataMember]
        public String City { get; set; }

        [Column("Zip_Postal_Code")]
        [Display(Name = "Postal Code")]
        [DataMember]
        public String PostalCode { get; set; }

        [Column("Time_Stamp")]
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual SecurityLoginPoco SecurityLogins { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
    }
}

