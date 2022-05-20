using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_DB_Demo2.Models;
namespace EF_DB_Demo2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DotnetF1Entities demo = new DotnetF1Entities();
        public ActionResult Index()
        {
            return View(demo.EmployeeJKs.ToList());
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeJK e) {
            demo.EmployeeJKs.Add(e);
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id) {
            EmployeeJK e = demo.EmployeeJKs.Find(id);
            return View(e);
        }
        [HttpPost]
        public ActionResult Delete(EmployeeJK e) {
            demo.EmployeeJKs.Remove(e);
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id) {
            EmployeeJK e = demo.EmployeeJKs.Find(id);
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeJK e) {
            demo.EmployeeJKs.Attach(e);
            demo.Entry(e).State = System.Data.Entity.EntityState.Modified;
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id) {
            EmployeeJK e=demo.EmployeeJKs.Find(id);
            return View(e);
        }
    }
}