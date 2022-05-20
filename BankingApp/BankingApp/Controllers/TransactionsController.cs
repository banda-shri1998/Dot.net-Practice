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
    public class TransactionsController : Controller
    {
        private BankProjectDBEntities1 db = new BankProjectDBEntities1();
        [Authorize(Roles = "Employee,Customer,Admin")]
        // GET: Transactions
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.Customer).Include(t => t.Customer1);
            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        [Authorize(Roles = "Employee,Customer")]
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        [Authorize(Roles = "Employee")]
        public ActionResult Create()
        {
            ViewBag.transFrom_accno = new SelectList(db.Customers, "AccNo", "CustName");
            ViewBag.transTo_accNo = new SelectList(db.Customers, "AccNo", "CustName");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "transID,transTime,TransType,transFrom_accno,transTo_accNo,transAmount,trans_remark")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                if (!(transaction.transAmount > 0)&&(transaction.transAmount<db.Customers.Find(transaction.transFrom_accno).Balance))
                {
                    ModelState.AddModelError("transAmount", "Amount Should be greater than 0");
                    return View(transaction.transAmount);
                }
                transaction.TransTime = System.DateTime.Now;
                Customer transFrom = db.Customers.Find(transaction.transFrom_accno);
                Customer transTo = db.Customers.Find(transaction.transTo_accNo);
                transFrom.Balance = transFrom.Balance - transaction.transAmount;
                transTo.Balance = transTo.Balance + transaction.transAmount;
                db.Customers.Attach(transTo);
                db.Customers.Attach(transFrom);
                db.Transactions.Add(transaction);
                db.Entry(transFrom).State = System.Data.Entity.EntityState.Modified;
                db.Entry(transTo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.transFrom_accno = new SelectList(db.Customers, "AccNo", "CustName", transaction.transFrom_accno);
            ViewBag.transTo_accNo = new SelectList(db.Customers, "AccNo", "CustName", transaction.transTo_accNo);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        [Authorize(Roles = "Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.transFrom_accno = new SelectList(db.Customers, "AccNo", "CustName", transaction.transFrom_accno);
            ViewBag.transTo_accNo = new SelectList(db.Customers, "AccNo", "CustName", transaction.transTo_accNo);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transID,TransTime,TransType,transFrom_accno,transTo_accNo,transAmount,trans_remark")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.transFrom_accno = new SelectList(db.Customers, "AccNo", "CustName", transaction.transFrom_accno);
            ViewBag.transTo_accNo = new SelectList(db.Customers, "AccNo", "CustName", transaction.transTo_accNo);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        [Authorize(Roles = "Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
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
