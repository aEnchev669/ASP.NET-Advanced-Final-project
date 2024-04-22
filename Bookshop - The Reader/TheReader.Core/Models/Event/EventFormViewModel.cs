using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants.EventConstants;
using static TheReader.Infrastructure.Constants.ErrorMessages.EventErrorMessages;

namespace TheReader.Core.Models.Event
{
	public class EventFormViewModel
	{
		[StringLength(EventTopicMaxLength, MinimumLength = EventTopicMinLength, ErrorMessage = InvalidTopic)]

		public string Topic { get; set; } = null!;

		[Required]
		[StringLength(EventLocationMaxLength, MinimumLength = EventLocationMinLength, ErrorMessage = InvalidLocation)]
		public string Location { get; set; } = null!; 
		
		[Required]
		[StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = InvalidDescription)]
		public string Description { get; set; } = null!;

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
