using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants.EventConstants;
namespace TheReader.Infrastructure.Data.Models.Events
{
	public class Event
	{
		[Key]
		[Comment("The current Event's Identifier")]
		public int Id { get; set; }

		[Required]
		[MaxLength(EventTopicMaxLength)]
		[Comment("The current Event's Topic")]
		public string Topic { get; set; } = null!;

		[Required]
		[MaxLength(EventDescriptionMaxLength)]
		[Comment("The current Event's Description")]
		public string Description { get; set; } = null!;

		[Required]
		[MaxLength(EventLocationMaxLength)]
		[Comment("The current Event's Location")]
		public string Location { get; set; } = null!;

		[Required]
		[Comment("The current Event's date")]
		public DateTime Date { get; set; }

		[Required]
		[Comment("The current Event's seats")]
		public int Seats { get; set; }

		[Required]
		[Comment("The current Event's Ticket Price")]
		public decimal TicketPrice { get; set; }

		public bool IsDeleted { get; set; } = false;

        public ICollection<EventParticipant> EventsParticipants { get; set; } = new HashSet<EventParticipant>();
		public ICollection<EventCart> EventsCarts { get; set; } = new HashSet<EventCart>();
	}
}
