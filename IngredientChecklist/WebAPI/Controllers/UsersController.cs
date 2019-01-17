using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Users;

namespace WebAPI.Controllers
{
	[Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
		private readonly IUserService _userService;
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[AllowAnonymous]
		[HttpGet("")]
		public IActionResult GetAllUsers()
		{
			return Ok(_userService.GetUserDictionary());
		}
    }
}