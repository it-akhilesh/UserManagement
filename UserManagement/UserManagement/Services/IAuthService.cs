using UserManagement.Models.Requests;
using UserManagement.Models.Responses;

namespace UserManagement.Services
{
    public interface IAuthService
    {
        AuthResponse SignIn(LoginRequest request);
    }
}
