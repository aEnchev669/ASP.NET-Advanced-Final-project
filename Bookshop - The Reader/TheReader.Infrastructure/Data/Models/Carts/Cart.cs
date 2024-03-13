using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Account;

namespace TheReader.Infrastructure.Data.Models.Carts
{
	[Comment("Current cart")]
	public class Cart
	{
		[Key]
		[Comment("Current cart identifier")]
		public int Id { get; set; }

		[Required]
		[Comment("The current user identifier")]
		public string UserId { get; set; } = string.Empty;
		[ForeignKey(nameof(UserId))]
		[Comment("The current user")]
		public ApplicationUser User { get; set; } = null!;

		[Required]
		[Comment("Collection of all books in the current cart")]
		public ICollection<BookCart> BooksCarts { get; set; } = new HashSet<BookCart>();
    }
}
