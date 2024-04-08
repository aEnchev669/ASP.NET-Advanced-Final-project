using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Models.Book;
using TheReader.Infrastructure.Data.Common;
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

        public IEnumerable<AllBooksViewModel> All()
        {
            throw new NotImplementedException();
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


	}
}
