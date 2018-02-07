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
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyDescriptionPoco poco in pocos)
            {
                if (!CheckCompanyName(poco))
                {
                    exceptions.Add(new ValidationException(106, $"CompanyName for CompanyDescription {poco.Id} must be greater than 2 characters"));
                }
                if (!CheckCompanyDescription(poco))
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription for CompanyDescription {poco.Id} must be greater than 2 characters"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckCompanyName(CompanyDescriptionPoco poco)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(poco.CompanyName))
            {
                if (poco.CompanyName.Length > 2)
                {
                    result = true;
                }
            }
            return result;
        }
        private bool CheckCompanyDescription(CompanyDescriptionPoco poco)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(poco.CompanyDescription))
            {
                if (poco.CompanyDescription.Length > 2)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}


