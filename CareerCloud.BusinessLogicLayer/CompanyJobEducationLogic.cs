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
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyJobEducationPoco poco in pocos)
            {
                if (!CheckMajorValue(poco))
                {
                    exceptions.Add(new ValidationException(200, $"Major for CompanyJobEducation {poco.Id} must be at least 2 characters"));
                }
                if (!CheckImportance(poco))
                {
                    exceptions.Add(new ValidationException(201, $"Importance for CompanyJobEducation {poco.Id} cannot be less than 0"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckImportance(CompanyJobEducationPoco poco)
        {
            bool result = false;

            if (poco.Importance>=0)
            {
                result = true;
            }
            return result;
        }
        private bool CheckMajorValue(CompanyJobEducationPoco poco)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(poco.Major))
            {
                if (poco.Major.Length > 2)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}


