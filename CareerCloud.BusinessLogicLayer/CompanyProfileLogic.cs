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
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyProfilePoco poco in pocos)
            {
                if (!CheckContactPhone(poco))
                {
                    exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} must correspond to a valid phone number (e.g. 416-555-1234)"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckContactPhone(CompanyProfilePoco poco)
        {
            bool result = true;
            string[] phoneComponents = poco.ContactPhone.Split('-');
            if (phoneComponents.Length < 3)
            {
                result = false;
            }
            else
            {
                if (phoneComponents[0].Length < 3)
                {
                    result = false;
                }
                else if (phoneComponents[1].Length < 3)
                {
                    result = false;
                }
                else if (phoneComponents[2].Length < 4)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}


