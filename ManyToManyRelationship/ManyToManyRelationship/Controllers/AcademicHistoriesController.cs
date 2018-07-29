using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManyToManyRelationship.Models;

namespace ManyToManyRelationship.Controllers
{
    public class AcademicHistoriesController : Controller
    {
        private MtoMRelContext db = new MtoMRelContext();

        // GET: AcademicHistories
        public ActionResult Index()
        {
            return View(db.AcademicHistories.ToList());
        }

        // GET: AcademicHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicHistory academicHistory = db.AcademicHistories.Find(id);
            if (academicHistory == null)
            {
                return HttpNotFound();
            }
            return View(academicHistory);
        }

        // GET: AcademicHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AcademicHistoryId,Degree,Institute,Subject,PassingYear")] AcademicHistory academicHistory)
        {
            if (ModelState.IsValid)
            {
                db.AcademicHistories.Add(academicHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicHistory);
        }

        // GET: AcademicHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicHistory academicHistory = db.AcademicHistories.Find(id);
            if (academicHistory == null)
            {
                return HttpNotFound();
            }
            return View(academicHistory);
        }

        // POST: AcademicHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcademicHistoryId,Degree,Institute,Subject,PassingYear")] AcademicHistory academicHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicHistory);
        }

        // GET: AcademicHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicHistory academicHistory = db.AcademicHistories.Find(id);
            if (academicHistory == null)
            {
                return HttpNotFound();
            }
            return View(academicHistory);
        }

        // POST: AcademicHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicHistory academicHistory = db.AcademicHistories.Find(id);
            db.AcademicHistories.Remove(academicHistory);
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
