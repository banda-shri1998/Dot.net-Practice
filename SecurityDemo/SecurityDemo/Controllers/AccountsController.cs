using SecurityDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SecurityDemo.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (MVC_DBEntities entities = new MVC_DBEntities())
            {
                bool IsValidUser = entities.Users.Any(u => u.UserName.ToLower() == model.UserName.ToLower() && u.UserPassword == model.UserPassword);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User Model)
        {
            using (MVC_DBEntities entities = new MVC_DBEntities())
            {
                entities.Users.Add(Model);
                entities.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Accounts");
        }
    }
}