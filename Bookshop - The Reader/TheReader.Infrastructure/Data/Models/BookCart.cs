using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheReader.Infrastructure.Data.Models.Books;
using TheReader.Infrastructure.Data.Models.Carts;

namespace TheReader.Infrastructure.Data.Models
{
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
