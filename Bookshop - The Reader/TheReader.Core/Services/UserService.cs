using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.User;
using TheReader.Core.Models.User;
using TheReader.Infrastructure.Data.Models.Enums;

namespace TheReader.Core.Services
{
	public class UserService : IUserService
	{
		private readonly TheReaderDbContext dbContext;

		public UserService(TheReaderDbContext _dbContext)
		{
			dbContext = _dbContext;
		}

		public async Task EditProfileAsync(string userId, EditProfileViewModel model)
		{
			var currUser = await dbContext
				 .Users
				 .Where(u => u.Id == userId && u.IsDeleted == false)
				 .FirstAsync();

			if (currUser != null)
			{
				currUser.FirstName = model.FirstName;
				currUser.LastName = model.LastName;
				currUser.Email = model.Email;
				currUser.BirthDate = model.BirthDate;
				currUser.UserName = model.UserName;
				currUser.Gender = (GenderType)model.Gender;

				await dbContext.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
		{
			var allUsers = await dbContext
				.Users
				.Select(u => new UserViewModel
				{
					Id = u.Id,
					UserName = u.UserName,
					Email = u.Email,
				})
				.ToArrayAsync();

			return allUsers;
		}

		public async Task<IEnumerable<UserViewModel>> GetAllUsersExceptCurrOneAsync(string userId)
		{
			var allUsers = await dbContext
			   .Users
			   .Where(u => u.Id != userId)
			   .Select(u => new UserViewModel()
			   {
				   Id = u.Id.ToString(),
				   UserName = u.UserName,
				   Email = u.Email,
			   })
			   .ToArrayAsync();

			return allUsers;
		}

		public async Task<EditProfileViewModel> GetUserByIdAsync(string userId)
		{
			var userModel = await dbContext
				 .Users
				 .Where(u => u.Id == userId && u.IsDeleted == false)
				 .Select(u => new EditProfileViewModel()
				 {
					 Id = u.Id,
					 UserName = u.UserName,
					 Email = u.Email,
					 FirstName = u.FirstName,
					 LastName = u.LastName,
					 Gender = u.Gender,
					 BirthDate = u.BirthDate,
				 })
				 .FirstAsync();

			return userModel;
		}

		public async Task<bool> IsUserDeletedAsync(string userId)
		{
			var user = await dbContext
				 .Users
				 .Where(u => u.Id == userId)
				 .FirstAsync();

			return user.IsDeleted;
		}

		public async Task SoftDeleteUserAsync(string userId)
		{
			var user = await dbContext
				.Users
				.Where(u => u.Id == userId && u.IsDeleted == false)
				.FirstAsync();


			user.FirstName = null;
			user.LastName = null;
			user.BirthDate = null;
			user.IsDeleted = true;

			await dbContext.SaveChangesAsync();
		}
	}
}
