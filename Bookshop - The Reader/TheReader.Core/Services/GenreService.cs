using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Models.Genre;
using TheReader.Infrastructure.Data.Models.Books;

namespace TheReader.Core.Services
{
	public class GenreService : IGenreService
    {
        private readonly TheReaderDbContext dbContext;
        public GenreService(TheReaderDbContext _context)
        {
            dbContext = _context;
        }
        public async Task<ICollection<GenreViewModel>> AllGenresAsync()
        {
            var allGenres = await dbContext
                .Genres
                .Where(g => g.IsDeleted == false)
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToListAsync();

            return allGenres;
        }

        public async Task CreateNewGenreAsync(NewGenreViewModel genreModel)
        {
            Genre genre = new Genre()
            {
                Name = genreModel.Name,
            };

            await dbContext.Genres.AddAsync(genre);
            await dbContext.SaveChangesAsync();
        }

		//public async  Task EditGenreAsync(int cateogryId, NewGenreViewModel categoryModel)
		//{
		//	var currGenre = await dbContext
		//		.Genres
		//		.FindAsync(cateogryId);

		//	if (currGenre != null)
		//	{
		//		currGenre.Name = categoryModel.Name;
		//		await dbContext.SaveChangesAsync();
		//	}
		//}

		public async Task<NewGenreViewModel> GetGenreByIdAsync(int id)
        {
            var genre = await dbContext
                .Genres
                .Where(g => g.IsDeleted == false && g.Id == id)
                .Select(g => new NewGenreViewModel
                {
                    Name = g.Name,
                })
                .FirstAsync();

            return genre;
        }

		public async Task<NewGenreViewModel> GetGenreByNameAsync(string name)
		{
			var genre = await dbContext
			   .Genres
			   .Where(g => g.IsDeleted == false && g.Name == name)
			   .Select(g => new NewGenreViewModel
			   {
				   Name = g.Name,
			   })
			   .FirstAsync();

			return genre;
		}

		public async Task<bool> IsGenreExistAsync(int id)
        {
            var isIdExist = await dbContext
                .Genres
                .Where(c => c.IsDeleted == false)
                .AnyAsync(c => c.Id == id);

            return isIdExist;
        }

        public async Task<bool> IsGenreExistByNameAsync(string genreName)
        {
            var isExist = await dbContext
                .Genres
                .Where(g => g.IsDeleted == false)
                .AnyAsync(g => g.Name == genreName);

            return isExist;
        }

        public async Task SoftDeleteGenreAsync(int genreId)
        {
            Genre genre = await dbContext
                .Genres
                .Where(g => g.Id == genreId && g.IsDeleted == false)
                .FirstAsync();

            if (genre != null)
            {
                genre.IsDeleted = true;

                await dbContext.SaveChangesAsync();
            }
        }


    }
}
