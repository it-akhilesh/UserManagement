using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Requests
{
    public class LoginRequest
    {
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
