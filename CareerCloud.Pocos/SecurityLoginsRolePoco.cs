using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    [DataContract]
    public class SecurityLoginsRolePoco : IPoco
    {
        private Guid varId;
        private Guid varLogin;
        private Guid varRole;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [DataMember]
        [ForeignKey("SecurityLogins")]
        public Guid Login { get { return varLogin; } set { varLogin = value; } }

        [ForeignKey("SecurityRoles")]
        [DataMember]
        public Guid Role { get { return varRole; } set { varRole = value; } }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }

        public virtual SecurityLoginPoco SecurityLogins { get; set; }
        public virtual SecurityRolePoco SecurityRoles { get; set; }
    }
}
