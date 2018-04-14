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
        private Guid varId;
        private String varLogin;
        private String varPassword;
        private String varSalt;
        private DateTime varCreated;
        private DateTime? varPasswordUpdate;
        private DateTime? varAgreementAccepted;
        private Boolean varIsLocked;
        private Boolean varIsInactive;
        private String varEmailAddress;
        private String varPhoneNumber;
        private String varFullName;
        private Boolean varForceChangePassword;
        private String varPrefferredLanguage;
        private Byte[] varTimeStamp;
        [Key]
        [DataMember]
        public Guid Id { get { return varId; } set { varId = value; } }

        [DataMember]
        public String Login { get { return varLogin; } set { varLogin = value; } }

        [DataType(DataType.Password)]
        [DataMember]
        public String Password { get { return varPassword; } set { varPassword = value; } }

        [NotMapped]
        public String Salt { get { return varSalt; } set { varSalt = value; } }

        [Column("Created_Date")]
        [DataMember]
        public DateTime Created { get { return varCreated; } set { varCreated = value; } }

        [Column("Password_Update_Date")]
        [DataMember]
        [Display(Name = "Password Update Date")]
        public DateTime? PasswordUpdate { get { return varPasswordUpdate; } set { varPasswordUpdate = value; } }

        [Column("Agreement_Accepted_Date")]
        [Display(Name = "Aggrement Accept Date")]
        [DataMember]
        public DateTime? AgreementAccepted { get { return varAgreementAccepted; } set { varAgreementAccepted = value; } }

        [Column("Is_Locked")]
        [Display(Name = "Is Locked")]
        [DataMember]
        public Boolean IsLocked { get { return varIsLocked; } set { varIsLocked = value; } }

        [Column("Is_Inactive")]
        [Display(Name = "Is Inactive")]
        [DataMember]
        public Boolean IsInactive { get { return varIsInactive; } set { varIsInactive = value; } }

        [Column("Email_Address")]
        [DataType(DataType.EmailAddress)]
        [DataMember]
        [Display(Name = "Email Address")]
        public String EmailAddress { get { return varEmailAddress; } set { varEmailAddress = value; } }

        [Column("Phone_Number")]
        [Display(Name = "Phone Number")]
        [DataMember]
        [DataType(DataType.PhoneNumber)]

        public String PhoneNumber { get { return varPhoneNumber; } set { varPhoneNumber = value; } }

        [Column("Full_Name")]
        [DataMember]
        [Display(Name = "Full Name")]

        public String FullName { get { return varFullName; } set { varFullName = value; } }

        [Column("Force_Change_Password")]
        [DataMember]
        [Display(Name = "Force Change Password")]
        public Boolean ForceChangePassword { get { return varForceChangePassword; } set { varForceChangePassword = value; } }

        [Column("Prefferred_Language")]
        [Display(Name = "Prefferred Language")]
        [DataMember]
        public String PrefferredLanguage { get { return varPrefferredLanguage; } set { varPrefferredLanguage = value; } }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        [ScaffoldColumn(false)]
        [DataMember]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
    }
}