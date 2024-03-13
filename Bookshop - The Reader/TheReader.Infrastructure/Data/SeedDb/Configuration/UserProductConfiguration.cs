using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheReader.Infrastructure.Data.Models;

namespace TheReader.Infrastructure.Data.SeedDb.Configuration
{
	internal class UserProductConfiguration : IEntityTypeConfiguration<UserProduct>
	{
		public void Configure(EntityTypeBuilder<UserProduct> builder)
		{
			builder
				.HasKey(up => new { up.ApplicationUserId, up.BookId });
		}
	}
}
