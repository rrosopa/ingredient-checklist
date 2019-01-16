using Data.Entities;

namespace Services.Auth
{
	public interface IAuthenticationService
    {
		string Authenticate(string username, string password);
    }
}
