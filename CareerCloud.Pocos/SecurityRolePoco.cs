using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
using System.Collections.Generic;
namespace CareerCloud.Pocos
{
    [Table("Security_Roles")]
    [DataContract]
    public class SecurityRolePoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public String Role { get; set; }

        [Column("Is_Inactive")]
        [Display(Name = "Is Inactive")]
        [DataMember]
        public Boolean IsInactive { get; set; }

        public virtual ICollection<SecurityLoginsRolePoco> SecuritysLoginsRoles { get; set; }
    }
}