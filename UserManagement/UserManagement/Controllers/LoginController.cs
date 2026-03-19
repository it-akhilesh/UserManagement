using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (model.UserName == "admin" && model.Password == "123")
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Invalid Username or Password";
                return View();
            }
        }
    }
}