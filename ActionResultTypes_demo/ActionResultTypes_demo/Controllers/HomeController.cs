using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionResultTypes_demo.Controllers
{
    public class HomeController : Controller
    {
        //Method 1
        public ActionResult ChooseView()
        {
            if (DateTime.Now.Day % 2 == 0)
            {
                return View("View1");
            }
            else
            {
                return View("View2");
            }
        }
        //Method 2
        public ViewResult Method() {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        //Method 3
        //public PartialViewResult Index1() {
        //    return PartialView("_SamplePartialView");
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}