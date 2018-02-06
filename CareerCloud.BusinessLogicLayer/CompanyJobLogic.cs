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
    public class CompanyJobLogic : BaseLogic<CompanyJobPoco>
    {
        public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyJobPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyJobPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyJobPoco poco in pocos)
            {
                if (!CheckMajorValue(poco))
                {
                    exceptions.Add(new ValidationException(107, "Cannot be empty or less than 3 characters"));
                }
                if (!CheckStartDate(poco))
                {
                    exceptions.Add(new ValidationException(108, "Cannot be greater than today"));
                }
                if (!CheckCompletionDate(poco))
                {
                    exceptions.Add(new ValidationException(109, "CompletionDate cannot be earlier than StartDate"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        private bool CheckMajorValue(CompanyJobPoco poco)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(poco.Major))
            {
                if (poco.Major.Length >= 3)
                {
                    result = true;
                }
            }
            return result;
        }
        private bool CheckStartDate(CompanyJobPoco poco)
        {
            bool result = false;
            if (poco.StartDate.HasValue)
            {
                if (!(poco.StartDate < System.DateTime.Today))
                {
                    result = true;
                }
            }
            else result = true; // if no value don't block

            return result;
        }
        private bool CheckCompletionDate(CompanyJobPoco poco)
        {
            bool result = false;
            if (poco.CompletionDate.HasValue && poco.StartDate.HasValue)
            {
                if (!(poco.CompletionDate > poco.StartDate))
                {
                    result = true;
                }
            }
            else result = true; // if no value don't block

            return result;
        }

    }
}


