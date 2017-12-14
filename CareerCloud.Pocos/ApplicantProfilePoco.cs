using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
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
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Login { get { return varLogin; } set { varLogin = value; } }
        [Column("Current_Salary")]
        public Decimal? CurrentSalary { get { return varCurrentSalary; } set { varCurrentSalary = value; } }
        [Column("Current_Rate")]
        public Decimal? CurrentRate { get { return varCurrentRate; } set { varCurrentRate = value; } }
        public String Currency { get { return varCurrency; } set { varCurrency = value; } }
        [Column("Country_Code")]
        public String Country { get { return varCountry; } set { varCountry = value; } }
        [Column("State_Province_Code")]
        public String Province { get { return varProvince; } set { varProvince = value; } }
        [Column("Street_Address")]
        public String Street { get { return varStreet; } set { varStreet = value; } }
        [Column("City_Town")]
        public String City { get { return varCity; } set { varCity = value; } }
        [Column("Zip_Postal_Code")]
        public String PostalCode { get { return varPostalCode; } set { varPostalCode = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}
