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
    public interface IApplicant
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddApplicantEducation(ApplicantEducationPoco[] list);

        [OperationContract]

        ApplicantEducationPoco[] GetAllApplicantEducation();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        ApplicantEducationPoco GetSingleApplicantEducation(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateApplicantEducation(ApplicantEducationPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveApplicantEducation(ApplicantEducationPoco[] list);
        //================AddApplicantJobApplication=============================================================0

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] list);

        [OperationContract]

        ApplicantJobApplicationPoco[] GetAllApplicantJobApplication();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] list);

        //================AddApplicantProfile=============================================================0

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddApplicantProfile(ApplicantProfilePoco[] list);

        [OperationContract]

        ApplicantProfilePoco[] GetAllApplicantProfile();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        ApplicantProfilePoco GetSingleApplicantProfile(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateApplicantProfile(ApplicantProfilePoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveApplicantProfile(ApplicantProfilePoco[] list);

        //================AddApplicantResume=============================================================0

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddApplicantResume(ApplicantResumePoco[] list);

        [OperationContract]

        ApplicantResumePoco[] GetAllApplicantResume();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        ApplicantResumePoco GetSingleApplicantResume(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateApplicantResume(ApplicantResumePoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveApplicantResume(ApplicantResumePoco[] list);

        //================AddApplicantSkill=============================================================0

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddApplicantSkill(ApplicantSkillPoco[] list);

        [OperationContract]

        ApplicantSkillPoco[] GetAllApplicantSkill();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        ApplicantSkillPoco GetSingleApplicantSkill(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateApplicantSkill(ApplicantSkillPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveApplicantSkill(ApplicantSkillPoco[] list);

        //================AddApplicantWorkHistory=============================================================0

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] list);

        [OperationContract]

        ApplicantWorkHistoryPoco[] GetAllApplicantWorkHistory();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] list);
    }

    [DataContract]
    public class ValidationFault
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
