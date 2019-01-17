using Core.Models;
using Data.Contexts;
using Services.Auth;
using System.Collections.Generic;
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

		public List<IdLabelPair> GetUserDictionary() => 
			_appDbContext.Users.Select(x => new IdLabelPair
			{
				Id = x.Username,
				Label = x.Name
			}).ToList();
	}
}
