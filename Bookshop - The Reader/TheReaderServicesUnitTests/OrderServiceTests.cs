using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Order;
using TheReader.Core.Models.Order;
using TheReader.Core.Services;
using TheReader.Infrastructure.Data.Models.Orders;

namespace TheReaderServicesUnitTests
{
	public class OrderServiceTests
	{
		private DbContextOptions<TheReaderDbContext> dbOptions;
		private TheReaderDbContext dbContext;

		private IOrderService orderService;

		[SetUp]
		public void SetUp()
		{
			dbOptions = new DbContextOptionsBuilder<TheReaderDbContext>()
				.UseInMemoryDatabase("TheReaderInMemoryDb")
				.Options;

			dbContext = new TheReaderDbContext(dbOptions);

			dbContext.Database.EnsureCreated();
			SeedData.SeedDatabase(dbContext);

			orderService = new OrderService(dbContext);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task GetOrderDetailsAsync_ShouldReturnOrderModel()
		{
			var order = await dbContext
				.Orders
				.FirstAsync();

			var resultOrder = await orderService.GetOrderDetailsAsync(order.CartId);

			Assert.Multiple(() =>
			{
				Assert.That(resultOrder, Is.Not.Null);

				Assert.That(order.Id, Is.EqualTo(resultOrder!.Id));
				Assert.That(order.FirstName, Is.EqualTo(resultOrder.FirstName));
				Assert.That(order.LastName, Is.EqualTo(resultOrder.LastName));
				Assert.That(order.City, Is.EqualTo(resultOrder.City));
				Assert.That(order.CartId, Is.EqualTo(resultOrder.CartId));
				Assert.That(order.UserId, Is.EqualTo(resultOrder.UserId));
				Assert.That(order.TotalPrice, Is.EqualTo(resultOrder.TotalPrice));
				Assert.That(order.Phone, Is.EqualTo(resultOrder.Phone));
			});
		}

        [Test]
		public async Task GetAllOrdersByUserIdAsync_ShouldResturnListOfOrders()
		{
			var userId = "333aw2123467-33dda-e33a-8s2a-55566955544";

			var allOrders = await dbContext
				.Orders
				.Where(o => o.UserId.ToString() == userId)
				.ToListAsync();

			var result = await orderService.GetAllOrdersByUserIdAsync(userId);

			Assert.That(allOrders, Has.Count.EqualTo(result.Count()));

		}

        
        [Test]
		public async Task CreateOrderAsync_ShouldCreateNewOrder()
		{
			var before = await dbContext
				.Orders
				.Where(o => o.UserId == "333aw2123467-33dda-e33a-8s2a-55566955544")
				.ToListAsync();

			var order = new OrderFormViewModel()
			{
				FirstName = "Test",
				LastName = "Last Name Test",
				City = "Test City",
				CartId = 2,
				UserId = "333aw2123467-33dda-e33a-8s2a-55566955544",
				TotalPrice = 22.35M
			};

			await orderService.CreateOrderAsync(order);

			var result = await dbContext
				.Orders
				.Where(o => o.UserId == "333aw2123467-33dda-e33a-8s2a-55566955544")
				.ToListAsync();

			Assert.That(result, Has.Count.EqualTo(before.Count() + 1));
		}

        [Test]
        public async Task CreateOrderAsync_ShouldCreateNewOrderName()
        {
            
            var order = new OrderFormViewModel()
            {
                FirstName = "Test",
                LastName = "Last Name Test",
                City = "Test City",
                CartId = 2,
                UserId = "333aw2123467-33dda-e33a-8s2a-55566955544",
                TotalPrice = 22.35M
            };

            await orderService.CreateOrderAsync(order);

            var result = await dbContext
                .Orders
                .Where(o => o.UserId == "333aw2123467-33dda-e33a-8s2a-55566955544" && o.LastName == order.LastName)
                .Select(o => o.LastName)
                .ToListAsync();



			Assert.That(result[0], Is.EqualTo(order.LastName));
        }

        [Test]
		public async Task GetLastOrderListByUserIdAsync_ShouldReturnLastOrder()
		{
			var userId = "333aw2123467-33dda-e33a-8s2a-55566955544";

			var expected = await dbContext
				.Orders
				.Where(o => o.UserId == userId)
				.LastAsync();

			var result = await orderService.GetLastOrderListByUserIdAsync(userId.ToString());

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(expected.Id, Is.EqualTo(result!.Id));
				Assert.That(expected.FirstName, Is.EqualTo(result.FirstName));
				Assert.That(expected.LastName, Is.EqualTo(result.LastName));
				Assert.That(expected.City, Is.EqualTo(result.City));
				Assert.That(expected.CartId, Is.EqualTo(result.CartId));
				Assert.That(expected.UserId.ToString(), Is.EqualTo(result.UserId));
				Assert.That(expected.TotalPrice, Is.EqualTo(result.TotalPrice));
				Assert.That(expected.Phone, Is.EqualTo(result.Phone));
			});
		}
	}
}
