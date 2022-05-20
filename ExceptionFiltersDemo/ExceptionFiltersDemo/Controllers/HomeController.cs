using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionFiltersDemo.Controllers
{
    [HandleError(ExceptionType = typeof(NullReferenceException), View = "NullableReferance")]
    [HandleError(ExceptionType = typeof(DivideByZeroException), View = "divideByZero")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //throw new Exception("Something went wrong");
            return View();
        }
        public ActionResult Test1()
        {
            throw new NullReferenceException();
        }

        public ActionResult Test2()
        {
            throw new DivideByZeroException();
        }

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