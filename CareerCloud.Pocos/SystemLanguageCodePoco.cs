using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
using System.Collections.Generic;
namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
    [DataContract]
    public class SystemLanguageCodePoco 
    {
        private String varLanguageID;
        private String varName;
        private String varNativeName;
        [Key]
        [DataMember]
        public String LanguageID { get { return varLanguageID; } set { varLanguageID = value; } }

        [Required]
        [DataMember]
        public String Name { get { return varName; } set { varName = value; } }

        [Column("Native_Name")]
        [Display(Name = "Native Name")]
        [Required]
        [DataMember]
        public String NativeName { get { return varNativeName; } set { varNativeName = value; } }

        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
    }
}