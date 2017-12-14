using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Company_Jobs")]
    public class CompanyJobPoco : IPoco
    {
        private Guid varId;
        private Guid varCompany;
        private DateTime varProfileCreated;
        private Boolean varIsInactive;
        private Boolean varIsCompanyHidden;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Company { get { return varCompany; } set { varCompany = value; } }
        [Column("Profile_Created")]
        public DateTime ProfileCreated { get { return varProfileCreated; } set { varProfileCreated = value; } }
        [Column("Is_Inactive")]
        public Boolean IsInactive { get { return varIsInactive; } set { varIsInactive = value; } }
        [Column("Is_Company_Hidden")]
        public Boolean IsCompanyHidden { get { return varIsCompanyHidden; } set { varIsCompanyHidden = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}