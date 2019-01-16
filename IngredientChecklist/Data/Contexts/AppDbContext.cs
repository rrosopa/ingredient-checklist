using Data.Entities;
using Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
	public class AppDbContext : DbContext, IAppDbContext
	{
		public AppDbContext() { }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Recipe> Recipes{ get; set; }
		public virtual DbSet<Ingredient> Ingredients { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserMapping());
			modelBuilder.ApplyConfiguration(new RecipeMapping());
			modelBuilder.ApplyConfiguration(new IngredientMapping());
		}
	}
}
