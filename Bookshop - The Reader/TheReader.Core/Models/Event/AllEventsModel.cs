using System.ComponentModel.DataAnnotations;

namespace TheReader.Core.Models.Event
{
	public class AllEventsModel
	{
		public int EventsPerPage { get; } = 8;

		[Display(Name = "Търсене")]
		public string SearchTerm { get; set; } = null!;

		public int TotalEventsCount { get; set; }
		public int CurrentPage { get; set; } = 1;

		public IEnumerable<EventModel> Events { get; set; } = new HashSet<EventModel>();
	}
}
