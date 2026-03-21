using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManagement.Data;
using UserManagement.Models.stu;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        
        private readonly IStudentService _studentService;
        public StudentController() : this(new StudentService(new StudentRepository()))
        {

        }

        internal StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateStudent(StudentRequest student)
        {
            if (student == null)
            {
                return BadRequest("Student data is required.");
            }
            var result = _studentService.Save(student);
            return Ok(result);
        }
    }
}