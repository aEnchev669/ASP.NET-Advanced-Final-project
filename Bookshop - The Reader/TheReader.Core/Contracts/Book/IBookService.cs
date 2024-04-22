using TheReader.Core.Models.Book;

namespace TheReader.Core.Contracts.Book
{
    public interface IBookService
    {
        Task<IEnumerable<BookServiceIndexModel>> LastFourBooksAsync();
        public Task<IEnumerable<AllBooksViewModel>> AllBooksAsync();
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
