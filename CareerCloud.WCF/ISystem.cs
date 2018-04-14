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
    public interface ISystem
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddSystemCountryCode(SystemCountryCodePoco[] list);

        [OperationContract]
        SystemCountryCodePoco[] GetAllSystemCountryCode();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        SystemCountryCodePoco GetSingleSystemCountryCode(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateSystemCountryCode(SystemCountryCodePoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveSystemCountryCode(SystemCountryCodePoco[] list);

        //===========Language Code  ============================================
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddSystemLanguageCode(SystemLanguageCodePoco[] list);

        [OperationContract]
        SystemLanguageCodePoco[] GetAllSystemLanguageCode();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        SystemLanguageCodePoco GetSingleSystemLanguageCode(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateSystemLanguageCode(SystemLanguageCodePoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveSystemLanguageCode(SystemLanguageCodePoco[] list);

    }
}
