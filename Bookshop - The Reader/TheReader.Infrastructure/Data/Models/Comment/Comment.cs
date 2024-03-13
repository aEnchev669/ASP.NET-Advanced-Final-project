using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;
using static TheReader.Infrastructure.Constants.DataConstants;

namespace TheReader.Infrastructure.Data.Models.Review
{
	[Comment("Current Comment")]
	public class Comment
	{
		[Key]
		[Comment("Current comment Identifier")]
		public int Id { get; set; }

		[Required]
		[MaxLength(CommentConstants.TextMaxLength)]
		[Comment("Current comment text")]
		public string Text { get; set; } = string.Empty;

		[Comment("The date of creation of the current comemnt")]
		public DateTime DatePosted { get; set; } = DateTime.Now;

		[Required]
		[Comment("Book identifier")]
		public int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		[Comment("The current book commentary")]
		public Book Book { get; set; } = null!;

		[Required]
		[Comment("User identifier")]
		public string UserId { get; set; } = string.Empty;

		[ForeignKey(nameof(UserId))]
		[Comment("The user who created the current comment")]
		public ApplicationUser User { get; set; } = null!;


	}
}
