using TheReader.Core.Models.Book;
using TheReader.Core.Models.Book.Enums;

namespace TheReader.Core.Contracts.Book
{
    public interface IBookService
    {
        Task<IEnumerable<BookServiceIndexModel>> LastFourBooksAsync();
		Task<BookQueryServiceModel> AllAsync(
			string? genre = null,
		string? searchTerm = null,
		BooksSorting sorting = BooksSorting.Newest,
			int currentPage = 1,
			int booksPerPage = 10);
		Task CreateBookAsync(BookFormViewModel bookModel);
        Task<BookFormViewModel> GetBookByIdAsync(int bookId);
		Task EditBookAsync(int id, BookFormViewModel bookModel);
        Task<BookIndexViewModel> GetDetailsByIdAsync(int bookId);
        DeleteBookViewModel DeleteBookAsync(int bookId);
        Task<int> DeleteBookConfirmAsync(int bookId);
		Task<IEnumerable<BookIndexViewModel>> AllIBooksByChoosenGenreAsync(string name);
        Task<bool> BookExistsAsync(int bookId);
    }
}
