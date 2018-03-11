using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    public class SecurityLoginsRolePoco : IPoco
    {
        private Guid varId;
        private Guid varLogin;
        private Guid varRole;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        [ForeignKey("SecurityLogins")]
        public Guid Login { get { return varLogin; } set { varLogin = value; } }
        [ForeignKey("SecurityRoles")]
        public Guid Role { get { return varRole; } set { varRole = value; } }
        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
        public virtual SecurityLoginPoco SecurityLogins { get; set; }
        public virtual SecurityRolePoco SecurityRoles { get; set; }
    }
}
