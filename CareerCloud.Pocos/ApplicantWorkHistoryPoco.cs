using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;


namespace CareerCloud.Pocos    
{
    [Table("Applicant_Work_History")]
    [DataContract]
    public class ApplicantWorkHistoryPoco : IPoco
    {
        private Guid varId;
        private Guid varApplicant;
        private String varCompanyName;
        private String varCountryCode;
        private String varLocation;
        private String varJobTitle;
        private String varJobDescription;
        private Int16 varStartMonth;
        private Int32 varStartYear;
        private Int16 varEndMonth;
        private Int32 varEndYear;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }

        [Column("Company_Name")]
        [Display(Name = "Company Name")]
        [Required]
        [DataMember]
        public String CompanyName { get { return varCompanyName; } set { varCompanyName = value; } }

        [ForeignKey("SystemCountryCodes")]
        [Column("Country_Code")]
        [Display(Name = "Country")]
        [DataMember]
        public String CountryCode { get { return varCountryCode; } set { varCountryCode = value; } }

        [Required]
        [DataMember]
        public String Location { get { return varLocation; } set { varLocation = value; } }

        [Column("Job_Title")]
        [Display(Name = "Job Title")]
        [Required]
        [DataMember]
        public String JobTitle { get { return varJobTitle; } set { varJobTitle = value; } }

        [Column("Job_Description")]
        [Display(Name = "Job Description")]
        [Required]
        [DataMember]
        public String JobDescription { get { return varJobDescription; } set { varJobDescription = value; } }

        [Column("Start_Month")]
        [Display(Name = "Start Month")]
        [Required]
        [DataMember]
        public Int16 StartMonth { get { return varStartMonth; } set { varStartMonth = value; } }

        [Column("Start_Year")]
        [Display(Name = "Start Year")]
        [Required]
        [DataMember]
        public Int32 StartYear { get { return varStartYear; } set { varStartYear = value; } }

        [Column("End_Month")]
        [Display(Name = "End Month")]
        [Required]
        [DataMember]
        public Int16 EndMonth { get { return varEndMonth; } set { varEndMonth = value; } }

        [Column("End_Year")]
        [Display(Name = "End Year")]
        [Required]
        [DataMember]
        public Int32 EndYear { get { return varEndYear; } set { varEndYear = value; } }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [DataMember]
        [ScaffoldColumn(false)]        
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }

        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }

    }
}