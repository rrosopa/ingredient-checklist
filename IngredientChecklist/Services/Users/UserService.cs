using Data.Contexts;
using Data.Entities;
using System.Linq;

namespace Services.Users
{
	public class UserService : IUserService
	{
		private readonly IAppDbContext _appDbContext;

		public UserService(IAppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public User Get(int id)
		{
			return _appDbContext.Users.SingleOrDefault(x => x.UserId == id);
		}
	}
}
