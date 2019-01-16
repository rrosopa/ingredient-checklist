using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
	public static class BaseEntityMapper
	{
		public static void MapBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id).HasColumnName("id").IsRequired();
			builder.Property(x => x.UserId).HasColumnName("user_id");
		}
	}
}
