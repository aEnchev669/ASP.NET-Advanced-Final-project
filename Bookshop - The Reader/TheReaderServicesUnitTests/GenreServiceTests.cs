using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Genre;
using TheReader.Core.Models.Genre;
using TheReader.Core.Services;

namespace TheReaderServicesUnitTests
{
    public class GenreServiceTests
    {
        private DbContextOptions<TheReaderDbContext> dbOptions;
        private TheReaderDbContext dbContext;

        private IGenreService genreService;

        int genreId;
        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<TheReaderDbContext>()
                .UseInMemoryDatabase("TheReaderInMemoryDb")
                .Options;

            dbContext = new TheReaderDbContext(dbOptions);

            dbContext.Database.EnsureCreated();
            SeedData.SeedDatabase(dbContext);

            genreService = new GenreService(dbContext);

            genreId = 2;
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AllGenresAsync_ShouldReturnListOfAllGenres()
        {
            var expected = await dbContext
                .Genres
                .ToListAsync();

            var result = await genreService.AllGenresAsync();

            Assert.That(expected, Has.Count.EqualTo(result.Count()));
        }

        [Test]
        public async Task IsGenreExistAsync_ShouldReturnTrue()
        {
            bool result = await genreService.IsGenreExistAsync(genreId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsGenreExistAsync_ShouldReturnFalse()
        {
            int notExistGenre = 2332246;

            bool result = await genreService.IsGenreExistAsync(notExistGenre);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task AllGenresAsync_ShouldReturnArrayOfAllGenresNames()
        {
            var expected = await dbContext
                .Genres
                .Where(c => c.IsDeleted == false)
                .ToListAsync();

            var result = await genreService.AllGenresAsync();

            Assert.That(expected.Count, Is.EqualTo(result.Count));
        }

        [Test]
        public async Task IsGenreExistByNameAsync_ShouldReturnTrue()
        {
            var genreName = await dbContext
                .Genres
                .Where(c => c.Id == genreId)
                .Select(c => c.Name)
                .FirstAsync();

            bool result = await genreService.IsGenreExistByNameAsync(genreName);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsGenreExistByNameAsync_ShouldReturnFalse()
        {
            var genreName = "Unexisting Test Name";

            bool result = await genreService.IsGenreExistByNameAsync(genreName);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateNewGenreAsync_ShouldIncreaseCountOfCollection()
        {
            int currCount = await dbContext
                .Genres.CountAsync();

            var model = new NewGenreViewModel()
            {
                Name = "Test Category Name",
            };

            await genreService.CreateNewGenreAsync(model);

            int resultCount = await dbContext
                .Genres.CountAsync();

            Assert.That(resultCount, Is.EqualTo(currCount + 1));
        }

        [Test]
        public async Task CreateNewGenreAsync_ShouldAddNewGenre()
        {
           

            var model = new NewGenreViewModel()
            {
                Name = "Test Category Name",
            };

          await genreService.CreateNewGenreAsync(model);

          var result = await dbContext
                  .Genres
                  .AnyAsync(g => g.Name == model.Name);
         

            Assert.That(result, Is.EqualTo(true));
        }



        [Test]
        public async Task GetGenreByIdAsync_ShouldReturnRightGenre()
        {
            var expect = await dbContext
                .Genres
                .Where(c => c.Id == genreId && !c.IsDeleted)
                .FirstAsync();

            var result = await genreService.GetGenreByIdAsync(genreId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);

                Assert.That(expect.Name, Is.EqualTo(result.Name));
            });
        }

        [Test]
        public async Task DeleteBookAsync_ShouldReturnCorrectCount()
        {
            var genre = dbContext
                .Genres
                .Where(g => g.Id == genreId)
                .FirstOrDefault();

            var expected = new DeleteGenreViewModel()
            {
                Id = genre.Id,
                Name = genre.Name
            };

            var result = genreService.DeleteGenreAsync(genreId);

            Assert.AreEqual(expected.Name, (result.Name));
        }

        [Test]
        public async Task DeleteGenreConfirmAsync_ShouldTurnIsDeleteToTrue()
        {
            var genre = await dbContext
                .Genres
                .Where(c => c.Id == genreId)
                .FirstAsync();

            genre.IsDeleted = false;

            await genreService.DeleteGenreConfirmAsync(genreId);

            Assert.That(genre.IsDeleted, Is.True);
        }
    }
}
