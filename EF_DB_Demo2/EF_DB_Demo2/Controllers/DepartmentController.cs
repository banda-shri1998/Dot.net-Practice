using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_DB_Demo2.Models;

namespace EF_DB_Demo2.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DotnetF1Entities demo = new DotnetF1Entities();
        public ActionResult Index()
        {
            return View(demo.Departments.ToList());
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department d) {
            demo.Departments.Add(d);
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id) {
            Department d = demo.Departments.Find(id);
            return View(d);
        }
        [HttpPost]
        public ActionResult Edit(Department d) {
            demo.Departments.Attach(d);
            demo.Entry(d).State = System.Data.Entity.EntityState.Modified;
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id) {
            Department d=demo.Departments.Find(id);
            return View(d);
        }
        [HttpPost]
        public ActionResult Delete(Department d) {
            demo.Departments.Remove(d);
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id) {
            Department d = demo.Departments.Find(id);
            return View(d);
        }
    }
}