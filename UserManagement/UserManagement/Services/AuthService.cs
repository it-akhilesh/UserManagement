using UserManagement.Data;
using UserManagement.Models.Dto;
using UserManagement.Models.Requests;
using UserManagement.Models.Responses;

namespace UserManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository; //field

        public AuthService(IUserRepository userRepository) //costurctor injection
        {
            _userRepository = userRepository;
        }

        public AuthResponse SignIn(LoginRequest request)
        {
            if (request == null)
            {
                return new AuthResponse
                {
                    IsSuccess = false,
                    Message = "Please fillup the username & password."
                };
            }

            UserLoginInfo userLoginInfo = _userRepository.ValidateCredentials(request.UserName, request.Password);

            if (!userLoginInfo.IsValidUser)
            {
                return new AuthResponse
                {
                    IsSuccess = false,
                    Message = "Invalid username or password."
                };
            }

            return new AuthResponse
            {
                IsSuccess = true,
                Message = "Login successful.",
                Username = userLoginInfo.UserName,
                RoleName = userLoginInfo.RoleName

            };

        }
    }
}
