using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;


namespace CareerCloud.WCF
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class Applicant : IApplicant ,IDisposable
    {

        public void AddApplicantEducation(ApplicantEducationPoco[] list)
        {
            using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
            {
                logic.Add(list);
            }
        }

        public ApplicantEducationPoco[] GetAllApplicantEducation()
        {
            using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
            {
                return logic.GetAll();
            }
        }

        public ApplicantEducationPoco GetSingleApplicantEducation(String Id)
        {
            using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public void UpdateApplicantEducation(ApplicantEducationPoco[] list)
        {
            using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
            {
                logic.Update(list);
            }
        }

        public void RemoveApplicantEducation(ApplicantEducationPoco[] list)
        {
            using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
            {
                logic.Delete(list);
            }
        }

        public void AddApplicantJobApplication(ApplicantJobApplicationPoco[] list)
        {
            using (LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic> logic = new LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic>())
            {
                logic.Add(list);
            }

        }

        public ApplicantJobApplicationPoco[] GetAllApplicantJobApplication()
        {
            using (LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic> logic = new LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic>())
            {
                return logic.GetAll();
            }
        }

        public ApplicantJobApplicationPoco GetSingleApplicantJobApplication(String Id)
        {
            using (LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic> logic = new LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic>())
            {

                return (ApplicantJobApplicationPoco)logic.GetSingle(Id);
            }

        }

        public void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] list)
        {
            using (LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic> logic = new LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic>())
            {
                logic.Update(list);
            }
        }

        public void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] list)
        {
            using (LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic> logic = new LogicBridge<ApplicantJobApplicationPoco, ApplicantJobApplicationLogic>())
            {
                logic.Delete(list);
            }
        }

        public void AddApplicantProfile(ApplicantProfilePoco[] list)
        {
            using (LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic> logic = new LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic>())
            {
                logic.Add(list);
            }
        }

        public ApplicantProfilePoco[] GetAllApplicantProfile()
        {
            using (LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic> logic = new LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic>())
            {
                return logic.GetAll();
            }
        }

        public ApplicantProfilePoco GetSingleApplicantProfile(String Id)
        {
            using (LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic> logic = new LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic>())
            {

                return (ApplicantProfilePoco)logic.GetSingle(Id);
            }

        }

        public void UpdateApplicantProfile(ApplicantProfilePoco[] list)
        {
            using (LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic> logic = new LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic>())
            {
                logic.Update(list);
            }
        }

        public void RemoveApplicantProfile(ApplicantProfilePoco[] list)
        {
            using (LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic> logic = new LogicBridge<ApplicantProfilePoco, ApplicantProfileLogic>())
            {
                logic.Delete(list);
            }
        }

        public void AddApplicantResume(ApplicantResumePoco[] list)
        {
            using (LogicBridge<ApplicantResumePoco, ApplicantResumeLogic> logic = new LogicBridge<ApplicantResumePoco, ApplicantResumeLogic>())
            {
                logic.Add(list);
            }
        }

        public ApplicantResumePoco[] GetAllApplicantResume()
        {
            using (LogicBridge<ApplicantResumePoco, ApplicantResumeLogic> logic = new LogicBridge<ApplicantResumePoco, ApplicantResumeLogic>())
            {
                return logic.GetAll();
            }
        }

        public ApplicantResumePoco GetSingleApplicantResume(String Id)
        {
            using (LogicBridge<ApplicantResumePoco, ApplicantResumeLogic> logic = new LogicBridge<ApplicantResumePoco, ApplicantResumeLogic>())
            {

                return (ApplicantResumePoco)logic.GetSingle(Id);
            }

        }

        public void UpdateApplicantResume(ApplicantResumePoco[] list)
        {
            using (LogicBridge<ApplicantResumePoco, ApplicantResumeLogic> logic = new LogicBridge<ApplicantResumePoco, ApplicantResumeLogic>())
            {
                logic.Update(list);
            }
        }

        public void RemoveApplicantResume(ApplicantResumePoco[] list)
        {
            using (LogicBridge<ApplicantResumePoco, ApplicantResumeLogic> logic = new LogicBridge<ApplicantResumePoco, ApplicantResumeLogic>())
            {
                logic.Delete(list);
            }
        }

        public void AddApplicantSkill(ApplicantSkillPoco[] list)
        {
            using (LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic> logic = new LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic>())
            {
                logic.Add(list);
            }
        }

        public ApplicantSkillPoco[] GetAllApplicantSkill()
        {
            using (LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic> logic = new LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic>())
            {
                return logic.GetAll();
            }
        }

        public ApplicantSkillPoco GetSingleApplicantSkill(String Id)
        {
            using (LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic> logic = new LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic>())
            {

                return (ApplicantSkillPoco)logic.GetSingle(Id);
            }

        }

        public void UpdateApplicantSkill(ApplicantSkillPoco[] list)
        {
            using (LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic> logic = new LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic>())
            {
                logic.Update(list);
            }
        }

        public void RemoveApplicantSkill(ApplicantSkillPoco[] list)
        {
            using (LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic> logic = new LogicBridge<ApplicantSkillPoco, ApplicantSkillLogic>())
            {
                logic.Delete(list);
            }
        }

        public void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] list)
        {
            using (LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic> logic = new LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic>())
            {
                logic.Add(list);
            }
        }

        public ApplicantWorkHistoryPoco[] GetAllApplicantWorkHistory()
        {
            using (LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic> logic = new LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic>())
            {
                return logic.GetAll();
            }
        }

        public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(String Id)
        {
            using (LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic> logic = new LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic>())
            {

                return (ApplicantWorkHistoryPoco)logic.GetSingle(Id);
            }

        }

        public void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] list)
        {
            using (LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic> logic = new LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic>())
            {
                logic.Update(list);
            }
        }

        public void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] list)
        {
            using (LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic> logic = new LogicBridge<ApplicantWorkHistoryPoco, ApplicantWorkHistoryLogic>())
            {
                logic.Delete(list);
            }
        }

        //==================================  temp ==========================================================
        //public Applicant()
        //{
        //    //Trace.Listeners.Add(new TextWriterTraceListener(@"c:\TextWriterOutput.log", "myListener"));
        //    // You must close or flush the trace to empty the output buffer.  
        //}
        //public void AddApplicantEducation(ApplicantEducationPoco[] list)
        //{
        //    //ApplicantEducationLogic logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
        //    using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
        //    {
        //        logic.Add(list);
        //    }
        //}

        //public ApplicantEducationPoco[] GetAllApplicantEducation()
        //{
        //    using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
        //    {
        //        return logic.GetAll();
        //    }
        //}

        //public ApplicantEducationPoco GetSingleApplicantEducation(String Id)
        //{
        //    using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
        //    {

        //        return logic.GetSingle(Id);
        //        //return logic.GetAll().Where(c => c.Id==Id);
        //    }
        //}

        //public void UpdateApplicantEducation(ApplicantEducationPoco[] list)
        //{
        //    using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
        //    {
        //        logic.Update(list);
        //    }
        //}

        //public void RemoveApplicantEducation(ApplicantEducationPoco[] list)
        //{
        //    using (LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic> logic = new LogicBridge<ApplicantEducationPoco, ApplicantEducationLogic>())
        //    {
        //        logic.Delete(list);
        //    }
        //}

        public void Dispose()
        {
            //Trace.Flush();
        }

    }
}
