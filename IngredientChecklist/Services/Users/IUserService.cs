using Core.Models;
using System.Collections.Generic;

namespace Services.Users
{
	public interface IUserService
    {
		List<IdLabelPair> GetUserDictionary();
	}
}
