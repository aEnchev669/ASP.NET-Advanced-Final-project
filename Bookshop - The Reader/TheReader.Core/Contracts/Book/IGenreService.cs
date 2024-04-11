using TheReader.Core.Models.Genre;

namespace TheReader.Core.Contracts.Book
{
    public interface IGenreService
    {
        Task<ICollection<GenreViewModel>> AllGenresAsync();
        Task<bool> IsGenreExistByNameAsync(string genreName);
        Task<bool> IsGenreExistByIdAsync(int id);
        Task CreateNewGenreAsync(NewGenreViewModel genreModel);
        Task SoftDeleteGenreAsync(int genreId);
        Task<NewGenreViewModel> GetGenreByIdAsync(int genreId);

    }
}
