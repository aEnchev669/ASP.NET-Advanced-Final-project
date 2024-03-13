using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheReader.Infrastructure.Data.Models.Books;

namespace TheReader.Infrastructure.Data.SeedDb.Configuration
{
	internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> builder)
		{
			var data = new SeedData();

			builder.HasData(new Genre[] { data.Fantasy, data.ScienceFiction, data.Classic, data.Mystery, data.Horror, data.Finance, data.Biography, data.FoodAndDrink, data.History, data.Travel, data.Crime });
		}
	}
}

