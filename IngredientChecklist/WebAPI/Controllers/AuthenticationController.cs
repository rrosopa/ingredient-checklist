using Core.Models;
using Microsoft.AspNetCore.Authorization;
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

		[AllowAnonymous]
		[HttpPost("")]
		public IActionResult Login([FromBody]LoginCredentials credentials)
		{
			var token = _authenticationService.Authenticate(credentials.Username);
			if (token == null)
				return Unauthorized();

			return Ok(token);
		}
    }
}