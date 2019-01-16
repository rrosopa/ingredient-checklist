using Core.Extensions;
using System.Security.Claims;

namespace Services.Auth
{
	public class ClaimsService : IClaimsService
    {
		private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _currentUser;

		public ClaimsService(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_currentUser = _httpContextAccessor.HttpContext.User;
		}

		public int UserId => _currentUser.FindFirst(ClaimTypes.Actor).Value.ToInteger().Value;
	}
}
