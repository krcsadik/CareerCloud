using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic 
    {
        protected IDataRepository<SystemLanguageCodePoco> _repository;
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository) 
        {
            _repository = repository;
        }

        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }

        public void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }
        public SystemLanguageCodePoco Get(string languageID)
        {

            var item = _repository.GetSingle(c => c.LanguageID== languageID);
            return item;
        }

        public List<SystemLanguageCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Delete(SystemLanguageCodePoco[] pocos)
        {
            _repository.Remove(pocos);
        }

        protected void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemLanguageCodePoco poco in pocos)
            {
                if (!CheckLanguageID(poco))
                {
                    exceptions.Add(new ValidationException(1000, $"LanguageID for SystemLanguageCode {poco.LanguageID} cannot be empty"));
                }
                if (!CheckName(poco))
                {
                    exceptions.Add(new ValidationException(1001, $"Name for SystemLanguageCode {poco.LanguageID} cannot be empty"));
                }
                if (!CheckNativeName(poco))
                {
                    exceptions.Add(new ValidationException(1002, $"NativeName for SystemLanguageCode {poco.LanguageID} cannot be empty"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckLanguageID(SystemLanguageCodePoco poco)
        {
            bool result = true;
            if (string.IsNullOrEmpty(poco.LanguageID))
            {
                result = false;
            }
            return result;
        }
        private bool CheckName(SystemLanguageCodePoco poco)
        {
            bool result = true;
            if (string.IsNullOrEmpty(poco.Name))
            {
                result = false;
            }
            return result;
        }
        private bool CheckNativeName(SystemLanguageCodePoco poco)
        {
            bool result = true;
            if (string.IsNullOrEmpty(poco.NativeName))
            {
                result = false;
            }
            return result;
        }
    }
}