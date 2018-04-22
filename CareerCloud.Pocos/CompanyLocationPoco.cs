using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    [DataContract]
    public class CompanyLocationPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("CompanyProfiles")]
        [DataMember]
        public Guid Company { get; set; }

        [Column("Country_Code")]
        [DataMember]
        public String CountryCode { get; set; }

        [Column("State_Province_Code")]
        [DataMember]
        public String Province{ get; set; }

        [Column("Street_Address")]
        [DataMember]
        public String Street { get; set; }

        [Column("City_Town")]
        [DataMember]
        public String City { get; set; }

        [Column("Zip_Postal_Code")]
        [DataMember]
        [Display(Name = "Postal Code")]
        public String PostalCode { get; set; }

        [Column("Time_Stamp")]
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        public Byte[] TimeStamp { get; set; }

        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
    }
}