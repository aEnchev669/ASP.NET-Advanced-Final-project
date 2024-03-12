using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Books;
using TheReader.Infrastructure.Data.Models.Carts;

namespace TheReader.Infrastructure.Data.Models
{
	[Comment("The cart with books")]
	public class BookCart
	{
		[Required]
		[Comment("The Current book's ientifier")]
		public int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		[Comment("The current book")]
		public Book Book { get; set; } = null!;

		[Required]
		[Comment("The current cart idetifier")]
		public int CartId { get; set; }

		[ForeignKey(nameof(CartId))]
		[Comment("The current cart")]
		public Cart Cart { get; set; } = null!;
	}
}
