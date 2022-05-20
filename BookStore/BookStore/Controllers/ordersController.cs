using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class ordersController : Controller
    {
        private BookStoreEntities db = new BookStoreEntities();

        // GET: orders
        public ActionResult Index()
        {
            var orders = db.orders.Include(o => o.Customer).Include(o => o.Book1);
            return View(orders.ToList());
        }

        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: orders/Create
        public ActionResult Create()
        {
            ViewBag.CustID = new SelectList(db.Customers, "CustId", "CustName");
            ViewBag.bookId = new SelectList(db.Books, "BookId", "BookName");
            return View();
        }

        // POST: orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustID,Quantity,bookId")] order order)
        {
            if (ModelState.IsValid)
            {
                Book b = db.Books.Find(order.bookId);
                if (!(order.Quantity > 0)&&(order.Quantity<b.StockAvail)) {
                    ModelState.AddModelError("Quantity", "Quantity should be more than 1 or not avail for that quantity");
                    return RedirectToAction("Create");
                }
                order.BillAmount = genrateBill(order);
                b.StockAvail = b.StockAvail - order.Quantity;
                db.Books.Attach(b);
                order.OrderTime = System.DateTime.Now;
                db.Entry(b).State = EntityState.Modified;
            }
            ViewBag.CustID = new SelectList(db.Customers, "CustId", "CustName", order.CustID);
            ViewBag.bookId = new SelectList(db.Books, "BookId", "BookName", order.bookId);
            db.orders.Add(order);
            db.SaveChanges();
            //return View(order);
            return RedirectToAction("Index");
        }

        // GET: orders/Edit/5
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        internal decimal genrateBill(order order)
        {
            Book b = db.Books.Find(order.bookId);
            order.BillAmount = order.Quantity * b.Price;
            return order.BillAmount;
            /*ViewBag.result = order.BillAmount;
            return View();*/
        }
    }
}
