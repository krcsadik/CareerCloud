using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.MVC.Models;
using System.Linq.Expressions;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantController : Controller
    {

        public ActionResult ListJobs()
        {
            IEnumerable<CompanyJobPoco> companyJobList = null;

            //In different menu step always clear other menu temp data's
            TempData.Keep("ListJobsAppliedModel");

            if (TempData["ListJobsModel"] == null)
            {
                IDataRepository<CompanyJobPoco> repoCompanyJob = new MvcLogic<CompanyJobPoco>().Repo;
                IList<Guid> companyFullIdJobList = repoCompanyJob.GetList(c => (c.IsInactive == false) && (c.IsCompanyHidden == false)).Select(c => c.Id).ToList();

                companyJobList = repoCompanyJob.GetList(c => companyFullIdJobList.Contains(c.Id),
                    c => c.CompanyJobsDescriptions,
                    c => c.CompanyProfiles
                    );
                TempData["ListJobsModel"] = companyJobList;

            }
            else
            {
                companyJobList = TempData["ListJobsModel"] as IEnumerable<CompanyJobPoco>;
                TempData.Keep("ListJobsModel");
            }

            return View(companyJobList);
        }
        public ActionResult JobDetails(Guid? id)
        {
            CompanyJobPoco companyJobPoco = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (TempData["ListJobsModel"] != null)
            {
                IEnumerable<CompanyJobPoco> companyJobList = (IEnumerable<CompanyJobPoco>)TempData["ListJobsModel"];
                companyJobPoco = companyJobList.Where(c => c.Id == id).FirstOrDefault();
                if (companyJobPoco == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TempData.Keep("ListJobsModel");
            }
            else
            {
                IDataRepository<CompanyJobPoco> repoCompanyJob = new MvcLogic<CompanyJobPoco>().Repo;
                companyJobPoco = repoCompanyJob.GetSingle(c=>c.Id==id);

                if (companyJobPoco == null)
                {
                    return HttpNotFound();
                }
            }
            if (TempData["JobDetailsModel"] == null)
            {
                TempData["JobDetailsModel"] = companyJobPoco;
            }
            return View(companyJobPoco);
        }
        // POST: ApplicantJobApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyJob([Bind(Include = "Id")] CompanyJobPoco bindCompanyJobPoco)
        {
            bool bSuccess = false;
            if (ModelState.IsValid)
            {

                IDataRepository<ApplicantJobApplicationPoco> repoApplicantJob = new MvcLogic<ApplicantJobApplicationPoco>().Repo;

                ApplicantJobApplicationLogic logic = new ApplicantJobApplicationLogic(repoApplicantJob);
                
                List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();

                ApplicantJobApplicationPoco item = new ApplicantJobApplicationPoco();

                item.Job = bindCompanyJobPoco.Id;
                item.ApplicationDate = DateTime.Now;

                if (this.Session["_ApplicantId"] != null)
                {
                    var y = this.Session["_ApplicantId"];
                    Guid newVal;
                    Guid.TryParse(y.ToString(), out newVal);
                    item.Applicant = newVal;
                }

                pocos.Add(item);

                try
                {
                    logic.Add(pocos.ToArray());
                    bSuccess = true;
                }
                catch (AggregateException e)
                {
                    IEnumerable<ValidationException> exceptions = e.InnerExceptions.Cast<ValidationException>();
                    if (exceptions != null)
                    {
                        foreach (ValidationException exc in exceptions)
                        {
                            ModelState.AddModelError(exc.Code.ToString(), exc.Message.ToString());
                        }
                    }
                }
            }
            if (bSuccess)
            {
                ViewBag.AlertMessage = "Job Application is successfully done" ;
                ViewBag.SuccessMessage = "Job Application is successfully done"; //+ ((char)251);  // ascii 251 is check sign !
                //Keep track of Applied Jobs
                if (this.Session["_ApplicationGuidList"] != null)
                {
                    ((List<Guid>)this.Session["_ApplicationGuidList"]).Add(bindCompanyJobPoco.Id);
                }
            }
            else
            {
                ViewBag.AlertMessage = "Job Application could not be done! Check validation messages";
            }

            CompanyJobPoco companyJobPoco = (CompanyJobPoco)TempData["JobDetailsModel"];
            TempData.Keep("JobDetailsModel");
            
            return View("JobDetails",companyJobPoco); 
        }
        // Shows applied job list for the current applicant  
        public ActionResult ListJobsApplied()
        {
            IEnumerable<ApplicantJobApplicationPoco> appliedJobsFullJobList = null;
            //In different menu step always clear other menu temp data's
            TempData.Keep("ListJobsModel");
            TempData.Keep("JobDetailsModel");

            if (TempData["ListJobsAppliedModel"] == null)
            {
                IDataRepository<ApplicantJobApplicationPoco> repoAppliedJob = new MvcLogic<ApplicantJobApplicationPoco>().Repo;
                appliedJobsFullJobList = repoAppliedJob.GetAll();

                TempData["ListJobsAppliedModel"] = appliedJobsFullJobList;
            }
            else
            {
                appliedJobsFullJobList = TempData["ListJobsAppliedModel"] as IEnumerable<ApplicantJobApplicationPoco>;
                TempData.Keep("ListJobsAppliedModel");
            }
            ViewBag.ShowAppliedJobs = true;
            return View("ListJobsApplied", appliedJobsFullJobList); 
        }


        public ActionResult JobDetailsApplied(Guid? id)
        {
            ApplicantJobApplicationPoco applicantJobApplicationPoco = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (TempData["ListJobsAppliedModel"] != null)
            {
                IEnumerable<ApplicantJobApplicationPoco> appliedJobList = (IEnumerable<ApplicantJobApplicationPoco>)TempData["ListJobsAppliedModel"];
                applicantJobApplicationPoco = appliedJobList.Where(c => c.Id == id).FirstOrDefault();
                if (applicantJobApplicationPoco == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TempData.Keep("ListJobsAppliedModel");
            }
            else
            {
                IDataRepository<ApplicantJobApplicationPoco> repoAppliedJob = new MvcLogic<ApplicantJobApplicationPoco>().Repo;
                applicantJobApplicationPoco = repoAppliedJob.GetSingle(c => c.Id == id);

                if (applicantJobApplicationPoco == null)
                {
                    return HttpNotFound();
                }
            }
 
            return View(applicantJobApplicationPoco);
        }

    }
}
