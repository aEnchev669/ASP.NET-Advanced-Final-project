using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Models.Book;
using TheReader.Core.Models.Book.Enums;
using TheReader.Core.Models.Genre;
using TheReader.Infrastructure.Data.Models.Books;

namespace TheReader.Core.Services
{
	public class BookService : IBookService
	{
		private readonly TheReaderDbContext dbContext;

		public BookService(TheReaderDbContext _dbContext)
		{
			dbContext = _dbContext;
		}

		public async Task<IEnumerable<AllBooksViewModel>> AllBooksAsync()
		{
			var allBooks = await dbContext
						 .Books
						 .AsNoTracking()
						 .Where(b => b.IsDeleted == false)
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

		public async Task<BookQueryServiceModel> AllAsync(string? genre = null,
			string? searchTerm = null,
			BooksSorting sorting = BooksSorting.Newest,
			int currentPage = 1,
			int booksPerPage = 10)
		{
			var booksToShow = dbContext
				.Books
				.Where(b => b.IsDeleted == false);

			if (genre != null)
			{
				booksToShow = booksToShow
					.Where(b => b.Genre.Name.ToLower() == genre.ToLower());
			}

			if (searchTerm != null)
			{
				string normalizedSearchTerm = searchTerm.ToLower();

				booksToShow = booksToShow
				.Where(b => normalizedSearchTerm.Contains(b.Title.ToLower())
				|| normalizedSearchTerm.Contains(b.Author.ToLower())
				|| normalizedSearchTerm.Contains(b.Genre.Name.ToLower())
				|| b.Title.ToLower().Contains(normalizedSearchTerm)
				|| b.Author.ToLower().Contains(normalizedSearchTerm)
				|| b.Genre.Name.ToLower().Contains(normalizedSearchTerm));
			}

			booksToShow = sorting switch
			{
				BooksSorting.Oldest => booksToShow.OrderBy(b => b.Id),
				BooksSorting.PriceAscending => booksToShow.OrderBy(b => b.Price).ThenByDescending(b => b.Id),
				BooksSorting.PriceDescending => booksToShow.OrderByDescending(b => b.Price).ThenByDescending(b => b.Id),
				BooksSorting.IdAscending => booksToShow.OrderBy(b => b.Id),
				BooksSorting.IdDescending => booksToShow.OrderByDescending(b => b.Id),
				_ => booksToShow.OrderByDescending(b => b.Id),
			};

			var books = await booksToShow
				.Skip((currentPage - 1) * booksPerPage)
				.Take(booksPerPage)
			.Select(b => new BookServiceModel()
			{
				Id = b.Id,
				Title = b.Title,
				Author = b.Author,
				Price = b.Price,
				ImageUrl = b.ImageUrl
			})
				.ToArrayAsync();

			int totalBooks = await booksToShow.CountAsync();

			return new BookQueryServiceModel()
			{
				Books = books,
				TotalBooksCount = totalBooks
			};
		}

		public async Task<IEnumerable<BookIndexViewModel>> AllIBooksByChoosenGenreAsync(string name)
		{
			var allBooks = await dbContext
				.Books
				.Where(b => b.Genre.Name == name && b.IsDeleted == false)
				.Select(b => new BookIndexViewModel
				{
					Id = b.Id,
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
					Pages = b.Pages,
				})
				.ToListAsync();

			return allBooks;
		}

		public async Task<bool> BookExistsAsync(int bookId)
		{
			return await dbContext
				.Books
				.AsNoTracking()
				.AnyAsync(b => b.Id == bookId);
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
				Pages = bookModel.Pages,
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
				book.Pages = bookModel.Pages;

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
					Pages = b.Pages,
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
				.Where(b => b.IsDeleted == false)
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

		public DeleteBookViewModel DeleteBookAsync(int bookId)
		{
			var book = dbContext
				.Books
				.Where(b => b.Id == bookId)
				.FirstOrDefault();

			var deleteBook = new DeleteBookViewModel()
			{
				Id = book.Id,
				Author = book.Author,
				Title = book.Title,
				ImageUrl = book.ImageUrl,
			};

			return deleteBook;
		}

		public async Task<int> DeleteBookConfirmAsync(int bookId)
		{

			var book = await dbContext.Books.FindAsync(bookId);
			book.IsDeleted = true;
			await dbContext.SaveChangesAsync();

			return book.Id;
		}
	}
}
