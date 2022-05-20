using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_DB_Approach_Demo1.Models;

namespace EF_DB_Approach_Demo1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DotnetF1Entities1 demo = new DotnetF1Entities1();
        public ActionResult Index()
        {
            return View(demo.EmployeeJKs.ToList());
        }
        public ActionResult Details(int id)
        {
            EmployeeJK dept1 = demo.EmployeeJKs.Find(id);
            return View(dept1);
        }
        public ActionResult Delete(int id)
        {
            EmployeeJK e = demo.EmployeeJKs.Find(id);
            return View(e);
        }
        [HttpPost]
        public ActionResult Delete(int id,EmployeeJK e)
        {
            EmployeeJK ed = demo.EmployeeJKs.Find(id);
            demo.EmployeeJKs.Remove(ed);
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            EmployeeJK e = demo.EmployeeJKs.Find(id);
            List<SelectListItem> items = new List<SelectListItem>();
            var depts = demo.Departments.ToList();
            foreach (var dept in depts)
            {
                items.Add(new SelectListItem
                {
                    Text = dept.Name,
                    Value = dept.DepartmentId.ToString()
                });
            }
            ViewBag.Departments = items;
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeJK jK) {
            demo.EmployeeJKs.Attach(jK);
            demo.Entry(jK).State = System.Data.Entity.EntityState.Modified;
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create() {
            List<SelectListItem> items = new List<SelectListItem>();
            var depts = demo.Departments.ToList();
            foreach (var dept in depts) {
                items.Add(new SelectListItem
                {
                    Text = dept.Name,
                    Value = dept.DepartmentId.ToString()
                });
            }
            ViewBag.Departments = items;
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeJK k) {
            demo.EmployeeJKs.Add(k);
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}