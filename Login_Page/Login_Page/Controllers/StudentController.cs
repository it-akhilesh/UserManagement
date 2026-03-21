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
            BindDropdownList(stu);
            return View(stu);


        }
        [HttpPost]
        public ActionResult Index(StudentViewModel stu)
        {
            if (ModelState.IsValid)
            {
                if (stu.Photo != null && stu.Photo.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(stu.Photo.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    stu.Photo.SaveAs(path);
                }
                //Call business logic to save student data to the database here
                return RedirectToAction("Index");
            }

            BindDropdownList(stu);

            return View(stu);
            // Here you can save the student data to the database or perform other actions


        }

        private static void BindDropdownList(StudentViewModel stu)
        {
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
        }
    }
}