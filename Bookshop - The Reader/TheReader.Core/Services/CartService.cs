using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Cart;
using TheReader.Core.Models.Cart;
using TheReader.Infrastructure.Data.Models;
using TheReader.Infrastructure.Data.Models.Books;
using TheReader.Infrastructure.Data.Models.Carts;

namespace TheReader.Core.Services
{
    public class CartService : ICartService
	{
		private readonly TheReaderDbContext dbContext;

		public CartService(TheReaderDbContext _dbContext)
		{
			dbContext = _dbContext;
		}

		public async Task AddBookToCartAsync(int bookId, int cartId, string userId)
		{
			bool isBookExistInCart = await dbContext
			   .BooksCarts
			   .AnyAsync(bc => bc.BookId == bookId
							&& bc.CartId == cartId);

			Book currBook = await dbContext
				.Books
				.Where(b => b.Id == bookId)
				.FirstAsync();

			Cart cart = await dbContext
				.Carts
				.Where(c => c.Id == cartId)
				.FirstAsync();

			BookCart? currCartBook;

			if (!isBookExistInCart)
			{
				currCartBook = await dbContext
				 .BooksCarts
				 .Where(bc => bc.BookId == bookId && bc.CartId == cartId)
				 .FirstOrDefaultAsync();

				if (currCartBook == null)
				{
					currCartBook = new BookCart()
					{
						BookId = currBook.Id,
						CartId = cart.Id
					};
				}

				dbContext.BooksCarts.Add(currCartBook);

			}
			else
			{
				currCartBook = await dbContext
					.BooksCarts
					.Where(bc => bc.BookId == bookId && bc.CartId == cartId)
					.FirstAsync();

				currCartBook.Quantity++;
			}

			await dbContext.SaveChangesAsync();
		}

		public async Task CreateCartAsync(string userId)
		{

			Cart cart = new Cart()
			{
				UserId = userId
			};

			dbContext.Carts.Add(cart);
			await dbContext.SaveChangesAsync();
		}

		public async Task DecreaseBookCountAsync(int bookId, int cartId)
		{
			var cartItem = await dbContext
			   .BooksCarts
			   .Where(bc => bc.BookId == bookId && bc.CartId == cartId)
			   .FirstAsync();

			cartItem.Quantity--;

			await dbContext.SaveChangesAsync();
		}

		public async Task<CartFormViewModel> GetCartByOrderIdAsync(int orderId)
		{
			var currCart = await dbContext
			   .Orders
			   .Where(o => o.Id == orderId)
			   .Select(o => new CartFormViewModel()
			   {
				   Id = o.CartId,
				   Books = o.Cart.BooksCarts
				   .Select(ci => new CartBookViewModel()
				   {
					   BookId = ci.BookId,
					   Title = ci.Book.Title,
					   Image = ci.Book.ImageUrl,
					   Price = ci.Book.Price,
					   Quantity = ci.Quantity,
					   TotalPrice = ci.Quantity * ci.Book.Price
				   })
				   .ToArray()
			   })
			   .FirstAsync();

			return currCart;
		}

		public async Task<CartFormViewModel?> GetCurrCartByUserIdAsync(string userId)
		{
			var cart = await dbContext
				.Carts
				.OrderByDescending(c => c.CreatedOn)
				.Where(c => c.UserId == userId)
				.Select(c => new CartFormViewModel()
				{
					Id = c.Id,
					Books = c.BooksCarts
					.Select(bc => new CartBookViewModel()
					{
						BookId = bc.BookId,
						Title = bc.Book.Title,
						Image = bc.Book.ImageUrl,
						Price = bc.Book.Price,
						Quantity = bc.Quantity,
						TotalPrice = bc.Quantity * bc.Book.Price
					})
					.ToArray()

				})
				.FirstOrDefaultAsync();

			if (cart != null)
			{
				cart!.TotalPrice += cart.Books.Select(b => b.TotalPrice).Sum();
			}

			return cart;
		}

		public async Task IncreaseBookCountAsync(int bookId, int cartId)
		{
			var cartItem = await dbContext
				.BooksCarts
				.Where(bc => bc.BookId == bookId && bc.CartId == cartId)
				.FirstAsync();

			cartItem.Quantity++;

			await dbContext.SaveChangesAsync();
		}

		public async Task RemoveBookFromCartAsync(int bookId, int cartId)
		{
			var bookCart = await dbContext
				.BooksCarts
				.Where(bc => bc.BookId == bookId && bc.CartId == cartId)
				.FirstAsync();

			if (bookCart != null)
			{
				dbContext.BooksCarts.Remove(bookCart);
				await dbContext.SaveChangesAsync();
			}
		}
	}


}
