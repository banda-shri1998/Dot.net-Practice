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
    public class LoansController : Controller
    {
        private BankProjectDBEntities1 db = new BankProjectDBEntities1();
        [Authorize(Roles = "Employee,Customer,Admin")]
        // GET: Loans
        public ActionResult Index()
        {
            var loans = db.Loans.Include(l => l.Customer);
            return View(loans.ToList());
        }

        // GET: Loans/Details/5
        [Authorize(Roles = "Employee,Customer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: Loans/Create
        [Authorize(Roles = "Employee")]
        public ActionResult Create()
        {
            ViewBag.AccountNo = new SelectList(db.Customers, "AccNo", "CustName");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanID,LoanType,LoanAmt,AccountNo")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                bool checkExist = db.Loans.Any(u => u.AccountNo == loan.AccountNo);
                if (checkExist)
                {
                    ModelState.AddModelError("LoanID", "Customer need to pay out the loan");
                    return View(loan);
                }
                if (!(loan.LoanAmt > 0)) {
                    ModelState.AddModelError("LoanAmt","Amount Should be greater than 0");
                    return View(loan.LoanAmt);
                }
                //loan.totalAmount = (int)(loan.LoanAmt + (loan.LoanAmt * loan.duration * loan.interest) / 100);
                db.Loans.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountNo = new SelectList(db.Customers, "AccNo", "CustName", loan.AccountNo);
            return View(loan);
        }

        // GET: Loans/Edit/5
        [Authorize(Roles = "Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountNo = new SelectList(db.Customers, "AccNo", "CustName", loan.AccountNo);
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanID,LoanType,LoanAmt,AccountNo")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                bool checkExist = db.Loans.Find(loan.AccountNo).LoanID == loan.LoanID;
                if (checkExist)
                {
                    ModelState.AddModelError("Loan ID", "Customer need to pay out previous loan");
                    return View(loan);
                }
                db.Loans.Attach(loan);
                db.Entry(loan).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountNo = new SelectList(db.Customers, "AccNo", "CustName", loan.AccountNo);
            return View(loan);
        }

        // GET: Loans/Delete/5
        [Authorize(Roles = "Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan loan = db.Loans.Find(id);
            db.Loans.Remove(loan);
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
