using UserManagement.Models.Dto;

namespace UserManagement.Data
{
    public interface IUserRepository
    {
        UserLoginInfo ValidateCredentials(string userName, string password);
    }
}
