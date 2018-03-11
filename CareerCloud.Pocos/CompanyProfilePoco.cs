using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace CareerCloud.Pocos     
{
    [Table("Company_Profiles")]
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
        public Guid Id { get { return varId; } set { varId = value; } }
        [Column("Registration_Date")]
        public DateTime RegistrationDate { get { return varRegistrationDate; } set { varRegistrationDate = value; } }
        [Column("Company_Website")]
        public String CompanyWebsite { get { return varCompanyWebsite; } set { varCompanyWebsite = value; } }
        [Column("Contact_Phone")]
        public String ContactPhone { get { return varContactPhone; } set { varContactPhone = value; } }
        [Column("Contact_Name")]
        public String ContactName { get { return varContactName; } set { varContactName = value; } }
        [Column("Company_Logo")]
        public Byte[] CompanyLogo { get { return varCompanyLogo; } set { varCompanyLogo = value; } }
        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual ICollection<CompanyJobPoco> ComspanyJobs { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }
    }
}
