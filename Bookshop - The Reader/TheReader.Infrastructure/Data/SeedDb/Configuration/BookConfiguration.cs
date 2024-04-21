using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheReader.Infrastructure.Data.Models.Books;

namespace TheReader.Infrastructure.Data.SeedDb.Configuration
{
	internal class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{

			builder
				.Property(b => b.Price)
				.HasPrecision(18, 2);

			builder
				.Property(b => b.Weight)
				.HasPrecision(18, 2);

			var data = new SeedData();

			builder.HasData(new Book[] {data.RichDadPoorDad, data.ElonMusk, data.TheStoryOfTheKamasutra, data.Trillions });
		}
	}
}
