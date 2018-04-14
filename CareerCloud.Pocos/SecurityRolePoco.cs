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
        private Guid varId;
        private String varRole;
        private Boolean varIsInactive;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [DataMember]
        public String Role { get { return varRole; } set { varRole = value; } }

        [Column("Is_Inactive")]
        [Display(Name = "Is Inactive")]
        [DataMember]
        public Boolean IsInactive { get { return varIsInactive; } set { varIsInactive = value; } }

        public virtual ICollection<SecurityLoginsRolePoco> SecuritysLoginsRoles { get; set; }
    }
}