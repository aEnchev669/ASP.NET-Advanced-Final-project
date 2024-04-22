using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheReader.Infrastructure.Data.Models;

namespace TheReader.Infrastructure.Data.SeedDb.Configuration
{
	internal class EventCartConfiguration : IEntityTypeConfiguration<EventCart>
	{
		public void Configure(EntityTypeBuilder<EventCart> builder)
		{
			builder
				.HasKey(bc => new { bc.EventId, bc.CartId });
		}
	}
}
