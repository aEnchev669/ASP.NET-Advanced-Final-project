namespace TheReader.Core.Models.Event
{
	public class DeleteEventViewModel
	{
		public int Id { get; set; }

		public string Topic { get; set; } = null!;

		public string Location { get; set; } = null!;
	}
}
