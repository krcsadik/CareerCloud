using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;

namespace CareerCloud.WCF
{
    class Security : ISecurity
    {
        public void AddSecurityLogin(SecurityLoginPoco[] list)
        {
            using (LogicBridge<SecurityLoginPoco, SecurityLoginLogic> logic = new LogicBridge<SecurityLoginPoco, SecurityLoginLogic>())
            {
                logic.Add(list);
            }

        }

        public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] list)
        {
            using (LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic> logic = new LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic>())
            {
                logic.Add(list);
            }

        }

        public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] list)
        {
            using (LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic> logic = new LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic>())
            {
                logic.Add(list);
            }
        }

        public void AddSecurityRole(SecurityRolePoco[] list)
        {
            using (LogicBridge<SecurityRolePoco, SecurityRoleLogic> logic = new LogicBridge<SecurityRolePoco, SecurityRoleLogic>())
            {
                logic.Add(list);
            }
        }

        public SecurityLoginPoco[] GetAllSecurityLogin()
        {
            using (LogicBridge<SecurityLoginPoco, SecurityLoginLogic> logic = new LogicBridge<SecurityLoginPoco, SecurityLoginLogic>())
            {
                return logic.GetAll();
            }
        }

        public SecurityLoginsLogPoco[] GetAllSecurityLoginsLog()
        {
            using (LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic> logic = new LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic>())
            {
                return logic.GetAll();
            }
        }

        public SecurityLoginsRolePoco[] GetAllSecurityLoginsRole()
        {
            using (LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic> logic = new LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic>())
            {
                return logic.GetAll();
            }
        }

        public SecurityRolePoco[] GetAllSecurityRole()
        {
            using (LogicBridge<SecurityRolePoco, SecurityRoleLogic> logic = new LogicBridge<SecurityRolePoco, SecurityRoleLogic>())
            {
                return logic.GetAll();
            }
        }

        public SecurityLoginPoco GetSingleSecurityLogin(String Id)
        {
            using (LogicBridge<SecurityLoginPoco, SecurityLoginLogic> logic = new LogicBridge<SecurityLoginPoco, SecurityLoginLogic>())
            {
                return logic.GetSingle(Id);
            }

        }

        public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(String Id)
        {
            using (LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic> logic = new LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(String Id)
        {
            using (LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic> logic = new LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public SecurityRolePoco GetSingleSecurityRole(String Id)
        {
            using (LogicBridge<SecurityRolePoco, SecurityRoleLogic> logic = new LogicBridge<SecurityRolePoco, SecurityRoleLogic>())
            {
                return logic.GetSingle(Id);
            }
        }

        public void RemoveSecurityLogin(SecurityLoginPoco[] list)
        {
            using (LogicBridge<SecurityLoginPoco, SecurityLoginLogic> logic = new LogicBridge<SecurityLoginPoco, SecurityLoginLogic>())
            {
                logic.Delete(list);
            }
        }

        public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] list)
        {
            using (LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic> logic = new LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic>())
            {
                logic.Delete(list);
            }
        }

        public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] list)
        {
            using (LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic> logic = new LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic>())
            {
                logic.Delete(list);
            }
        }

        public void RemoveSecurityRole(SecurityRolePoco[] list)
        {
            using (LogicBridge<SecurityRolePoco, SecurityRoleLogic> logic = new LogicBridge<SecurityRolePoco, SecurityRoleLogic>())
            {
                logic.Delete(list);
            }
        }

        public void UpdateSecurityLogin(SecurityLoginPoco[] list)
        {
            using (LogicBridge<SecurityLoginPoco, SecurityLoginLogic> logic = new LogicBridge<SecurityLoginPoco, SecurityLoginLogic>())
            {
                logic.Update(list);
            }
        }

        public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] list)
        {
            using (LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic> logic = new LogicBridge<SecurityLoginsLogPoco, SecurityLoginsLogLogic>())
            {
                logic.Update(list);
            }
        }

        public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] list)
        {
            using (LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic> logic = new LogicBridge<SecurityLoginsRolePoco, SecurityLoginsRoleLogic>())
            {
                logic.Update(list);
            }
        }

        public void UpdateSecurityRole(SecurityRolePoco[] list)
        {
            using (LogicBridge<SecurityRolePoco, SecurityRoleLogic> logic = new LogicBridge<SecurityRolePoco, SecurityRoleLogic>())
            {
                logic.Update(list);
            }
        }
    }
}
