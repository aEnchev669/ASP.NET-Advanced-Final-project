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
        Task SoftDeleteBookAsync(int bookId);
        Task<IEnumerable<BookIndexViewModel>> AllIBooksByChoosenGenreAsync(string name);
        Task<AllBooksFilteredAndPagedServiceModel> AllActiveBooksQueryAsync(AllBooksQueryModel queryModel);
    }
}
