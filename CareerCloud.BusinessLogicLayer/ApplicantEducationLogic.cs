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
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (ApplicantEducationPoco poco in pocos)
            {
                if (!CheckMajorValue(poco))
                {
                    exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Id} cannot be empty or less than 3 characters"));
                }
                if (!CheckStartDate(poco))
                {
                    exceptions.Add(new ValidationException(108, $"StartDate for ApplicantEducation {poco.Id} cannot be greater than today"));
                }
                if (!CheckCompletionDate(poco))
                {
                    exceptions.Add(new ValidationException(109, $"CompletionDate for ApplicantEducation {poco.Id} cannot be greater than StartDate"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        private bool CheckMajorValue(ApplicantEducationPoco poco)
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
        private bool CheckStartDate(ApplicantEducationPoco poco)
        {
            bool result = true;
            if (poco.StartDate.HasValue)
            {
                int resultDayDiff = DateTime.Compare((DateTime)poco.StartDate, DateTime.Now);
                if (resultDayDiff > 0)
                {
                    result = false;
                }
            }
            return result;
        }
        private bool CheckCompletionDate(ApplicantEducationPoco poco)
        {
            bool result = true;
            if (poco.CompletionDate.HasValue && poco.StartDate.HasValue)
            {
                int resultDayDiff = DateTime.Compare((DateTime)poco.CompletionDate, (DateTime)poco.StartDate);
                if (resultDayDiff <0)
                {
                    result = false;
                }
            }
            return result;
        }

    }
}


