using System;
using System.Collections.Generic;
using System.Linq;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using System.Reflection;
using System.ServiceModel;


namespace CareerCloud.WCF
{
    public class LogicBridge<T1, T2> : IDisposable
            where T1 : class, IPoco
            where T2 : BaseLogic<T1>

    {
        private IDataRepository<T1> dataRepo = new EFGenericRepository<T1>(false);
        public void Add(T1[] list)
        {
            try
            {
                BaseLogic<T1> classInstance = CreateLogic();
                classInstance.Add(list);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Create Record Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
            }
        }

        public T1[] GetAll()
        {
            try
            {
                BaseLogic<T1> classInstance = CreateLogic();
                return classInstance.GetAll().ToArray();
            }
            catch (Exception err)
            {
                ValidationFault fault = new ValidationFault();
                fault.Result = false;
                fault.Message = "Read All Problem";
                fault.Description = err.Message;
                FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                throw fe;
            }
        }


        public void Update(T1[] list)
        {
            try
            {
                BaseLogic<T1> classInstance = CreateLogic();
                classInstance.Update(list);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Update Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
            }
        }

        public void Delete(T1[] list)
        {
            try
            {
                BaseLogic<T1> classInstance = CreateLogic();
                classInstance.Delete(list);
            }
            catch (AggregateException e)
            {
                List<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>().ToList();
                foreach (ValidationException err in exceptions)
                {
                    ValidationFault fault = new ValidationFault();
                    fault.Result = false;
                    fault.Message = "Delete Problem";
                    fault.Description = err.Message;
                    FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                    throw fe;
                }
            }
        }
        public T1 GetSingle(String Id)
        {
            try
            {
                BaseLogic<T1> classInstance = CreateLogic();
                // You must close or flush the trace to empty the output buffer.  
                return classInstance.Get(Guid.Parse(Id));
            }
            catch (Exception err)
            {
                ValidationFault fault = new ValidationFault();
                fault.Result = false;
                fault.Message = "Read Problem";
                fault.Description = err.Message;
                FaultException<ValidationFault> fe = new FaultException<ValidationFault>(fault, new FaultReason(fault.Message));
                throw fe;
            }
        }

        // special constructor invoking method !
        private T2 CreateLogic()
        {
            try
            {
                Type classType = typeof(T2);
                ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { dataRepo.GetType() });
                return classConstructor.Invoke(new object[] { dataRepo }) as T2;
            }
            catch (Exception e)
            {

                ValidationFault fault = new ValidationFault();
                fault.Result = false;
                fault.Message = "Service Repository initializing problem";
                fault.Description = e.Message;
                throw new FaultException<ValidationFault>(fault);
            }
        }

        public void Dispose()
        {
            if (dataRepo != null)
            {
                dataRepo = null;
            }
        }
    }
}