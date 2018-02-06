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
    public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
    {
        public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantJobApplicationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
        
            foreach (var poco in pocos)
            {
                if (! CheckApplicationDate(poco))
                {
                    exceptions.Add(new ValidationException(110, $"ApplicationDate for ApplicantJobApplication {poco.Id} cannot be greater than today"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckApplicationDate(ApplicantJobApplicationPoco poco)
        {
            bool result = false;
            int resultDayDiff = DateTime.Compare((DateTime)poco.ApplicationDate, DateTime.Now);
            if (resultDayDiff <= 0)
            {
                result = true;
            }
            return result;
        }
    }
}