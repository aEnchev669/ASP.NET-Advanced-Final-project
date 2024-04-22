namespace TheReader.Core.Models.Event
{
	public class AllEventViewModel
	{
		public int Id { get; set; }

		public string Topic { get; set; } = null!;

		public string Location { get; set; } = null!;

		public DateTime Date { get; set; }

	}
}
