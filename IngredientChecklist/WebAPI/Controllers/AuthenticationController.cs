using Microsoft.AspNetCore.Mvc;
using Services.Auth;

namespace WebAPI.Controllers
{
	[Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
		private readonly IAuthenticationService _authenticationService;
		public AuthenticationController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		[HttpPost("")]
		public IActionResult Login([FromBody]string username, [FromBody]string password)
		{
			var token = _authenticationService.Authenticate(username, password);
			if (token == null)
				return Unauthorized();

			return Ok(token);
		}
    }
}