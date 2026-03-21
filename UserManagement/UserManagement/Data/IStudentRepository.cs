using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.Models.stu;

namespace UserManagement.Data
{
    public interface IStudentRepository
    {
        bool StudentInsert(StudentRequest student);
    }
}