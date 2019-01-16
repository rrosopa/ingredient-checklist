using Core.Models;

namespace Services.Auth
{
	public interface IAuthenticationService
    {
		TokenDetails Authenticate(string username, string password);
    }
}
