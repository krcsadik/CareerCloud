using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
using System.Collections.Generic;
namespace CareerCloud.Pocos     
{
    [Table("Company_Profiles")]
    [DataContract]
    public class CompanyProfilePoco : IPoco
    {
        private Guid varId;
        private DateTime varRegistrationDate;
        private String varCompanyWebsite;
        private String varContactPhone;
        private String varContactName;
        private Byte[] varCompanyLogo;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [Column("Registration_Date")]
        [Display(Name = "Registration Date")]
        [DataMember]
        public DateTime RegistrationDate { get { return varRegistrationDate; } set { varRegistrationDate = value; } }

        [Column("Company_Website")]
        [Display(Name ="Company Website")]
        [DataType(DataType.Url)]
        [DataMember]
        public String CompanyWebsite { get { return varCompanyWebsite; } set { varCompanyWebsite = value; } }

        [Column("Contact_Phone")]
        [Display(Name = "Contact Phone")]
        [DataType(DataType.PhoneNumber)]
        [DataMember]
        public String ContactPhone { get { return varContactPhone; } set { varContactPhone = value; } }

        [Column("Contact_Name")]
        [Display(Name = "Contact Name")]
        [DataMember]
        public String ContactName { get { return varContactName; } set { varContactName = value; } }

        [Column("Company_Logo")]
        [Display(Name = "Company Logo")]
        [DataMember]
        public Byte[] CompanyLogo { get { return varCompanyLogo; } set { varCompanyLogo = value; } }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }

        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual ICollection<CompanyJobPoco> CompanyJobs { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }
    }
}
