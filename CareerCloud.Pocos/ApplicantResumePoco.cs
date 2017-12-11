using System;
namespace CareerCloud.Pocos
{
    public class ApplicantResumePoco
    {
        private Guid varId;
        private Guid varApplicant;
        private String varResume;
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }
        public String Resume { get { return varResume; } set { varResume = value; } }
    }
}
