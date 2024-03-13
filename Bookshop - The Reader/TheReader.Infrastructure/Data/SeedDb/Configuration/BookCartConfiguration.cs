using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheReader.Infrastructure.Data.Models;

namespace TheReader.Infrastructure.Data.SeedDb.Configuration
{
	internal class BookCartConfiguration : IEntityTypeConfiguration<BookCart>
	{
		public void Configure(EntityTypeBuilder<BookCart> builder)
		{
			builder
				.HasKey(bc => new { bc.BookId, bc.CartId });
		}
	}
}
