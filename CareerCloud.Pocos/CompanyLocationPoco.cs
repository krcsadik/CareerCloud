using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    [DataContract]
    public class CompanyLocationPoco : IPoco
    {
        private Guid varId;
        private Guid varCompany;
        private String varCountryCode;
        private String varProvince;
        private String varStreet;
        private String varCity;
        private String varPostalCode;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("CompanyProfiles")]
        [DataMember]
        public Guid Company { get { return varCompany; } set { varCompany = value; } }

        [Column("Country_Code")]
        [DataMember]
        public String CountryCode { get { return varCountryCode; } set { varCountryCode = value; } }

        [Column("State_Province_Code")]
        [DataMember]
        public String Province{ get { return varProvince; } set { varProvince = value; } }

        [Column("Street_Address")]
        [DataMember]
        public String Street { get { return varStreet; } set { varStreet = value; } }

        [Column("City_Town")]
        [DataMember]
        public String City { get { return varCity; } set { varCity = value; } }

        [Column("Zip_Postal_Code")]
        [DataMember]
        [Display(Name = "Postal Code")]
        public String PostalCode { get { return varPostalCode; } set { varPostalCode = value; } }

        [Column("Time_Stamp")]
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }

        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
    }
}