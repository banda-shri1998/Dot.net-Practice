using System.Linq;
using System.Web.Mvc;
using EF_DB_Approach_Demo1.Models;

namespace EF_DB_Approach_Demo1.Controllers
{
    public class DepartmentController : Controller
    {
        DotnetF1Entities1 demo = new DotnetF1Entities1();
        // GET: Department        
        
        public ActionResult Index()
        {
            return View(demo.Departments.ToList());
        }
        public ActionResult Create() {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Department d = demo.Departments.Find(id);
            return View(d);
        }
        public ActionResult Details(int id)
        {
            Department d = demo.Departments.Find(id);
            return View(d);
        }
        public ActionResult Delete(int id)
        {
            Department d = demo.Departments.Find(id);
            return View(d);
        }
        [HttpPost]
        public ActionResult Create(Department depart) {
            demo.Departments.Add(depart);
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Department depart)
        {
            demo.Departments.Attach(depart);
            demo.Entry(depart).State=System.Data.Entity.EntityState.Modified;
            demo.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id,Department depart) {
            Department d = demo.Departments.Find(id);
            demo.Departments.Remove(d);
            demo.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}