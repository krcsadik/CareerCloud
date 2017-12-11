using System;
namespace CareerCloud.Pocos
{
    public class ApplicantProfilePoco
    {
        private Guid varId;
        private Guid varLogin;
        private Decimal varCurrentSalary;
        private Decimal varCurrentRate;
        private String varCurrency;
        private String varCountryCode;
        private String varStateProvinceCode;
        private String varStreetAddress;
        private String varCityTown;
        private String varZipPostalCode;
        private Byte[] varTimeStamp;
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Login { get { return varLogin; } set { varLogin = value; } }
        public Decimal CurrentSalary { get { return varCurrentSalary; } set { varCurrentSalary = value; } }
        public Decimal CurrentRate { get { return varCurrentRate; } set { varCurrentRate = value; } }
        public String Currency { get { return varCurrency; } set { varCurrency = value; } }
        public String CountryCode { get { return varCountryCode; } set { varCountryCode = value; } }
        public String StateProvinceCode { get { return varStateProvinceCode; } set { varStateProvinceCode = value; } }
        public String StreetAddress { get { return varStreetAddress; } set { varStreetAddress = value; } }
        public String CityTown { get { return varCityTown; } set { varCityTown = value; } }
        public String ZipPostalCode { get { return varZipPostalCode; } set { varZipPostalCode = value; } }
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}
