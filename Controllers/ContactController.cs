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

        [HttpGet(Name = "GetContacts")]
        [ProducesResponseType(typeof(IEnumerable<UserModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersByRoleAsync("USER");

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        [HttpGet("{userId}", Name = "GetContactDetails")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUserDetails([FromRoute] int userId)
        {
            return Ok(_userService.GetUserDetails(userId));
        }

        [HttpPost(Name = "CreateContact")]
        [ProducesResponseType(typeof(UserCreateRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser([FromBody] UserCreateRequest userCreateRequest)
        {
            return Ok(_userService.CreateUser(userCreateRequest));
        }

        [HttpPut("{userId}", Name = "UpdateContact")]
        [ProducesResponseType(typeof(UserUpdateRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser([FromRoute] int userId, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            _userService.UpdateUser(userId, userUpdateRequest);
            return Ok();
        }

        [HttpDelete("{userId}", Name = "DeleteContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUser([FromRoute] int userId)
        {
            _userService.DeleteUser(userId);
            return Ok();
        }
    }
}
