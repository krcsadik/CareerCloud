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
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [Column("Registration_Date")]
        [Display(Name = "Registration Date")]
        [DataMember]
        public DateTime RegistrationDate { get; set; }

        [Column("Company_Website")]
        [Display(Name ="Company Website")]
        [DataType(DataType.Url)]
        [DataMember]
        public String CompanyWebsite { get; set; }

        [Column("Contact_Phone")]
        [Display(Name = "Contact Phone")]
        [DataType(DataType.PhoneNumber)]
        [DataMember]
        public String ContactPhone { get; set; }

        [Column("Contact_Name")]
        [Display(Name = "Contact Name")]
        [DataMember]
        public String ContactName { get; set; }

        [Column("Company_Logo")]
        [Display(Name = "Company Logo")]
        [DataMember]
        public Byte[] CompanyLogo { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get; set; }

        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual ICollection<CompanyJobPoco> CompanyJobs { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }
    }
}
