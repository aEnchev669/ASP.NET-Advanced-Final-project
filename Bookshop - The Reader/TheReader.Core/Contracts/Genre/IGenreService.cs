using TheReader.Core.Models.Book;
using TheReader.Core.Models.Genre;

namespace TheReader.Core.Contracts.Genre
{
    public interface IGenreService
    {
        Task<ICollection<GenreViewModel>> AllGenresAsync();
        Task<bool> IsGenreExistByNameAsync(string genreName);
        Task<bool> IsGenreExistAsync(int id);
        Task CreateNewGenreAsync(NewGenreViewModel genreModel);
        Task SoftDeleteGenreAsync(int genreId);
        Task<NewGenreViewModel> GetGenreByIdAsync(int genreId);
        Task<NewGenreViewModel> GetGenreByNameAsync(string name);
        DeleteGenreViewModel DeleteGenreAsync(int bookId);
        Task<int> DeleteGenreConfirmAsync(int bookId);
        //Task EditGenreAsync(int cateogryId, NewGenreViewModel categoryModel);

    }
}
