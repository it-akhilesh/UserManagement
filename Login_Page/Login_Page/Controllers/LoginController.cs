
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading.Tasks;
using Login_Page.Models;
using BusinessLogiclayer;



namespace Login_Page.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult NewIndex()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(LoginModel model)
        {
            LoginService obj = new LoginService();

            var result = await obj.GetLogin(model.UserName, model.UserPassword);

            if (result.IsSuccess)
            {
                Session["username"] = result.Username;
                Session["role"] = result.RoleName;
                if (result.RoleName == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (result.RoleName == "Student")
                {
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ViewBag.Message = "Invalid Role";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.Message = "Invalid Username or Password";
                return View("Index");
            }
        }
    }
}