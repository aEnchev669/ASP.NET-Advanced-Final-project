using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheReader.Infrastructure.Data.Models;

namespace TheReader.Infrastructure.Data.SeedDb.Configuration
{
	internal class EventParticipantConfiguration : IEntityTypeConfiguration<EventParticipant>
	{
		public void Configure(EntityTypeBuilder<EventParticipant> builder)
		{
			builder
				.HasKey(ep => new { ep.EventId, ep.ParticipantId });
		}

	}
}
