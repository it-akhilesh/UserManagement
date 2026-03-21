using UserManagement.Models.Requests;
using UserManagement.Models.Responses;
using UserManagement.Models.stu;

namespace UserManagement.Services
{
    public interface IStudentService
    {
        bool Save(StudentRequest student);
    }
}
