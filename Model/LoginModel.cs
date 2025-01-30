using System.ComponentModel.DataAnnotations;

namespace CharityManager.API.Model
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string DisplayName { get; set; }
        public string Role { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
