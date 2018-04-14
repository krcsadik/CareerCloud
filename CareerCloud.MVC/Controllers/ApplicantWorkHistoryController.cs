﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantWorkHistoryController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantWorkHistory
        public ActionResult Index()
        {
            var applicantWorkHistories = db.ApplicantWorkHistories.Include(a => a.ApplicantProfiles).Include(a => a.SystemCountryCodes);
            return View(applicantWorkHistories.ToList());
        }

        // GET: ApplicantWorkHistory/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = db.ApplicantWorkHistories.Find(id);
            if (applicantWorkHistoryPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantWorkHistoryPoco);
        }

        // GET: ApplicantWorkHistory/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency");
            ViewBag.CountryCode = new SelectList(db.SystemCountryCodes, "Code", "Name");
            return View();
        }

        // POST: ApplicantWorkHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,CompanyName,CountryCode,Location,JobTitle,JobDescription,StartMonth,StartYear,EndMonth,EndYear,TimeStamp")] ApplicantWorkHistoryPoco applicantWorkHistoryPoco)
        {
            if (ModelState.IsValid)
            {
                applicantWorkHistoryPoco.Id = Guid.NewGuid();
                db.ApplicantWorkHistories.Add(applicantWorkHistoryPoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency", applicantWorkHistoryPoco.Applicant);
            ViewBag.CountryCode = new SelectList(db.SystemCountryCodes, "Code", "Name", applicantWorkHistoryPoco.CountryCode);
            return View(applicantWorkHistoryPoco);
        }

        // GET: ApplicantWorkHistory/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = db.ApplicantWorkHistories.Find(id);
            if (applicantWorkHistoryPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency", applicantWorkHistoryPoco.Applicant);
            ViewBag.CountryCode = new SelectList(db.SystemCountryCodes, "Code", "Name", applicantWorkHistoryPoco.CountryCode);
            return View(applicantWorkHistoryPoco);
        }

        // POST: ApplicantWorkHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,CompanyName,CountryCode,Location,JobTitle,JobDescription,StartMonth,StartYear,EndMonth,EndYear,TimeStamp")] ApplicantWorkHistoryPoco applicantWorkHistoryPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantWorkHistoryPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfiles, "Id", "Currency", applicantWorkHistoryPoco.Applicant);
            ViewBag.CountryCode = new SelectList(db.SystemCountryCodes, "Code", "Name", applicantWorkHistoryPoco.CountryCode);
            return View(applicantWorkHistoryPoco);
        }

        // GET: ApplicantWorkHistory/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = db.ApplicantWorkHistories.Find(id);
            if (applicantWorkHistoryPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantWorkHistoryPoco);
        }

        // POST: ApplicantWorkHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = db.ApplicantWorkHistories.Find(id);
            db.ApplicantWorkHistories.Remove(applicantWorkHistoryPoco);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
