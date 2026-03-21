using BusinessLogiclayer;
using BusinessLogiclayer.Requests;
using Login_Page.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index(StudentViewModel stu)
        {
            if (ModelState.IsValid)
            {
                byte[] fileData = null;
                string fileName = null;
                string fileType = null;

                if (stu.Photo != null && stu.Photo.ContentLength > 0)
                {
                    fileName = Path.GetFileName(stu.Photo.FileName);
                    fileType = stu.Photo.ContentType;

                    using (var binaryReader = new BinaryReader(stu.Photo.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(stu.Photo.ContentLength);
                    }
                }

                StudentService studentService = new StudentService();
                Student student = new Student();
                student.Name = stu.Name;
                student.Address = stu.Address;
                student.Country = stu.Country;
                student.State = stu.State;
                student.City = stu.City;
                student.PinCode = stu.PinCode;
                student.MobileNo = stu.MobileNo;
                student.Email = stu.Email;
                student.fileData = fileData;
                student.fileName = fileName;
                student.fileType = fileType;
                
                var result = await studentService.Register(student);
                if(result)
                {
                    TempData["Message"] = "Student registered successfully!";
                }
                else
                {
                    TempData["Message"] = "Failed to register student";
                }

                //Call business logic to save student data into the database here
                return RedirectToAction("Index");
            }

            BindDropdownList(stu);

            return View(stu);
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