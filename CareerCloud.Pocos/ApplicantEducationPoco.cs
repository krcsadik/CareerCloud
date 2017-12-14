using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Educations")]
    public class ApplicantEducationPoco : IPoco
    {
        //private int varId;
        //public int Id { get { return varId; } set { varId = value; } }
        private Guid varId;
        private Guid varApplicant;
        private String varMajor;
        private String varCetificateDiploma;
        private DateTime? varStartDate;
        private DateTime? varCompletionDate;
        private Byte? varCompletionPercent;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }
        public String Major { get { return varMajor; } set { varMajor = value; } }
        [Column("Cetificate_Diploma")]
        public String CetificateDiploma { get { return varCetificateDiploma; } set { varCetificateDiploma = value; } }
        [Column("Start_Date")]
        public DateTime? StartDate { get { return varStartDate; } set { varStartDate = value; } }
        [Column("Completion_Date")]
        public DateTime? CompletionDate { get { return varCompletionDate; } set { varCompletionDate = value; } }
        [Column("Completion_Percent")]
        public Byte? CompletionPercent { get { return varCompletionPercent; } set { varCompletionPercent = value; } }
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }        
    }
}
