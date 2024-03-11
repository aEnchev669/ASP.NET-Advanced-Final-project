using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;

namespace TheReader.Infrastructure.Data.Models
{
	[Comment("User")]
	public class UserProduct
	{
		[Key]
		[Comment("Current Identifier")]
		public int Id { get; set; }

		[Required]
		public int ApplicationUserId { get; set; }

		[ForeignKey(nameof(ApplicationUserId))]
		public ApplicationUser ApplicationUser { get; set; } = null!;

		[Required]
		public int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		public Book Book { get; set; } = null!;
	}
}
