using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OutputCacheDemo.Models;

namespace OutputCacheDemo.Controllers
{
    public class EmployeeJKsController : Controller
    {
        private DotnetF1Entities db = new DotnetF1Entities();

        // GET: EmployeeJKs
        [OutputCache(Duration =10)]
        public ActionResult Index()
        {
            return View(db.EmployeeJKs.ToList());
        }

        // GET: EmployeeJKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeJK employeeJK = db.EmployeeJKs.Find(id);
            if (employeeJK == null)
            {
                return HttpNotFound();
            }
            return View(employeeJK);
        }

        // GET: EmployeeJKs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeJKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmpName,Gender,Salary,Designation,DeptId")] EmployeeJK employeeJK)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeJKs.Add(employeeJK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeJK);
        }

        // GET: EmployeeJKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeJK employeeJK = db.EmployeeJKs.Find(id);
            if (employeeJK == null)
            {
                return HttpNotFound();
            }
            return View(employeeJK);
        }

        // POST: EmployeeJKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmpName,Gender,Salary,Designation,DeptId")] EmployeeJK employeeJK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeJK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeJK);
        }

        // GET: EmployeeJKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeJK employeeJK = db.EmployeeJKs.Find(id);
            if (employeeJK == null)
            {
                return HttpNotFound();
            }
            return View(employeeJK);
        }

        // POST: EmployeeJKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeJK employeeJK = db.EmployeeJKs.Find(id);
            db.EmployeeJKs.Remove(employeeJK);
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
