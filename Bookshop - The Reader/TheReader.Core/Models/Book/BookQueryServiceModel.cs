namespace TheReader.Core.Models.Book
{
	public class BookQueryServiceModel
	{
		public int TotalBooksCount { get; set; }
		public IEnumerable<BookServiceModel> Books { get; set; } = new HashSet<BookServiceModel>();
	}
}
