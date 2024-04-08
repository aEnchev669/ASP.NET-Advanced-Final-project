using TheReader.Core.Models.Book;

namespace TheReader.Core.Contracts.Book
{
	public interface IBookService
	{
		Task<IEnumerable<BookServiceIndexModel>> LastFourBooksAsync();
        public IEnumerable<AllBooksViewModel> All();
    }
}
