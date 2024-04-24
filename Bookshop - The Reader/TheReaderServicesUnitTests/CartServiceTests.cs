using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Cart;
using TheReader.Core.Services;

namespace TheReaderServicesUnitTests
{
	public class CartServiceTests
	{
		private DbContextOptions<TheReaderDbContext> dbOptions;
		private TheReaderDbContext dbContext;

		private ICartService cartService;

		int bookId;
		string userId;
		int orderId;
		int cartId;

		[SetUp]
		public void SetUp()
		{
			dbOptions = new DbContextOptionsBuilder<TheReaderDbContext>()
				.UseInMemoryDatabase("TheReaderInMemoryDb")
				.Options;

			dbContext = new TheReaderDbContext(dbOptions);

			dbContext.Database.EnsureCreated();
			SeedData.SeedDatabase(dbContext);

			cartService = new CartService(dbContext);

			bookId = 2;
			userId = "333aw2123467-33dda-e33a-8s2a-55566955544";
			orderId = 2;
			cartId = 2;
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task GetCurrCartByUserIdAsync_ShouldReturnLastCreatedCartOfThisUser()
		{
			var expected = await dbContext
				.Carts
				.Where(c => c.UserId.ToString() == userId)
				.LastAsync();

			var result = await cartService.GetCurrCartByUserIdAsync(userId);

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(expected.Id, Is.EqualTo(result.Id));
				Assert.That(expected.BooksCarts.Count(), Is.EqualTo(result.Books.Count()));
			});

		}

		[Test]
		public async Task GetCartByOrderIdAsync_ShouldReturnRightCart()
		{
			var expected = await dbContext
				.Orders
				.Where(o => o.Id == orderId)
				.Select(o => o.Cart)
				.FirstAsync();

			var result = await cartService.GetCartByOrderIdAsync(orderId);

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(expected.Id, Is.EqualTo(result.Id));
				Assert.That(expected.BooksCarts.Count(), Is.EqualTo(result.Books.Count()));
			});
		}

		[Test]
		public async Task CreateCartAsync_ShouldCreateNewCard()
		{
			var before = dbContext
				.Carts
				.Count(c => c.UserId.ToString() == userId);

			await cartService.CreateCartAsync(userId);

			var result = dbContext
				.Carts
				.Count(c => c.UserId.ToString() == userId);

			Assert.That(result, Is.EqualTo(before + 1));
		}


        [Test]
		public async Task AddItemToCartAsync_ShouldAddItemToLastCurrUserCart()
		{
			var before = dbContext
				.BooksCarts
				.Count(ci => ci.BookId == bookId && ci.CartId == cartId);

			await cartService.AddBookToCartAsync(bookId, cartId, userId);

			var result = dbContext
				.BooksCarts
				.Count(ci => ci.BookId == bookId && ci.CartId == cartId);

			Assert.That(result, Is.EqualTo(before));

		}

		[Test]
		public async Task AddItemToCartAsync_ShouldIncreaseQuantity()
		{
			await cartService.AddBookToCartAsync(bookId, cartId, userId);

			int before = dbContext
				.BooksCarts
				.Where(ci => ci.BookId == bookId && ci.CartId == cartId)
				.Select(ci => ci.Quantity)
				.First();

			await cartService.AddBookToCartAsync(bookId, cartId, userId);

			int result = dbContext
			   .BooksCarts
			   .Where(ci => ci.BookId == bookId && ci.CartId == cartId)
			   .Select(ci => ci.Quantity)
			   .First();

			Assert.That(result, Is.EqualTo(before + 1));
		}

		[Test]
		public async Task RemoveItemFromCartAsync_ShouldRemoveItemFromCollection()
		{
			int bookId = 2;

			int before = dbContext
				.BooksCarts
				.Count(ci => ci.CartId == cartId);

			await cartService.RemoveBookFromCartAsync(bookId, cartId);

			int result = dbContext
				.BooksCarts
				.Count(ci => ci.CartId == cartId);

			Assert.That(result, Is.EqualTo(before - 1));
		}

		[Test]
		public async Task IncreaseItemCountAsync_ShouldIncreaseQuantityOfItem()
		{
			int alreadyAddedCartItemId = 2;

			int before = dbContext
				.BooksCarts
				.Where(ci => ci.BookId == alreadyAddedCartItemId && ci.CartId == cartId)
				.Select(ci => ci.Quantity)
				.First();

			await cartService.IncreaseBookCountAsync(alreadyAddedCartItemId, cartId);

			int result = dbContext
				.BooksCarts
				.Where(ci => ci.BookId == alreadyAddedCartItemId && ci.CartId == cartId)
				.Select(ci => ci.Quantity)
				.First();

			Assert.That(result, Is.EqualTo(before + 1));
		}

		[Test]
		public async Task DecreaseItemCountAsync_ShouldDecreaseQuantityOfItem()
		{
			int alreadyAddedCartItemId = 2;

			int before = dbContext
				.BooksCarts
				.Where(ci => ci.BookId == alreadyAddedCartItemId && ci.CartId == cartId)
				.Select(ci => ci.Quantity)
				.First();

			await cartService.DecreaseBookCountAsync(alreadyAddedCartItemId, cartId);

			int result = dbContext
				.BooksCarts
				.Where(ci => ci.BookId == alreadyAddedCartItemId && ci.CartId == cartId)
				.Select(ci => ci.Quantity)
				.First();

			Assert.That(result, Is.EqualTo(before - 1));
		}
	}
}
