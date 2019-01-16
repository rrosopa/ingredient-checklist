using Microsoft.AspNetCore.Mvc;
using Services.Users;

namespace WebAPI.Controllers
{
	[Route("api/[users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
		private readonly IUserService _userService;
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet("{id}")]
		public IActionResult GetUser(int id)
		{
			var user = _userService.Get(id);
			if (user == null)
				return NotFound("User does not exist");

			return Ok(user.Name);
		}
    }
}