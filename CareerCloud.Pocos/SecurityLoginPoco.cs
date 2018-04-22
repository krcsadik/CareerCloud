using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Runtime.Serialization;
using System.Collections.Generic;
namespace CareerCloud.Pocos
{
    [Table("Security_Logins")]
    [DataContract]
    public class SecurityLoginPoco : IPoco
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public String Login { get; set; }

        [DataType(DataType.Password)]
        [DataMember]
        public String Password { get; set; }

        [NotMapped]
        public String Salt { get; set; }

        [Column("Created_Date")]
        [DataMember]
        public DateTime Created { get; set; }

        [Column("Password_Update_Date")]
        [DataMember]
        [Display(Name = "Password Update Date")]
        public DateTime? PasswordUpdate { get; set; }

        [Column("Agreement_Accepted_Date")]
        [Display(Name = "Aggrement Accept Date")]
        [DataMember]
        public DateTime? AgreementAccepted { get; set; }

        [Column("Is_Locked")]
        [Display(Name = "Is Locked")]
        [DataMember]
        public Boolean IsLocked { get; set; }

        [Column("Is_Inactive")]
        [Display(Name = "Is Inactive")]
        [DataMember]
        public Boolean IsInactive { get; set; }

        [Column("Email_Address")]
        [DataType(DataType.EmailAddress)]
        [DataMember]
        [Display(Name = "Email Address")]
        public String EmailAddress { get; set; }

        [Column("Phone_Number")]
        [Display(Name = "Phone Number")]
        [DataMember]
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }

        [Column("Full_Name")]
        [DataMember]
        [Display(Name = "Full Name")]
                public String FullName { get; set; }

        [Column("Force_Change_Password")]
        [DataMember]
        [Display(Name = "Force Change Password")]
        public Boolean ForceChangePassword { get; set; }

        [Column("Prefferred_Language")]
        [Display(Name = "Prefferred Language")]
        [DataMember]
        public String PrefferredLanguage { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
    }
}