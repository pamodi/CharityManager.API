using CharityManager.API.Model;
using CharityManager.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CharityManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AuthService authService) : ControllerBase
    {
        private readonly AuthService _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _authService.ValidateUser(loginRequest.Username, loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(new LoginResponse() { IsSuccess = false, Role = "", Message = "Invalid credentials." });
            }

            return Ok(new LoginResponse() { IsSuccess = true, Role = user.Role, Message = "Login successful." });
        }
    }
}
