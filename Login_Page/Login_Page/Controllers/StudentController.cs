using Login_Page.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Login_Page.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentViewModel stu = new StudentViewModel();

            ViewBag.Username = Session["username"];
            ViewData["Role"] = Session["role"];

            stu.CountryList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "India", Text = "India" },
                    new SelectListItem { Value = "USA", Text = "United States" },
                };
            stu.StateList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Uttar Pradesh", Text = "Uttar Pradesh" },
                    new SelectListItem { Value = "Uttrakhand", Text = "Uttrakhand" },
                };
            stu.CityList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "lko", Text = "Lucknow" },
                    new SelectListItem { Value = "Mana", Text = "Manali" },
                };

            return View(stu);


        }
    }
}