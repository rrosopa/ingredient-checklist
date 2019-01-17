using Core.Models;
using Data.Contexts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services.Auth
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IOptions<AppConfig> _appConfig;
		private readonly IAppDbContext _appDbContext;

		public AuthenticationService(
			IOptions<AppConfig> appConfig,
			IAppDbContext appDbContext)
		{
			_appConfig = appConfig;
			_appDbContext = appDbContext;
		}

		public TokenDetails Authenticate(string username)
		{
			var user =  _appDbContext.Users.SingleOrDefault(x => x.Username == username);
			if (user == null)
				return null;

			var claims = new[]
			{
				new Claim(ClaimTypes.Actor, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.Name)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.Value.JWTKey));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				_appConfig.Value.JWTIssuer,
				_appConfig.Value.JWTIssuer,
				claims,
				signingCredentials: credentials,
				expires: DateTime.Now.AddHours(12)
			);

			return new TokenDetails
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				Name = user.Name
			};
		}
	}
}
