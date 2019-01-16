using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
	public class UserMapping : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("user");
			builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(150);
			builder.Property(x => x.Username).HasColumnName("username").IsRequired().HasMaxLength(50);
			builder.Property(x => x.Password).HasColumnName("password").IsRequired().HasMaxLength(50);
		}
	}
}
