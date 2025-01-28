using CharityManager.API.Model;
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

        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(typeof(IEnumerable<UserModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContacts()
        {
            var users = await _userService.GetUsersByRoleAsync("User");

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(typeof(UserCreateRequest), StatusCodes.Status200OK)]
        public IActionResult CreateUser([FromBody] UserCreateRequest userCreateRequest)
        {
            return Ok(_userService.CreateUser(userCreateRequest));
        }

        [HttpPut("{userId}", Name = "UpdateUser")]
        [ProducesResponseType(typeof(UserUpdateRequest), StatusCodes.Status200OK)]
        public IActionResult UpdateUser([FromRoute] int userId, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            _userService.UpdateUser(userId, userUpdateRequest);
            return Ok();
        }
    }
}
