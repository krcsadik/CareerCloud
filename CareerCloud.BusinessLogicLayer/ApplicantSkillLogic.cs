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
    public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantSkillPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (ApplicantSkillPoco poco in pocos)
            {
                if (!CheckStartMonth(poco))
                {
                    exceptions.Add(new ValidationException(101, $"StartMonth for ApplicantSkill {poco.Id} cannot be greater than 12"));
                }
                if (!CheckEndMonth(poco))
                {
                    exceptions.Add(new ValidationException(102, $"EndMonth for ApplicantSkill {poco.Id} cannot be greater than 12"));
                }
                if (!CheckStartYear(poco))
                {
                    exceptions.Add(new ValidationException(103, $"StartYear for ApplicantSkill {poco.Id} cannot be less then 1900"));
                }
                if (!CheckEndYear(poco))
                {
                    exceptions.Add(new ValidationException(104, $"EndYear for ApplicantSkill {poco.Id} cannot be less then StartYear"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        private bool CheckStartMonth(ApplicantSkillPoco poco)
        {
            bool result = true;
            if  (poco.StartMonth>12)
            {
                result = false;
            }
            return result;
        }
        private bool CheckEndMonth(ApplicantSkillPoco poco)
        {
            bool result = true;
            if (poco.EndMonth > 12)
            {
                result = false;
            }
            return result;
        }
        private bool CheckStartYear(ApplicantSkillPoco poco)
        {
            bool result = true;
            if (poco.StartYear < 1900)
            {
                result = false;
            }
            return result;
        }
        private bool CheckEndYear(ApplicantSkillPoco poco)
        {
            bool result = true;
            if (poco.EndYear< poco.StartYear )
            {
                result = false;
            }
            return result;
        }
    }
}


