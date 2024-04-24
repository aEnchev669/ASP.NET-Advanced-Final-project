using System.ComponentModel.DataAnnotations;
using TheReader.Core.Models.Book.Enums;
namespace TheReader.Core.Models.Book
{
	public class AllBooksQueryModel
	{
		public int BooksPerPage { get; } = 8;

		[Display(Name = "Search")]
		public string SearchTerm { get; set; } = String.Empty;

		[Display(Name = "Sorting")]
		public BooksSorting Sorting { get; set; }

		public int TotalBooksCount { get; set; }
		public int CurrentPage { get; set; } = 1;

		[Display(Name = "Genre")]
		public string Genre { get; set; } = null!;
		public IEnumerable<string> Genres { get; set; } = null!;

		public IEnumerable<BookServiceModel> Books { get; set; } = new HashSet<BookServiceModel>();
	}
}
