using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheReader.Infrastructure.Data.Models.Carts
{
	public class Cart
	{
		[Key]
		[Comment("Current cart identifier")]
		public int Id { get; set; }

        [Required]
		[Comment("The current user identifier")]
        public int UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		[Comment("The current user")]
		public IdentityUser User { get; set; } = null!;

		[Required]
		[Comment("Collection of all books in the current cart")]
		public ICollection<BookCart> BooksCarts { get; set; } = new HashSet<BookCart>();
    }
}
