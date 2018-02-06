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
    public class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
    {
        public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {

                if (! CheckSalary(poco))
                {
                    exceptions.Add(new ValidationException(111, $"CurrentSalary for ApplicantProfile {poco.Id} cannot be negative"));
                }
                if (! CheckRate(poco))
                {
                    exceptions.Add(new ValidationException(112, $"CurrentRate for ApplicantProfile {poco.Id} cannot be negative"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckSalary(ApplicantProfilePoco poco)
        {
            bool result = true;
            if (poco.CurrentSalary.HasValue)
            {
                if (poco.CurrentSalary < 0)
                {
                    result = false;
                }
            }
            return result;
        }
        private bool CheckRate(ApplicantProfilePoco poco)
        {
            bool result = true;
            if (poco.CurrentRate.HasValue)
            {
                if (poco.CurrentRate < 0)
                {
                    result = false;
                }
            }
            return result;
        }


    }
}