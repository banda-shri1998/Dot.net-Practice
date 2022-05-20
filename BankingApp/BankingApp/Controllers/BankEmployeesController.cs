using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankingApp.Models;

namespace BankingApp.Controllers
{
    [Authorize]
    public class BankEmployeesController : Controller
    {
        private BankProjectDBEntities1 db = new BankProjectDBEntities1();

        // GET: BankEmployees
        [Authorize(Roles ="Admin,Employee,Customer")]
        public ActionResult Index()
        {
            var bankEmployees = db.BankEmployees.Include(b => b.Branch);
            return View(bankEmployees.ToList());
        }

        // GET: BankEmployees/Details/5
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankEmployee bankEmployee = db.BankEmployees.Find(id);
            if (bankEmployee == null)
            {
                return HttpNotFound();
            }
            return View(bankEmployee);
        }

        // GET: BankEmployees/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.BranchOffice = new SelectList(db.Branches, "IFSC", "BranchName");
            return View();
        }

        // POST: BankEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,EmpName,GENDER,BranchOffice")] BankEmployee bankEmployee)
        {
            if (ModelState.IsValid)
            {
                bool checkExist = db.BankEmployees.Find(bankEmployee.EmpId).EmpName == bankEmployee.EmpName;
                if (checkExist)
                {
                    ModelState.AddModelError("Name", "Employee Name already exist");
                    return View(bankEmployee);
                }
                db.BankEmployees.Add(bankEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchOffice = new SelectList(db.Branches, "IFSC", "BranchName", bankEmployee.BranchOffice);
            return View(bankEmployee);
        }

        // GET: BankEmployees/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankEmployee bankEmployee = db.BankEmployees.Find(id);
            if (bankEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchOffice = new SelectList(db.Branches, "IFSC", "BranchName", bankEmployee.BranchOffice);
            return View(bankEmployee);
        }

        // POST: BankEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,EmpName,GENDER,BranchOffice")] BankEmployee bankEmployee)
        {
            if (ModelState.IsValid)
            {
                bool checkExist = db.BankEmployees.Find(bankEmployee.EmpId).EmpName == bankEmployee.EmpName;
                if (checkExist) {
                    ModelState.AddModelError("Name", "Employee Name already exist");
                    return View(bankEmployee);
                }
                db.BankEmployees.Attach(bankEmployee);
                db.Entry(bankEmployee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchOffice = new SelectList(db.Branches, "IFSC", "BranchName", bankEmployee.BranchOffice);
            return View(bankEmployee);
        }

        // GET: BankEmployees/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankEmployee bankEmployee = db.BankEmployees.Find(id);
            if (bankEmployee == null)
            {
                return HttpNotFound();
            }
            return View(bankEmployee);
        }

        // POST: BankEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankEmployee bankEmployee = db.BankEmployees.Find(id);
            db.BankEmployees.Remove(bankEmployee);
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
