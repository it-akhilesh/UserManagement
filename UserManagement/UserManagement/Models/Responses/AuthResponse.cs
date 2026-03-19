namespace UserManagement.Models.Responses
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public string Message { get; set; }
    }
}
