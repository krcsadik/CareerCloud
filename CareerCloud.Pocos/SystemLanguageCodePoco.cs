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
        [Key]
        [DataMember]
        public String LanguageID { get; set; }

        [Required]
        [DataMember]
        public String Name { get; set; }

        [Column("Native_Name")]
        [Display(Name = "Native Name")]
        [Required]
        [DataMember]
        public String NativeName { get; set; }

        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
    }
}