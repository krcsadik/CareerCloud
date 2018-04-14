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
        private Guid varId;
        private Guid varLogin;
        private Decimal? varCurrentSalary;
        private Decimal? varCurrentRate;
        private String varCurrency;
        private String varCountry;
        private String varProvince;
        private String varStreet;
        private String varCity;
        private String varPostalCode;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("SecurityLogins")]
        [ScaffoldColumn(false)]
        [DataMember]
        public Guid Login { get { return varLogin; } set { varLogin = value; } }

        [Column("Current_Salary")]
        [Display(Name="Current Salary")]
        [DataMember]
        public Decimal? CurrentSalary { get { return varCurrentSalary; } set { varCurrentSalary = value; } }

        [Column("Current_Rate")]
        [Display(Name = "Current Rate")]
        [DataMember]
        public Decimal? CurrentRate { get { return varCurrentRate; } set { varCurrentRate = value; } }

        [DataMember]
        public String Currency { get { return varCurrency; } set { varCurrency = value; } }

        [Column("Country_Code")]
        [ForeignKey("SystemCountryCodes")]
        [DataMember]
        public String Country { get { return varCountry; } set { varCountry = value; } }

        [Column("State_Province_Code")]
        [DataMember]
        public String Province { get { return varProvince; } set { varProvince = value; } }

        [Column("Street_Address")]
        [DataMember]
        public String Street { get { return varStreet; } set { varStreet = value; } }

        [Column("City_Town")]
        [DataMember]
        public String City { get { return varCity; } set { varCity = value; } }

        [Column("Zip_Postal_Code")]
        [Display(Name = "Postal Code")]
        [DataMember]
        public String PostalCode { get { return varPostalCode; } set { varPostalCode = value; } }

        [Column("Time_Stamp")]
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
        public virtual ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual SecurityLoginPoco SecurityLogins { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
    }
}

