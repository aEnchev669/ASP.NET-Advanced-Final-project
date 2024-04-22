namespace TheReader.Core.Models.Event
{
	public class DetailsEventViewModel
	{
		public int Id { get; set; }

		public string Topic { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string Location { get; set; } = null!;

		public DateTime Date { get; set; }

		public int Seats { get; set; }

		public decimal TicketPrice { get; set; }

	}
}
