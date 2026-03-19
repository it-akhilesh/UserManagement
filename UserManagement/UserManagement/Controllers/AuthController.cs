using System.Web.Http;
using UserManagement.Data;
using UserManagement.Models.Requests;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController() : this(new AuthService(new SqlUserRepository()))
        {

        }

        internal AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("signin")]
        public IHttpActionResult SignIn(LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body is required.");
            }

            var result = _authService.SignIn(request);
            if (!result.IsSuccess)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
