using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.User;
using TheReader.Core.Models.User;
using TheReader.Core.Services;
using TheReader.Infrastructure.Data.Models.Enums;
using static TheReaderServicesUnitTests.SeedData;

namespace TheReaderServicesUnitTests
{
	public class UserServiceTests
	{
		private DbContextOptions<TheReaderDbContext> dbOptions;
		private TheReaderDbContext dbContext;

		private IUserService userService;




		[SetUp]
		public void SetUp() 
		{
			dbOptions = new DbContextOptionsBuilder<TheReaderDbContext>()
				.UseInMemoryDatabase("TheReaderInMemoryDb" )
				.Options;

			dbContext = new TheReaderDbContext(dbOptions);

			dbContext.Database.EnsureCreated();
			SeedData.SeedDatabase(dbContext);

			userService = new UserService(dbContext);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task GetAllUsersAsync_ShouldReturnListOfAllUsers()
		{
			var allUsers = await dbContext.Users.ToListAsync();

			var resultUser = await userService.GetAllUsersAsync();
			var usersCount = resultUser.Count();

			Assert.That(usersCount, Is.EqualTo(allUsers.Count()));
		}

		[Test]
		public async Task GetUserByIdAsync_ShouldReturnNotNull()
		{
			var userId = User!.Id;

			var user = await userService.GetUserByIdAsync(userId);
			Assert.Multiple(() =>
			{
				Assert.That(user, Is.Not.Null);

				Assert.That(User.UserName, Is.EqualTo(user.UserName));
				Assert.That(User.Email, Is.EqualTo(user.Email));
				Assert.That(User.FirstName, Is.EqualTo(user.FirstName));
				Assert.That(User.LastName, Is.EqualTo(user.LastName));
			});
		}

        [Test]
		public async Task GetAllUsersExceptCurrOneAsync_ShouldReturnAllUsersMinusOne()
		{
			var currUser = User;

			var allUsers = dbContext.Users.Count();
			var users = await userService.GetAllUsersExceptCurrOneAsync(currUser!.Id);

			Assert.That(users.Count(), Is.EqualTo(allUsers - 1));
		}

		[Test]
		public async Task EditProfileAsync_ShouldReturnEditedUser()
		{
			var user = await dbContext.Users.FirstOrDefaultAsync();

			var model = new EditProfileViewModel()
			{
				FirstName = "Test",
				LastName = "Testov",
				Email = "test@abv.bg",
				UserName = "testOv",
				Gender = GenderType.Male,
				BirthDate = DateTime.Now
			};

			await userService.EditProfileAsync(user!.Id, model);

			Assert.Multiple(() =>
			{
				Assert.That(user, Is.Not.Null);

				Assert.That(user.UserName, Is.EqualTo(model.UserName));
				Assert.That(user.Email, Is.EqualTo(model.Email));
				Assert.That(user.FirstName, Is.EqualTo(model.FirstName));
				Assert.That(user.LastName, Is.EqualTo(model.LastName));
				Assert.That(user.Gender, Is.EqualTo(model.Gender));
				Assert.That(user.BirthDate, Is.EqualTo(model.BirthDate));
			});
		}

		[Test]
		public async Task SoftDeleteUserAsync_ShouldIsDeleteGoTrue()
		{
			string userId = User!.Id.ToString();

			await userService.SoftDeleteUserAsync(userId);

			Assert.Multiple(() =>
			{
				Assert.That(User.IsDeleted, Is.True);

				Assert.That(User.BirthDate, Is.Null);
				Assert.That(User.FirstName, Is.Null);
				Assert.That(User.LastName, Is.Null);
			});
		}

		[Test]
		public async Task IsUserDeletedAsync_ShouldReturnTrue()
		{
			User!.IsDeleted = true;

			var isDeleted = await userService.IsUserDeletedAsync(User.Id.ToString());

			Assert.That(isDeleted, Is.True);
		}

		[Test]
		public async Task IsUserDeletedAsync_ShouldReturnFalse()
		{
			var isDeleted = await userService.IsUserDeletedAsync(User!.Id.ToString());

			Assert.That(isDeleted, Is.False);
		}
	}
}
