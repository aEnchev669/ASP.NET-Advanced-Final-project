using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Enums;
using TheReader.Infrastructure.Data.Models.Orders;
using TheReader.Infrastructure.Data.Models.Review;
using static TheReader.Infrastructure.Constants.DataConstants;

namespace TheReader.Infrastructure.Data.Models.Account
{
    [Comment("Current user")]
	public class ApplicationUser : IdentityUser<string>
	{

        [Required]
		[MaxLength(ApplicationUserConstants.FirstNameMaxLength)]
		[Comment("The first name of the current user")]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[MaxLength(ApplicationUserConstants.LastNameMaxLength)]
		[Comment("The last name of the current user")]
		public string LastName { get; set; } = string.Empty;

		[Comment("The birth date of the current user")]
		public DateTime? BirthDate { get; set; }

		[Comment("The registration date of the current user")]
		public DateTime RegistrationDate { get; set; } = DateTime.Now;

		[Required]
		[Comment("The genre of the current user")]
		public GenderType Gender { get; set; }

		[Required]
		[Comment("Is the user deleten")]
		public bool IsDeleted { get; set; }

		[Comment("All comments posted by the current user")]
		public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

		[Comment("The current user's cart")]
		public ICollection<UserProduct> Cart { get; set; } = new HashSet<UserProduct>();

		[Comment("The current user's orders")]
		public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

	}
}
