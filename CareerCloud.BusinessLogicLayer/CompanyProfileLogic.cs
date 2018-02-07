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
                if (!CheckWebSite(poco))
                {
                    exceptions.Add(new ValidationException(600, $"WebSite for CompanyProfile {poco.Id}  must end with the following extensions – \".ca\", \".com\", \".biz\""));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckContactPhone(CompanyProfilePoco poco)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(poco.ContactPhone))
            {
                string[] phoneComponents = poco.ContactPhone.Split('-');
                if (phoneComponents.Length >2)
                {
                    result = true;
                }
                else
                {
                    bool bCheck = true;
                    if (phoneComponents[0].Length < 3)
                    {
                        bCheck = false;
                    }
                    if (bCheck  && phoneComponents[1].Length < 3)
                    {
                        bCheck= false;
                    }
                    if (bCheck && phoneComponents[2].Length < 4)
                    {
                        bCheck= false;
                    }
                    result = bCheck;
                }
            }
            return result;
        }
        private bool CheckWebSite(CompanyProfilePoco poco)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(poco.CompanyWebsite))
            {
                string[] webSiteComponents = poco.CompanyWebsite.Split('.');
                if (webSiteComponents.Length >= 2)
                {
                    string suffix = webSiteComponents[webSiteComponents.Length - 1];
                    suffix = suffix.TrimEnd('\\').ToUpper();
                    result = true;
                    switch (suffix)
                    {
                        case "CA":
                            break;
                        case "COM":
                            break;
                        case "BIZ":
                            break;
                        default:
                            result = false;
                            break;
                    }
                }
            }
            return result;
        }
    }

}