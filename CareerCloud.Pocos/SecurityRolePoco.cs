using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Security_Roles")]
    public class SecurityRolePoco : IPoco
    {
        private Guid varId;
        private String varRole;
        private Boolean varIsInactive;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public String Role { get { return varRole; } set { varRole = value; } }
        [Column("Is_Inactive")]
        public Boolean IsInactive { get { return varIsInactive; } set { varIsInactive = value; } }
    }
}