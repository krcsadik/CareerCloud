using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;


namespace CareerCloud.Pocos    
{
    [Table("Applicant_Work_History")]
    [DataContract]
    public class ApplicantWorkHistoryPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("ApplicantProfiles")]
        [DataMember]
        public Guid Applicant { get; set; }

        [Column("Company_Name")]
        [Display(Name = "Company Name")]
        [Required]
        [DataMember]
        public String CompanyName { get; set; }

        [ForeignKey("SystemCountryCodes")]
        [Column("Country_Code")]
        [Display(Name = "Country")]
        [DataMember]
        public String CountryCode { get; set; }

        [Required]
        [DataMember]
        public String Location { get; set; }

        [Column("Job_Title")]
        [Display(Name = "Job Title")]
        [Required]
        [DataMember]
        public String JobTitle { get; set; }

        [Column("Job_Description")]
        [Display(Name = "Job Description")]
        [Required]
        [DataMember]
        public String JobDescription { get; set; }

        [Column("Start_Month")]
        [Display(Name = "Start Month")]
        [Required]
        [DataMember]
        public Int16 StartMonth { get; set; }

        [Column("Start_Year")]
        [Display(Name = "Start Year")]
        [Required]
        [DataMember]
        public Int32 StartYear { get; set; }

        [Column("End_Month")]
        [Display(Name = "End Month")]
        [Required]
        [DataMember]
        public Int16 EndMonth { get; set; }

        [Column("End_Year")]
        [Display(Name = "End Year")]
        [Required]
        [DataMember]
        public Int32 EndYear { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [DataMember]
        [ScaffoldColumn(false)]        
        public Byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }

    }
}