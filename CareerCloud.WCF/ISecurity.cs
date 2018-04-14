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
    public interface ISecurity
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddSecurityLogin(SecurityLoginPoco[] list);

        [OperationContract]

        SecurityLoginPoco[] GetAllSecurityLogin();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        SecurityLoginPoco GetSingleSecurityLogin(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateSecurityLogin(SecurityLoginPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveSecurityLogin(SecurityLoginPoco[] list);

        //=======================================================
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddSecurityLoginsRole(SecurityLoginsRolePoco[] list);

        [OperationContract]

        SecurityLoginsRolePoco[] GetAllSecurityLoginsRole();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        SecurityLoginsRolePoco GetSingleSecurityLoginsRole(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] list);

        //=======================================================
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddSecurityRole(SecurityRolePoco[] list);

        [OperationContract]

        SecurityRolePoco[] GetAllSecurityRole();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        SecurityRolePoco GetSingleSecurityRole(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateSecurityRole(SecurityRolePoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveSecurityRole(SecurityRolePoco[] list);
        //=======================================================
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void AddSecurityLoginsLog(SecurityLoginsLogPoco[] list);

        [OperationContract]

        SecurityLoginsLogPoco[] GetAllSecurityLoginsLog();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        SecurityLoginsLogPoco GetSingleSecurityLoginsLog(String Id);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] list);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] list);
    }
}
