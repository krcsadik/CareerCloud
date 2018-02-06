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
    public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
    {
        public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyJobDescriptionPoco poco in pocos)
            {
                if (!CheckJobName(poco))
                {
                    exceptions.Add(new ValidationException(300, $"JobName for CompanyJobDescription {poco.Id} cannot be empty"));
                }
                if (!CheckJobDescription(poco))
                {
                    exceptions.Add(new ValidationException(301, $"JobDescription for CompanyJobDescription {poco.Id} cannot be empty"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckJobName(CompanyJobDescriptionPoco poco)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(poco.JobName))
            {
                result = true;
            }
            return result;
        }
        private bool CheckJobDescription(CompanyJobDescriptionPoco poco)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(poco.JobDescriptions))
            {
                result = true;
            }
            return result;
        }
    }
}


