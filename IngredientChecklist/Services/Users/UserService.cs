using Data.Contexts;
using Services.Auth;
using System.Linq;

namespace Services.Users
{
	public class UserService : IUserService
	{
		private readonly IClaimsService _claimsService;
		private readonly IAppDbContext _appDbContext;

		public UserService(
			IClaimsService claimsService,
			IAppDbContext appDbContext)
		{
			_claimsService = claimsService;
			_appDbContext = appDbContext;
		}
	}
}
