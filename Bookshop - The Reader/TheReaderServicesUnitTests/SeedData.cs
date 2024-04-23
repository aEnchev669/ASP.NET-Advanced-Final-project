using BookshopTheReader.Infrastructure.Data;
using System.Globalization;
using System.Runtime.Serialization;
using TheReader.Infrastructure.Data.Models;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;
using TheReader.Infrastructure.Data.Models.Carts;
using TheReader.Infrastructure.Data.Models.Orders;
using Event = TheReader.Infrastructure.Data.Models.Events.Event;

namespace TheReaderServicesUnitTests
{
	public class SeedData
	{
		public static ApplicationUser? User;

		public static Book? Item;
		public static Order? Order;
		public static Cart? Cart;
		public static BookCart? CartBook;
		public static Event? Event;

		public static void SeedDatabase(TheReaderDbContext dbContext)
		{
			User = new ApplicationUser()
			{
				Id = "333aw2123467-33dda-e33a-8s2a-55566955544",
				UserName = "user",
				NormalizedUserName = "USER",
				Email = "user@abv.bg",
				NormalizedEmail = "USER@ABV.BG",
				PasswordHash = "AQAAAAEAACcQAAAAELe8pVu/pYozNSb46Onf++v8jGIFZKhEXaIX0ajNLPc72g7IlIwIgqq5ERU1v4LoYQ==",
				ConcurrencyStamp = "1f21023a-57d9-45b1-8b25-add0035ce3c1",
				SecurityStamp = "SGOWNX4SXZ3DIQOGFWKIYXUJF6IYLSV3",
				FirstName = "Ivan",
				LastName = "Ivanov",

			};

			dbContext.Users.Add(User);

			Cart = new Cart()
			{
				Id = 2,
				UserId = "333aw2123467-33dda-e33a-8s2a-55566955544",
				CreatedOn = DateTime.Now

			};

			CartBook = new BookCart()
			{
				CartId = 2,
				BookId = 2,
				Quantity = 3

			};

			Cart.BooksCarts.Add(CartBook);

			dbContext.BooksCarts.Add(CartBook);
			dbContext.Carts.Add(Cart);

			Order = new Order()
			{
				Id = 2,
				FirstName = "Aleksnadar",
				LastName = "Enchev",
				City = "Test City",
				CreatedOn = DateTime.Parse("2023-07-28 08:57:56.9627022"),
				UserId = "333aw2123467-33dda-e33a-8s2a-55566955544",
				CartId = 2,
				TotalPrice = 29.55M,
				Phone = "0899999991",
			};

			User.Orders.Add(Order);

			Event = new Event()
			{
				Id = 1,
				Topic = "Европейски музикален фестивал Варна 2024 - Програма",
				Description = "Европейкси музикален фестивал предсатвя на живо Елена Бакширова. За пръв път във Варна ще ни гостува Оркестър Кантус Фирмис с диригент Ивайло Кринчев",
				Location = "Зала 1 Градска художествена галерия",
				Date = DateTime.Now,
				Seats = 100,
				TicketPrice = 25
			};
			dbContext.SaveChanges();
		}
	}
}
