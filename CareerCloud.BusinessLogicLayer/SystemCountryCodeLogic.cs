﻿using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic 
    {
        protected IDataRepository<SystemCountryCodePoco> _repository;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) 
        {
            _repository = repository;
        }

        public  void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }

        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }

        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (!CheckCode(poco))
                {
                    exceptions.Add(new ValidationException(900, $"Code for SystemCountryCode {poco.Code} cannot be empty"));
                }
                if (!CheckName(poco))
                {
                    exceptions.Add(new ValidationException(901, $"Name for SystemCountryCode {poco.Code} cannot be empty"));
                }

            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckCode(SystemCountryCodePoco poco)
        {
            bool result =true;
            if (string.IsNullOrEmpty(poco.Code))
            {
               result = false;
            }
            return result;
        }
        private bool CheckName(SystemCountryCodePoco poco)
        {
            bool result = true;
            if (string.IsNullOrEmpty(poco.Name))
            {
                result = false;
            }
            return result;
        }
    }
}


