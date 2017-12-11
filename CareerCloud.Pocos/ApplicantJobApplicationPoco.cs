using System;
namespace CareerCloud.Pocos
{
    public class ApplicantJobApplicationPoco
    {
        private Guid varId;
        private Guid varApplicant;
        private Guid varJob;
        private DateTime varApplicationDate;
        private Byte[] varTimeStamp;
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }
        public Guid Job { get { return varJob; } set { varJob = value; } }
        public DateTime ApplicationDate { get { return varApplicationDate; } set { varApplicationDate = value; } }
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}