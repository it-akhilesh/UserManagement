using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.Data;
using UserManagement.Models.Requests;
using UserManagement.Models.Responses;
using UserManagement.Models.stu;

namespace UserManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository) //costurctor injection
        {
            _studentRepository = studentRepository;
        }

        public bool Save(StudentRequest student)
        {
            if (student == null)
            {
                return false;
            }

            return _studentRepository.StudentInsert(student);
        }

        public List<Student> GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();
            
            return students;
        }
    }
}