using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using System.ServiceModel;

namespace CareerCloud.WCF
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    class System : ISystem
    {
        public void AddSystemCountryCode(SystemCountryCodePoco[] list)
        {
            try
            {
                SystemCountryCodeLogic logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false) );
                logic.Add(list);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Country Create Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
            }
        }

        public void AddSystemLanguageCode(SystemLanguageCodePoco[] list)
        {
            try
            {

                SystemLanguageCodeLogic logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
                logic.Add(list);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Language Create Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
            }
        }

        public SystemCountryCodePoco[] GetAllSystemCountryCode()
        {
            try
            {
                SystemCountryCodeLogic logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
                return logic.GetAll().ToArray();
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Country Read Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
                return null;
            }

        }

        public SystemLanguageCodePoco[] GetAllSystemLanguageCode()
        {
            try
            {
                SystemLanguageCodeLogic logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
                return logic.GetAll().ToArray();
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Language Read Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
                return null;
            }
        }

        public SystemCountryCodePoco GetSingleSystemCountryCode(String code)
        {
            try
            {
                SystemCountryCodeLogic logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
                return logic.Get(code);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Country Read Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
                return null;
            }
        }

        public SystemLanguageCodePoco GetSingleSystemLanguageCode(String languageID)
        {
            try
            {
                SystemLanguageCodeLogic logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
                return logic.Get(languageID);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Language Read Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
                return null;
            }
        }

        public void RemoveSystemCountryCode(SystemCountryCodePoco[] list)
        {
            try
            {
                SystemCountryCodeLogic logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
                logic.Delete(list);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Country Delete Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
            }
        }

        public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] list)
        {
            try
            {
                SystemLanguageCodeLogic logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
                logic.Delete(list);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Language Delete Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
            }
        }

        public void UpdateSystemCountryCode(SystemCountryCodePoco[] list)
        {
            try
            {
                SystemCountryCodeLogic logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
                logic.Update(list);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Country Update Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
            }
        }

        public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] list)
        {
            try
            {
                SystemLanguageCodeLogic logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
                logic.Update(list);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Language Update Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
            }
        }
    }
}
