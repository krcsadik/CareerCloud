using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        private Guid varId;
        private Guid varCompany;
        private String varCountryCode;
        private String varStateProvinceCode;
        private String varStreetAddress;
        private String varCityTown;
        private String varZipPostalCode;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Company { get { return varCompany; } set { varCompany = value; } }
        [Column("Country_Code")]
        public String CountryCode { get { return varCountryCode; } set { varCountryCode = value; } }
        [Column("State_Province_Code")]
        public String StateProvinceCode { get { return varStateProvinceCode; } set { varStateProvinceCode = value; } }
        [Column("Street_Address")]
        public String StreetAddress { get { return varStreetAddress; } set { varStreetAddress = value; } }
        [Column("City_Town")]
        public String CityTown { get { return varCityTown; } set { varCityTown = value; } }
        [Column("Zip_Postal_Code")]
        public String ZipPostalCode { get { return varZipPostalCode; } set { varZipPostalCode = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}