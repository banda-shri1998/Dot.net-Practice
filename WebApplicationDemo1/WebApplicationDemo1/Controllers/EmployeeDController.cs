using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo1.Models;
using WebDemo1.ViewModels;

namespace WebDemo1.Controllers
{
    public class EmployeeDController : Controller
    {
        // GET: EmployeeD
        public ActionResult Index()
        {
            List<Employee> empL = new List<Employee>() {
                new Employee(){empID=101,EName="Shri",Gender='M',Salary=25000},
                new Employee(){empID=102,EName="Abhishek",Gender='M',Salary=24000},
                new Employee(){ empID=103,EName="Chinu",Gender='M',Salary=29000},
            };

            List<Address> addL = new List<Address>() {
                new Address(){ empID=101,address="adarsh Nagar",city="solapur",state="MH",pincode=413006},
                new Address(){ empID=102,address="Karnik Nagar",city="Aligadh",state="DL",pincode=600006},
                new Address(){ empID=103,address="Heaven",city="Nostalgia",state="California",pincode=41321},
            };
            ViewEmpDetails ve = new ViewEmpDetails();
            ve.Employee = empL;
            ve.Address = addL;
            return View(ve);
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
    }
}