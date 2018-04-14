using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.Pocos;
namespace CareerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
 
   [ServiceContract]
    public interface ICompany
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddCompanyDescription(CompanyDescriptionPoco[] list);

        [OperationContract]
        
        CompanyDescriptionPoco[] GetAllCompanyDescription();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CompanyDescriptionPoco GetSingleCompanyDescription(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateCompanyDescription (CompanyDescriptionPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveCompanyDescription(CompanyDescriptionPoco[] list);

        //================CompanyJobDescription=============================================================0
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddCompanyJobDescription(CompanyJobDescriptionPoco[] list);

        [OperationContract]

        CompanyJobDescriptionPoco[] GetAllCompanyJobDescription();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CompanyJobDescriptionPoco GetSingleCompanyJobDescription(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] list);

        //================CompanyJobEducation=============================================================0
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddCompanyJobEducation(CompanyJobEducationPoco[] list);

        [OperationContract]

        CompanyJobEducationPoco[] GetAllCompanyJobEducation();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CompanyJobEducationPoco GetSingleCompanyJobEducation(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateCompanyJobEducation(CompanyJobEducationPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveCompanyJobEducation(CompanyJobEducationPoco[] list);

        //================CompanyJob=============================================================0
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddCompanyJob(CompanyJobPoco[] list);

        [OperationContract]

        CompanyJobPoco[] GetAllCompanyJob();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CompanyJobPoco GetSingleCompanyJob(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateCompanyJob(CompanyJobPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveCompanyJob(CompanyJobPoco[] list);

        //================CompanyJobSkill=============================================================0
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddCompanyJobSkill(CompanyJobSkillPoco[] list);

        [OperationContract]

        CompanyJobSkillPoco[] GetAllCompanyJobSkill();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CompanyJobSkillPoco GetSingleCompanyJobSkill(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateCompanyJobSkill(CompanyJobSkillPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveCompanyJobSkill(CompanyJobSkillPoco[] list);

        //================CompanyLocation=============================================================0
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddCompanyLocation(CompanyLocationPoco[] list);

        [OperationContract]

        CompanyLocationPoco[] GetAllCompanyLocation();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CompanyLocationPoco GetSingleCompanyLocation(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateCompanyLocation(CompanyLocationPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveCompanyLocation(CompanyLocationPoco[] list);

        //================CompanyProfile=============================================================0
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddCompanyProfile(CompanyProfilePoco[] list);

        [OperationContract]

        CompanyProfilePoco[] GetAllCompanyProfile();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CompanyProfilePoco GetSingleCompanyProfile(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateCompanyProfile(CompanyProfilePoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveCompanyProfile(CompanyProfilePoco[] list);

    }


}
