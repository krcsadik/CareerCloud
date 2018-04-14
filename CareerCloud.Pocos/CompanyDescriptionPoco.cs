using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions")]
    [DataContract]
    public class CompanyDescriptionPoco : IPoco
    {
        private Guid varId;
        private Guid varCompany;
        private String varLanguageId;
        private String varCompanyName;
        private String varCompanyDescription;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [ForeignKey("CompanyProfiles")]
        [DataMember]
        public Guid Company { get { return varCompany; } set { varCompany = value; } }

        [ForeignKey("SystemLanguageCodes")]
        [DataMember]
        public String LanguageId { get { return varLanguageId; } set { varLanguageId = value; } }

        [Column("Company_Name")]
        [Display(Name ="Company Name")]
        [DataMember]
        public String CompanyName { get { return varCompanyName; } set { varCompanyName = value; } }

        [Column("Company_Description")]
        [Display(Name = "Company Description")]
        [DataMember]
        public String CompanyDescription { get { return varCompanyDescription; } set { varCompanyDescription = value; } }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }

        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
        public virtual SystemLanguageCodePoco SystemLanguageCodes { get; set; }
    }
}
