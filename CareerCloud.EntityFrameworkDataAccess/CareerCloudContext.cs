using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{

    public class CareerCloudContext : DbContext
    {
        public CareerCloudContext() : base("name=dbconnection")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<ApplicantEducationPoco> ApplicantEducations{ get; set; }
        public virtual DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications{ get; set; }
        public virtual DbSet<ApplicantProfilePoco> ApplicantProfiles{ get; set; }
        public virtual DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public virtual DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public virtual DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public virtual DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public virtual DbSet<CompanyJobDescriptionPoco> CompanyJobsDescriptions { get; set; }
        public virtual DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public virtual DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public virtual DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public virtual DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public virtual DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public virtual DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public virtual DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public virtual DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }





    }
}