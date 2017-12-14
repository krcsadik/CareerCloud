using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco : IPoco
    {
        private Guid varId;
        private Guid varCompany;
        private String varLanguageId;
        private String varCompanyName;
        private String varCompanyDescription;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Company { get { return varCompany; } set { varCompany = value; } }
        public String LanguageId { get { return varLanguageId; } set { varLanguageId = value; } }
        [Column("Company_Name")]
        public String CompanyName { get { return varCompanyName; } set { varCompanyName = value; } }
        [Column("Company_Description")]
        public String CompanyDescription { get { return varCompanyDescription; } set { varCompanyDescription = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}
