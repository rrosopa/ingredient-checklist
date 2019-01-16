using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
	public class IngredientMapping : IEntityTypeConfiguration<Ingredient>
	{
		public void Configure(EntityTypeBuilder<Ingredient> builder)
		{
			builder.ToTable("ingredient");
			builder.MapBaseEntity();

			builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
			builder.Property(x => x.RecipeId).HasColumnName("recipe_id").IsRequired();
			builder.Property(x => x.IsChecked).HasColumnName("is_checked").IsRequired();
		}
	}
}
