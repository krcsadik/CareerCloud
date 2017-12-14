﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Applicant_Resumes")]
    public class ApplicantResumePoco : IPoco
    {
        private Guid varId;
        private Guid varApplicant;
        private String varResume;
        private DateTime? varLastUpdated;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        public Guid Applicant { get { return varApplicant; } set { varApplicant = value; } }
        public String Resume { get { return varResume; } set { varResume = value; } }
        [Column("Last_Updated")]
        public DateTime? LastUpdated { get { return varLastUpdated; } set { varLastUpdated= value; } }
    }
}
