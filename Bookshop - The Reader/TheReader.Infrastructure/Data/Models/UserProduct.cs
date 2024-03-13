using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;

namespace TheReader.Infrastructure.Data.Models
{
	[Comment("User's products")]
	public class UserProduct
	{
		[Key]
		[Comment("Current Identifier")]
		public int Id { get; set; }

		[Required]
		[Comment("Identifier the current user")]
		public string ApplicationUserId { get; set; } = string.Empty;

		[ForeignKey(nameof(ApplicationUserId))]
		[Comment("The current user")]
		public ApplicationUser ApplicationUser { get; set; } = null!;

		[Required]
		[Comment("Book id of the current user")]
		public int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		[Comment("The book of the current user")]
		public Book Book { get; set; } = null!;
	}
}
