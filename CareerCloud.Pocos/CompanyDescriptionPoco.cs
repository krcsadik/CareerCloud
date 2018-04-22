using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions")]
    [DataContract]
    public class CompanyDescriptionPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [ForeignKey("CompanyProfiles")]
        [DataMember]
        public Guid Company { get; set; }

        [ForeignKey("SystemLanguageCodes")]
        [DataMember]
        public String LanguageId { get; set; }

        [Column("Company_Name")]
        [Display(Name ="Company Name")]
        [DataMember]
        public String CompanyName { get; set; }

        [Column("Company_Description")]
        [Display(Name = "Company Description")]
        [DataMember]
        public String CompanyDescription { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get; set; }

        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
        public virtual SystemLanguageCodePoco SystemLanguageCodes { get; set; }
    }
}
