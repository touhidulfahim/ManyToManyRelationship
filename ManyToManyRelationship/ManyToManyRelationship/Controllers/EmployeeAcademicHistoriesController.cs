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
    public class EmployeeAcademicHistoriesController : Controller
    {
        private MtoMRelContext db = new MtoMRelContext();

        // GET: EmployeeAcademicHistories
        public ActionResult Index()
        {
            var employeeAcademicHistories = db.EmployeeAcademicHistories.Include(e => e.AcademicHistory).Include(e => e.Employee);
            return View(employeeAcademicHistories.ToList());
        }

        // GET: EmployeeAcademicHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAcademicHistory employeeAcademicHistory = db.EmployeeAcademicHistories.Find(id);
            if (employeeAcademicHistory == null)
            {
                return HttpNotFound();
            }
            return View(employeeAcademicHistory);
        }

        // GET: EmployeeAcademicHistories/Create
        public ActionResult Create()
        {
            ViewBag.AcademicHistoryId = new SelectList(db.AcademicHistories, "AcademicHistoryId", "Degree");
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: EmployeeAcademicHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,AcademicHistoryId")] EmployeeAcademicHistory employeeAcademicHistory)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeAcademicHistories.Add(employeeAcademicHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicHistoryId = new SelectList(db.AcademicHistories, "AcademicHistoryId", "Degree", employeeAcademicHistory.AcademicHistoryId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeAcademicHistory.EmployeeId);
            return View(employeeAcademicHistory);
        }

        // GET: EmployeeAcademicHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAcademicHistory employeeAcademicHistory = db.EmployeeAcademicHistories.Find(id);
            if (employeeAcademicHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicHistoryId = new SelectList(db.AcademicHistories, "AcademicHistoryId", "Degree", employeeAcademicHistory.AcademicHistoryId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeAcademicHistory.EmployeeId);
            return View(employeeAcademicHistory);
        }

        // POST: EmployeeAcademicHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,AcademicHistoryId")] EmployeeAcademicHistory employeeAcademicHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAcademicHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicHistoryId = new SelectList(db.AcademicHistories, "AcademicHistoryId", "Degree", employeeAcademicHistory.AcademicHistoryId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeAcademicHistory.EmployeeId);
            return View(employeeAcademicHistory);
        }

        // GET: EmployeeAcademicHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAcademicHistory employeeAcademicHistory = db.EmployeeAcademicHistories.Find(id);
            if (employeeAcademicHistory == null)
            {
                return HttpNotFound();
            }
            return View(employeeAcademicHistory);
        }

        // POST: EmployeeAcademicHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeAcademicHistory employeeAcademicHistory = db.EmployeeAcademicHistories.Find(id);
            db.EmployeeAcademicHistories.Remove(employeeAcademicHistory);
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
