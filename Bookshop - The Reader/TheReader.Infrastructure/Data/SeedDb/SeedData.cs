using Microsoft.AspNetCore.Identity;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;

namespace TheReader.Infrastructure.Data.SeedDb
{
	internal class SeedData
	{
		//Users
		public ApplicationUser AdminUser { get; set; } = null!;
		public ApplicationUser GuestUser { get; set; } = null!;

		//Books
		public Book ARandomWalkDownWallStreet { get; set; } = null!;
		public Book Trillions { get; set; } = null!;
		public Book TheStoryOfTheKamasutra { get; set; } = null!;
		public Book JohnAdams { get; set; } = null!;
		public Book ElonMusk { get; set; } = null!;
		public Book TheRagingStorm { get; set; } = null!;

		//Genres
		public Genre Fantasy { get; set; } = null!;
		public Genre ScienceFiction { get; set; } = null!;
		public Genre Dystopian { get; set; } = null!;
		public Genre Mystery { get; set; } = null!;
		public Genre Horror { get; set; } = null!;
		public Genre Finance { get; set; } = null!;
		public Genre Biography { get; set; } = null!;
		public Genre FoodAndDrink { get; set; } = null!;
		public Genre History { get; set; } = null!;
		public Genre Travel { get; set; } = null!;
		public Genre Crime { get; set; } = null!;


		private void SeedUsers()
		{
			var hasher = new PasswordHasher<IdentityUser>();

			AdminUser = new ApplicationUser()
			{
				

			};
		}
	}
}
