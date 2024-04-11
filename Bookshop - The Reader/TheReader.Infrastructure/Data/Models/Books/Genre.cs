using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants;

namespace TheReader.Infrastructure.Data.Models.Books
{
	[Comment("Current genre")]
	public class Genre
	{
		[Key]
		[Comment("The current Genre's Identifier")]
		public int Id { get; set; }

		[Required]
		[MaxLength(GenreConstants.NameMaxLength)]
		[Comment("The current Genre's Name")]
		public string Name { get; set; } = string.Empty;

		public bool IsDeleted { get; set; } = false;

        [Comment("Books with the current genre")]
		public ICollection<Book> Books { get; set; } = new HashSet<Book>();
	}
}