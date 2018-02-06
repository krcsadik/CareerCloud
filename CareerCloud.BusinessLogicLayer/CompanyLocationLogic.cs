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
    public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyLocationPoco poco in pocos)
            {
                if (!CheckCountryCode(poco))
                {
                    exceptions.Add(new ValidationException(500, $"CountryCode for CompanyLocation {poco.Id} cannot be empty"));
                }
                if (!CheckProvince(poco))
                {
                    exceptions.Add(new ValidationException(501, $"Province for CompanyLocation {poco.Id} cannot be empty"));
                }
                if (!CheckStreet(poco))
                {
                    exceptions.Add(new ValidationException(502, $"Street for CompanyLocation {poco.Id} cannot be empty"));
                }
                if (!CheckCity(poco))
                {
                    exceptions.Add(new ValidationException(503, $"City for CompanyLocation {poco.Id} cannot be empty"));
                }
                if (!CheckPostalCode(poco))
                {
                    exceptions.Add(new ValidationException(504, $"PostalCode for CompanyLocation {poco.Id} cannot be empty"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckCountryCode(CompanyLocationPoco poco)
        {
            bool result = true;
            if (string.IsNullOrEmpty(poco.CountryCode))
            {
               result = false;
            }
            return result;
        }
        private bool CheckProvince(CompanyLocationPoco poco)
        {
            bool result = true;
            if (string.IsNullOrEmpty(poco.Province))
            {
                result = false;
            }
            return result;
        }
        private bool CheckStreet(CompanyLocationPoco poco)
        {
            bool result = true;
            if (string.IsNullOrEmpty(poco.Street))
            {
                result = false;
            }
            return result;
        }
        private bool CheckCity(CompanyLocationPoco poco)
        {
            bool result = true;
            if (string.IsNullOrEmpty(poco.City))
            {
                result = false;
            }
            return result;
        }
        private bool CheckPostalCode(CompanyLocationPoco poco)
        {
            bool result = true;
            if (string.IsNullOrEmpty(poco.PostalCode))
            {
                result = false;
            }
            return result;
        }
    }
}