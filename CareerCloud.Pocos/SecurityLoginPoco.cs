using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Security_Logins")]
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
        public Guid Id { get { return varId; } set { varId = value; } }
        public String Login { get { return varLogin; } set { varLogin = value; } }
        public String Password { get { return varPassword; } set { varPassword = value; } }
        public String Salt { get { return varSalt; } set { varSalt = value; } }
        [Column("Created_Date")]
        public DateTime Created { get { return varCreated; } set { varCreated = value; } }
        [Column("Password_Update_Date")]
        public DateTime? PasswordUpdate { get { return varPasswordUpdate; } set { varPasswordUpdate = value; } }
        [Column("Agreement_Accepted_Date")]
        public DateTime? AgreementAccepted { get { return varAgreementAccepted; } set { varAgreementAccepted = value; } }
        [Column("Is_Locked")]
        public Boolean IsLocked { get { return varIsLocked; } set { varIsLocked = value; } }
        [Column("Is_Inactive")]
        public Boolean IsInactive { get { return varIsInactive; } set { varIsInactive = value; } }
        [Column("Email_Address")]
        public String EmailAddress { get { return varEmailAddress; } set { varEmailAddress = value; } }
        [Column("Phone_Number")]
        public String PhoneNumber { get { return varPhoneNumber; } set { varPhoneNumber = value; } }
        [Column("Full_Name")]
        public String FullName { get { return varFullName; } set { varFullName = value; } }
        [Column("Force_Change_Password")]
        public Boolean ForceChangePassword { get { return varForceChangePassword; } set { varForceChangePassword = value; } }
        [Column("Prefferred_Language")]
        public String PrefferredLanguage { get { return varPrefferredLanguage; } set { varPrefferredLanguage = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}
