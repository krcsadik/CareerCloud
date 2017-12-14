﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        private Guid varId;
        private Guid varApplicant;
        private Guid varJob;
        private DateTime varApplicationDate;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }
        public Guid Job { get { return varJob; } set { varJob = value; } }
        [Column("Application_Date")]
        public DateTime ApplicationDate { get { return varApplicationDate; } set { varApplicationDate = value; } }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
    }
}