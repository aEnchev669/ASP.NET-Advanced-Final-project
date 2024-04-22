using System.ComponentModel.DataAnnotations;
using TheReader.Core.Contracts.Event;
using static TheReader.Infrastructure.Constants.DataConstants.EventConstants;
using static TheReader.Infrastructure.Constants.ErrorMessages.EventErrorMessages;

namespace TheReader.Core.Models.Event
{
	public class EventModel : IEventModel
	{
		public int Id { get; set; }

		[StringLength(EventTopicMaxLength, MinimumLength = EventTopicMinLength, ErrorMessage = InvalidTopic)]

		public string Topic { get; set; } = null!;

		[Required]
		[StringLength(EventLocationMaxLength, MinimumLength = EventLocationMinLength, ErrorMessage = InvalidLocation)]
		public string Location { get; set; } = null!;

		[Required]
		public DateTime Date { get; set; }

		[Required]
		[Range(EventSeatsMinRange, EventSeatsMaxRange)]
		public int Seats { get; set; }

		[Required]
		[Range(EventTicketPriceMinRange, EventTicketPriceMaxRange)]
		public decimal TicketPrice { get; set; }

	}
}
