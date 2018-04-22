using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CareerCloud.Pocos;
using System.Data.Entity.Infrastructure.Interception;
using System.Configuration;
namespace CareerCloud.EntityFrameworkDataAccess
{

    public class CareerCloudContext : DbContext
    {
        /* ... to be removed on assignment delivery*/
        private static bool isDbInterceptionInitialised = false;

        public CareerCloudContext(bool proxyEnabled =true) : base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {

            Configuration.ProxyCreationEnabled = proxyEnabled; // for preventing xml serilization recursivity.
            if (!isDbInterceptionInitialised)
            {
                // if want to log sql queries , just unmarked two line
                //DbInterception.Add(new InsertUpdateInterceptor());
                //isDbInterceptionInitialised = true;
            }
        }
        /* ... to be removed on assignment delivery*/

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
        public virtual DbSet<ApplicantResumePoco> ApplicantResumePocoes { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (OnDisposed != null) OnDisposed(this, null);
        }

        public event EventHandler OnDisposed;
    }
}
