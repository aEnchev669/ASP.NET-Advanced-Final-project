using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Models.Book;
using TheReader.Core.Models.Genre;
using TheReader.Infrastructure.Data.Models.Books;

namespace TheReader.Core.Services
{
    public class BookService : IBookService
    {
        private readonly TheReaderDbContext dbContext;
        private readonly IBookService bookService;

        public BookService(TheReaderDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Task<AllBooksFilteredAndPagedServiceModel> AllActiveBooksQueryAsync(AllBooksQueryModel queryModel)
        {
            //    IQueryable<Book> bookQuery = dbContext
            ////        .Books
            ////        .Where(b => b.IsDeleted == false)
            ////        .AsQueryable();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AllBooksViewModel>> AllBooksAsync()
        {

            //         var books = await dbContext
            //             .Books
            //             .Where(b => b.IsDeleted == false)
            //             .ToListAsync();

            //if (books == null || books.Count == 0)
            //{
            //	return null;
            //}
            //List<AllBooksViewModel> booksDto = new List<AllBooksViewModel>();
            //         foreach (var book in books.Where(x => x.IsDeleted == false))
            //         {
            //             booksDto.Add(new AllBooksViewModel()
            //             {
            //                 Id = book.Id,
            //                 Author = book.Author,
            //                 Title = book.Title,
            //                 ImageURL = book.ImageUrl,
            //                 Price = book.Price,
            //             });

            var allBooks = await dbContext
                         .Books
                         .AsNoTracking()
                        .OrderByDescending(b => b.PublishedYear)
                        .Select(b => new AllBooksViewModel
                        {
                            Id = b.Id,
                            Author = b.Author,
                            Title = b.Title,
                            ImageURL = b.ImageUrl,
                            Price = b.Price,

                        })
                        .ToListAsync();

            return allBooks;
        }

        public async Task<IEnumerable<BookIndexViewModel>> AllIBooksByChoosenGenreAsync(string name)
        {
            var allBooks = await dbContext
                .Books
                .Where(b => b.Genre.Name == name && b.IsDeleted == false)
                .Select(b => new BookIndexViewModel
                {
                    ISBN = b.ISBN,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    Price = b.Price,
                    PublishedYear = b.PublishedYear,
                    Genre = b.Genre.Name,
                    ImageUrl = b.ImageUrl,
                    Language = b.Language,
                    Weight = b.Weight,
                })
                .ToListAsync();

            return allBooks;
        }

        public async Task CreateBookAsync(BookFormViewModel bookModel)
        {
            Book newBook = new Book()
            {
                ISBN = bookModel.ISBN,
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                Price = bookModel.Price,
                PublishedYear = bookModel.PublishedYear,
                GenreId = bookModel.GenreId,
                ImageUrl = bookModel.ImageUrl,
                Language = bookModel.Language,
                Weight = bookModel.Weight,
            };

            await dbContext.Books.AddAsync(newBook);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditBookAsync(int id, BookFormViewModel bookModel)
        {
            var book = await dbContext
                 .Books
                 .FindAsync(id);

            if (book != null)
            {
                book.Title = bookModel.Title;
                book.Author = bookModel.Author;
                book.Description = bookModel.Description;
                book.Price = bookModel.Price;
                book.PublishedYear = bookModel.PublishedYear;
                book.Weight = bookModel.Weight;
                book.GenreId = bookModel.GenreId;
                book.ImageUrl = bookModel.ImageUrl;
                book.Language = bookModel.Language;
                book.ISBN = bookModel.ISBN;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<BookFormViewModel> GetBookByIdAsync(int bookId)
        {
            var genres = await dbContext
                 .Genres
                 .Select(c => new GenreViewModel
                 {
                     Id = c.Id,
                     Name = c.Name,
                 })
                 .ToListAsync();

            var currBook = await dbContext
                .Books
                .Where(book => book.Id == bookId)
                .Select(b => new BookFormViewModel()
                {
                    ISBN = b.ISBN,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    Price = b.Price,
                    PublishedYear = b.PublishedYear,
                    GenreId = b.GenreId,
                    ImageUrl = b.ImageUrl,
                    Language = b.Language,
                    Weight = b.Weight,
                })
                .FirstAsync();

            return currBook;
        }

        public async Task<BookIndexViewModel> GetDetailsByIdAsync(int bookId)
        {
            Book book = await dbContext
                 .Books
                 .Include(b => b.Genre)
                 .Where(book => book.Id == bookId)
                 .FirstAsync();

            BookIndexViewModel bookModel = new BookIndexViewModel()
            {
                Id = bookId,
                ISBN = book.ISBN,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
                Pages = book.Pages,
                PublishedYear = book.PublishedYear,
                Genre = book.Genre.Name,
                ImageUrl = book.ImageUrl,
                Language = book.Language,
                Weight = Math.Round(book.Weight, 5)
            };

            return bookModel;
        }

        public async Task<IEnumerable<BookServiceIndexModel>> LastFourBooksAsync()
        {
            return await dbContext
                .Books
                .OrderByDescending(x => x.Id)
                .Take(4)
                .Select(x => new BookServiceIndexModel
                {
                    Id = x.Id,
                    Author = x.Author,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task SoftDeleteBookAsync(int bookId)
        {
            Book book = await dbContext
                .Books
                .Where(book => book.Id == bookId)
                .FirstAsync();

            book.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }
    }
}
