using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
	public interface IAppDbContext
    {		
		DbSet<User> Users { get; set; }
		DbSet<Recipe> Recipes { get; set; }
		DbSet<Ingredient> Ingredients { get; set; }

		int SaveChanges();
	}
}
