using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    [DataContract]
    public class SecurityLoginsRolePoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        [ForeignKey("SecurityLogins")]
        public Guid Login { get; set; }

        [ForeignKey("SecurityRoles")]
        [DataMember]
        public Guid Role { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get; set; }

        public virtual SecurityLoginPoco SecurityLogins { get; set; }
        public virtual SecurityRolePoco SecurityRoles { get; set; }
    }
}
