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
    public class CompanyController : Controller
    {
        Guid _demoCompanyId =Guid.Empty;
        IDataRepository<CompanyJobPoco> _repoCompanyJob = null;
        public CompanyController()
        {
            _repoCompanyJob = new MvcLogic<CompanyJobPoco>().Repo;
        }
        
        public ActionResult ListJobs()
        {
            IEnumerable<CompanyJobPoco> companyJobList = null;

            //In different menu step always clear other menu temp data's
            TempData.Keep("ListJobsModel");
            _demoCompanyId = (Guid)this.Session["_CompanyId"];

            if (TempData["ListJobsModelPerCompany"] == null)
            {
                ;

                companyJobList = _repoCompanyJob.GetList(
                             c => (c.IsInactive == false) &&
                                  (c.IsCompanyHidden == false) &&
                                  (c.Company == _demoCompanyId),
                    c => c.CompanyJobsDescriptions,
                    c => c.CompanyProfiles
                    );
                TempData["ListJobsModelPerCompany"] = companyJobList;

            }
            else
            {
                companyJobList = TempData["ListJobsModelPerCompany"] as IEnumerable<CompanyJobPoco>;
                TempData.Keep("ListJobsModelPerCompany");
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

            if (TempData["ListJobsModelPerCompany"] != null)
            {
                IEnumerable<CompanyJobPoco> companyJobList = (IEnumerable<CompanyJobPoco>)TempData["ListJobsModelPerCompany"];
                companyJobPoco = companyJobList.Where(c => c.Id == id).FirstOrDefault();
                if (companyJobPoco == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TempData.Keep("ListJobsModelPerCompany");
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
            if (TempData["JobDetailsModelPerCompany"] == null)
            {
                TempData["JobDetailsModelPerCompany"] = companyJobPoco;
            }
            return View(companyJobPoco);
        }

        public ActionResult ListAppliers(Guid id)
        {
            throw new NotImplementedException();
        }

        // GET: ApplicantResume/Create
        public ActionResult Create()
        {
            CompanyJobPoco companyJobPoco = new CompanyJobPoco();
            //ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency");
            return View(companyJobPoco);

            //return View();
        }

        // POST: ApplicantResume/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Resume,LastUpdated")] ApplicantResumePoco applicantResumePoco)
        {
            //if (ModelState.IsValid)
            //{
            //    applicantResumePoco.Id = Guid.NewGuid();
            //    db.ApplicantResumePocoes.Add(applicantResumePoco);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency", applicantResumePoco.Applicant);
            return View(applicantResumePoco);
        }

        // GET: ApplicantResume/Edit/5
        public ActionResult Edit(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApplicantResumePoco applicantResumePoco = db.ApplicantResumePocoes.Find(id);
            //if (applicantResumePoco == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency", applicantResumePoco.Applicant);
            //return View(applicantResumePoco);
            return View();
        }

        // POST: ApplicantResume/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Resume,LastUpdated")] ApplicantResumePoco applicantResumePoco)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(applicantResumePoco).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency", applicantResumePoco.Applicant);
            return View(applicantResumePoco);
        }

        // GET: ApplicantResume/Delete/5
        public ActionResult Delete(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApplicantResumePoco applicantResumePoco = db.ApplicantResumePocoes.Find(id);
            //if (applicantResumePoco == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(applicantResumePoco);
            return View();
        }

        // POST: ApplicantResume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //ApplicantResumePoco applicantResumePoco = db.ApplicantResumePocoes.Find(id);
            //db.ApplicantResumePocoes.Remove(applicantResumePoco);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
