using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;
using static TheReader.Infrastructure.Constants.DataConstants;

namespace TheReader.Infrastructure.Data.Models.Review
{
	public class Comment
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(CommentConstants.TextMaxLength)]
		public string Text { get; set; } = string.Empty;

		public DateTime DatePosted { get; set; } = DateTime.Now;

		[Required]
		public int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		public Book Book { get; set; } = null!;

		[Required]
		public int UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public ApplicationUser User { get; set; } = null!;


	}
}
