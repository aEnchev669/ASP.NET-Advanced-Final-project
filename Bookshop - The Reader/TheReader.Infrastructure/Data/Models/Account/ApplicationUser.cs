using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TheReader.Infrastructure.Data.Models.Enums;
using TheReader.Infrastructure.Data.Models.Review;
using static TheReader.Infrastructure.Constants.DataConstants;

namespace TheReader.Infrastructure.Data.Models.Account
{
	public class ApplicationUser : IdentityUser
	{

		[Required]
		[MaxLength(ApplicationUserConstants.FirstNameMaxLength)]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[MaxLength(ApplicationUserConstants.LastNameMaxLength)]
		public string LastName { get; set; } = string.Empty;

		public DateTime? BirthDate { get; set; }

		public DateTime RegistrationDate { get; set; } = DateTime.Now;

		[Required]
		public GenderType Gender { get; set; }

		public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
		public ICollection<UserProduct> Cart { get; set; } = new HashSet<UserProduct>();
		public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

	}
}
