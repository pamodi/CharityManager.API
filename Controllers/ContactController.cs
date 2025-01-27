using CharityManager.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CharityManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IUserService _userService;

        public ContactController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var users = await _userService.GetUsersByRoleAsync("User");

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }
    }
}
