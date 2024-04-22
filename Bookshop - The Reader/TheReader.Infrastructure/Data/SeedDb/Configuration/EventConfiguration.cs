using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheReader.Infrastructure.Data.Models.Events;

namespace TheReader.Infrastructure.Data.SeedDb.Configuration
{
	internal class EventConfiguration : IEntityTypeConfiguration<Event>
	{
		public void Configure(EntityTypeBuilder<Event> builder)
		{
			builder
				.Property(e => e.TicketPrice)
				.HasPrecision(18, 2);

			var data = new SeedData();

			builder.HasData(new Event[]
			{
				data.EventOne,
				data.EventTwo,
				data.EventThree,
			});
		}
	}
}
