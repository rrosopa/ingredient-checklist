using Core.Models;
using Data.Contexts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services.Auth
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly AppConfig _appConfig;
		private readonly IAppDbContext _appDbContext;

		public AuthenticationService(IAppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		// NOTE: simple authentication for demo purposes only, password is not hash and signed
		public string Authenticate(string username, string password)
		{
			var user =  _appDbContext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
			if (user == null)
				return null;

			var claims = new[]
			{
				new Claim(ClaimTypes.Actor, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.Name)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.JWTKey));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				_appConfig.JWTIssuer,
				_appConfig.JWTIssuer,
				claims,
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
