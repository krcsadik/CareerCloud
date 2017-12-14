using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos    
{
    [Table("Applicant_Work_History")]
    public class ApplicantWorkHistoryPoco : IPoco
    {
        private Guid varId;
        private Guid varApplicant;
        private String varCompanyName;
        private String varCountryCode;
        private String varLocation;
        private String varJobTitle;
        private String varJobDescription;
        private Int16 varStartMonth;
        private Int32 varStartYear;
        private Int16 varEndMonth;
        private Int32 varEndYear;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }
        [Column("Company_Name")]
        public String CompanyName { get { return varCompanyName; } set { varCompanyName = value; } }
        [Column("Country_Code")]
        public String CountryCode { get { return varCountryCode; } set { varCountryCode = value; } }
        public String Location { get { return varLocation; } set { varLocation = value; } }
        [Column("Job_Title")]
        public String JobTitle { get { return varJobTitle; } set { varJobTitle = value; } }
        [Column("Job_Description")]
        public String JobDescription { get { return varJobDescription; } set { varJobDescription = value; } }
        [Column("Start_Month")]
        public Int16 StartMonth { get { return varStartMonth; } set { varStartMonth = value; } }
        [Column("Start_Year")]
        public Int32 StartYear { get { return varStartYear; } set { varStartYear = value; } }
        [Column("End_Month")]
        public Int16 EndMonth { get { return varEndMonth; } set { varEndMonth = value; } }
        [Column("End_Year")]
        public Int32 EndYear { get { return varEndYear; } set { varEndYear = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}