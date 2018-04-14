using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;
using System.ServiceModel;

namespace CareerCloud.WCF
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    class Company : ICompany
    {
        public void AddCompanyDescription(CompanyDescriptionPoco[] list)
        {
            using (LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic> logic = new LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic>())
            {
                logic.Add(list);
            }
        }

        public void AddCompanyJob(CompanyJobPoco[] list)
        {
            using (LogicBridge<CompanyJobPoco, CompanyJobLogic> logic = new LogicBridge<CompanyJobPoco, CompanyJobLogic>())
            {
                logic.Add(list);
            }

        }

        public void AddCompanyJobDescription(CompanyJobDescriptionPoco[] list)
        {
            using (LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic> logic = new LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic>())
            {
                logic.Add(list);
            }
        }

        public void AddCompanyJobEducation(CompanyJobEducationPoco[] list)
        {
            using (LogicBridge<CompanyJobEducationPoco, CompanyJobEducationLogic> logic = new LogicBridge<CompanyJobEducationPoco, CompanyJobEducationLogic>())
            {
                logic.Add(list);
            }
        }

        public void AddCompanyJobSkill(CompanyJobSkillPoco[] list)
        {
            using (LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic> logic = new LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic>())
            {
                logic.Add(list);
            }
        }

        public void AddCompanyLocation(CompanyLocationPoco[] list)
        {
            using (LogicBridge<CompanyLocationPoco, CompanyLocationLogic> logic = new LogicBridge<CompanyLocationPoco, CompanyLocationLogic>())
            {
                logic.Add(list);
            }
        }

        public void AddCompanyProfile(CompanyProfilePoco[] list)
        {
            using (LogicBridge<CompanyProfilePoco, CompanyProfileLogic> logic = new LogicBridge<CompanyProfilePoco, CompanyProfileLogic>())
            {
                logic.Add(list);
            }
        }

        public CompanyDescriptionPoco[] GetAllCompanyDescription()
        {
            using (LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic> logic = new LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic>())
            {
                return logic.GetAll();
            }
        }

        public CompanyJobPoco[] GetAllCompanyJob()
        {
            using (LogicBridge<CompanyJobPoco, CompanyJobLogic> logic = new LogicBridge<CompanyJobPoco, CompanyJobLogic>())
            {
                return logic.GetAll();
            }
        }

        public CompanyJobDescriptionPoco[] GetAllCompanyJobDescription()
        {
            using (LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic> logic = new LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic>())
            {
                return logic.GetAll();
            }
        }

        public CompanyJobEducationPoco[] GetAllCompanyJobEducation()
        {
            using (LogicBridge< CompanyJobEducationPoco,  CompanyJobEducationLogic> logic = new LogicBridge< CompanyJobEducationPoco,  CompanyJobEducationLogic>())
            {
                return logic.GetAll();
            }
        }

        public CompanyJobSkillPoco[] GetAllCompanyJobSkill()
        {
            using (LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic> logic = new LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic>())
            {
                return logic.GetAll();
            }
        }

        public CompanyLocationPoco[] GetAllCompanyLocation()
        {
            using (LogicBridge<CompanyLocationPoco, CompanyLocationLogic> logic = new LogicBridge<CompanyLocationPoco, CompanyLocationLogic>())
            {
                return logic.GetAll();
            }
        }

        public CompanyProfilePoco[] GetAllCompanyProfile()
        {
            using (LogicBridge<CompanyProfilePoco, CompanyProfileLogic> logic = new LogicBridge<CompanyProfilePoco, CompanyProfileLogic>())
            {
                return logic.GetAll();
            }
        }

        public CompanyDescriptionPoco GetSingleCompanyDescription(String Id)
        {
            using (LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic> logic = new LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public CompanyJobPoco GetSingleCompanyJob(String Id)
        {
            using (LogicBridge<CompanyJobPoco, CompanyJobLogic> logic = new LogicBridge<CompanyJobPoco, CompanyJobLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public CompanyJobDescriptionPoco GetSingleCompanyJobDescription(String Id)
        {
            using (LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic> logic = new LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public CompanyJobEducationPoco GetSingleCompanyJobEducation(String Id)
        {
            using (LogicBridge<CompanyJobEducationPoco, CompanyJobEducationLogic> logic = new LogicBridge<CompanyJobEducationPoco, CompanyJobEducationLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public CompanyJobSkillPoco GetSingleCompanyJobSkill(String Id)
        {
            using (LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic> logic = new LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public CompanyLocationPoco GetSingleCompanyLocation(String Id)
        {
            using (LogicBridge<CompanyLocationPoco, CompanyLocationLogic> logic = new LogicBridge<CompanyLocationPoco, CompanyLocationLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public CompanyProfilePoco GetSingleCompanyProfile(String Id)
        {
            using (LogicBridge<CompanyProfilePoco, CompanyProfileLogic> logic = new LogicBridge<CompanyProfilePoco, CompanyProfileLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public void RemoveCompanyDescription(CompanyDescriptionPoco[] list)
        {
            using (LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic> logic = new LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic>())
            {
                logic.Delete(list);
            }
        }

        public void RemoveCompanyJob(CompanyJobPoco[] list)
        {
            using (LogicBridge<CompanyJobPoco, CompanyJobLogic> logic = new LogicBridge<CompanyJobPoco, CompanyJobLogic>())
            {
                logic.Delete(list);
            }
        }

        public void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] list)
        {
            using (LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic> logic = new LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic>())
            {
                logic.Delete(list);
            }
        }

        public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] list)
        {
            using (LogicBridge<CompanyJobEducationPoco, CompanyJobEducationLogic> logic = new LogicBridge<CompanyJobEducationPoco, CompanyJobEducationLogic>())
            {
                logic.Delete(list);
            }
        }

        public void RemoveCompanyJobSkill(CompanyJobSkillPoco[] list)
        {
            using (LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic> logic = new LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic>())
            {
                logic.Delete(list);
            }
        }

        public void RemoveCompanyLocation(CompanyLocationPoco[] list)
        {
            using (LogicBridge<CompanyLocationPoco, CompanyLocationLogic> logic = new LogicBridge<CompanyLocationPoco, CompanyLocationLogic>())
            {
                logic.Delete(list);
            }
        }

        public void RemoveCompanyProfile(CompanyProfilePoco[] list)
        {
            using (LogicBridge<CompanyProfilePoco, CompanyProfileLogic> logic = new LogicBridge<CompanyProfilePoco, CompanyProfileLogic>())
            {
                logic.Delete(list);
            }
        }

        public void UpdateCompanyDescription(CompanyDescriptionPoco[] list)
        {
            using (LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic> logic = new LogicBridge<CompanyDescriptionPoco, CompanyDescriptionLogic>())
            {
                logic.Update(list);
            }
        }

        public void UpdateCompanyJob(CompanyJobPoco[] list)
        {
            using (LogicBridge<CompanyJobPoco, CompanyJobLogic> logic = new LogicBridge<CompanyJobPoco, CompanyJobLogic>())
            {
                logic.Update(list);
            }
        }

        public void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] list)
        {
            using (LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic> logic = new LogicBridge<CompanyJobDescriptionPoco, CompanyJobDescriptionLogic>())
            {
                logic.Update(list);
            }
        }

        public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] list)
        {
            using (LogicBridge<CompanyJobEducationPoco, CompanyJobEducationLogic> logic = new LogicBridge<CompanyJobEducationPoco, CompanyJobEducationLogic>())
            {
                logic.Update(list);
            }
        }

        public void UpdateCompanyJobSkill(CompanyJobSkillPoco[] list)
        {
            using (LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic> logic = new LogicBridge<CompanyJobSkillPoco, CompanyJobSkillLogic>())
            {
                logic.Update(list);
            }
        }

        public void UpdateCompanyLocation(CompanyLocationPoco[] list)
        {
            using (LogicBridge<CompanyLocationPoco, CompanyLocationLogic> logic = new LogicBridge<CompanyLocationPoco, CompanyLocationLogic>())
            {
                logic.Update(list);
            }
        }

        public void UpdateCompanyProfile(CompanyProfilePoco[] list)
        {
            using (LogicBridge<CompanyProfilePoco, CompanyProfileLogic> logic = new LogicBridge<CompanyProfilePoco, CompanyProfileLogic>())
            {
                logic.Update(list);
            }
        }
    }
}
