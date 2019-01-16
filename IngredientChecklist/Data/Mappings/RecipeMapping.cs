using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
	public class RecipeMapping : IEntityTypeConfiguration<Recipe>
	{
		public void Configure(EntityTypeBuilder<Recipe> builder)
		{
			builder.ToTable("recipe");
			builder.MapBaseEntity();

			builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);

			builder.HasMany(x => x.Ingredients).WithOne().HasForeignKey(x => x.Id);
		}
	}
}
