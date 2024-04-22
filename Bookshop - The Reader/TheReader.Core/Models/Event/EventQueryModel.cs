namespace TheReader.Core.Models.Event
{
	public class EventQueryModel
	{
		public int TotalEventsCount { get; set; }
		public IEnumerable<EventQueryModel> Events { get; set; } = new HashSet<EventQueryModel>();
	}
}
