using Data.Entities;

namespace Services.Users
{
	public interface IUserService
    {
		User Get(int id);
    }
}
