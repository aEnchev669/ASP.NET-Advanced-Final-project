using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Events;

namespace TheReader.Infrastructure.Data.Models
{
	public class EventParticipant
	{
		[Required]
		[Comment("The current Event's Identifier")]
		public int EventId { get; set; }

		[ForeignKey(nameof(EventId))]
		[Comment("The current Event")]
		public Event Event { get; set; } = null!;

		[Required]
		[Comment("The current Participant's Identifier")]
		public string ParticipantId { get; set; } = null!;

		[ForeignKey(nameof(ParticipantId))]
		[Comment("The current Participant")]
		public ApplicationUser Participant { get; set; } = null!;
	}
}
