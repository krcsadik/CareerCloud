using System;
namespace CareerCloud.Pocos
{
    public class ApplicantEducationPoco
    {
        //private int varId;
        //public int Id { get { return varId; } set { varId = value; } }
        private Guid varId;
        private Guid varApplicant;
        private String varMajor;
        private String varCetificateDiploma;
        private DateTime varStartDate;
        private DateTime varCompletionDate;
        private Byte varCompletionPercent;
        private Byte[] varTimeStamp;
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }
        public String Major { get { return varMajor; } set { varMajor = value; } }
        public String CetificateDiploma { get { return varCetificateDiploma; } set { varCetificateDiploma = value; } }
        public DateTime StartDate { get { return varStartDate; } set { varStartDate = value; } }
        public DateTime CompletionDate { get { return varCompletionDate; } set { varCompletionDate = value; } }
        public Byte CompletionPercent { get { return varCompletionPercent; } set { varCompletionPercent = value; } }
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }        
    }
}
