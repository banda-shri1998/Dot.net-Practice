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
    public class CustomersController : Controller
    {
        private BankProjectDBEntities1 db = new BankProjectDBEntities1();

        // GET: Customers
        [Authorize(Roles = "Employee,Customer,Admin")]
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Branch);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        [Authorize(Roles = "Employee,Customer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        [Authorize(Roles = "Employee")]
        public ActionResult Create()
        {
            ViewBag.BranchIFSC = new SelectList(db.Branches, "IFSC", "BranchName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccNo,CustName,CustAddress,DOB,PhoneNo,GENDER,AccountType,Balance,BranchIFSC")] Customer customer)
        {
            using (BankProjectDBEntities1 db = new BankProjectDBEntities1())
            {

                if (ModelState.IsValid)
                {
                    var checkExist = db.Customers.Any(u => u.PhoneNo == customer.PhoneNo);
                    if (checkExist)
                    {
                        ModelState.AddModelError("Phone No", "Phone No already exist");
                        return View(customer);
                    }
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.BranchIFSC = new SelectList(db.Branches, "IFSC", "BranchName", customer.BranchIFSC);
                return View(customer);
            }
        }

        // GET: Customers/Edit/5
        [Authorize(Roles = "Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchIFSC = new SelectList(db.Branches, "IFSC", "BranchName", customer.BranchIFSC);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccNo,CustName,CustAddress,DOB,PhoneNo,GENDER,AccountType,Balance,BranchIFSC")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                /*bool checkExist = db.Customers.Find(customer.PhoneNo).PhoneNo == customer.PhoneNo;
                if (checkExist)
                {
                    ModelState.AddModelError("Phone No", "Phone No already exist");
                    return View(customer);
                }*/
                db.Customers.Attach(customer);
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchIFSC = new SelectList(db.Branches, "IFSC", "BranchName", customer.BranchIFSC);
            return View(customer);
        }

        // GET: Customers/Delete/5
        [Authorize(Roles = "Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
