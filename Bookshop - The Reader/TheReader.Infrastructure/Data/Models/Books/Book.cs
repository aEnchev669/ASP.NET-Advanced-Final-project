using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Review;
using static TheReader.Infrastructure.Constants.DataConstants;

namespace TheReader.Infrastructure.Data.Models.Books
{
	[Comment("Current Book")]
	public class Book
	{
		[Key]
		[Comment("The current Book's Identifier")]
		public int Id { get; set; }

		[Required]
		[Comment("The International Standard Book Number")]
		public long ISBN { get; set; }

		[Required]
		[MaxLength(BookConstants.TitleMaxLength)]
		[Comment("The current Book's Title")]
		public string Title { get; set; } = string.Empty;

		[Required]
		[MaxLength(BookConstants.AuthorMaxLength)]
		[Comment("The current Book's Author")]
		public string Author { get; set; } = string.Empty;

		[Required]
		[MaxLength()]
		[Comment("The current Book's Description")]
		public string Description { get; set; } = string.Empty;

		[Required]
		[Comment("The current Book's Price")]
		//Add Range
		public decimal Price { get; set; }

		[Required]
		[Comment("The published year of the current Book")]
		//Add Range
		public int PublishedYear { get; set; }

		[Required]
		[Comment("Genre Identifier")]
		public int GenreId { get; set; }

		[ForeignKey(nameof(GenreId))]
		[Comment("The genre of the current Book")]
		public Genre Genre { get; set; } = null!;

		[Required]
		[MaxLength(BookConstants.ImageUrlMaxLegnth)]
		[Comment("The current Book's cover image url")]
		public string ImageUrl { get; set; } = string.Empty;

		[Required]
		[MaxLength(BookConstants.LanguageMaxLength)]
		[Comment("The current Book language")]
		public string Language { get; set; } = string.Empty;

		[Required]
		//Add Range
		[Comment("The currrent Book weight")]
		public double Weight { get; set; }

		public bool IsDeleted { get; set; } = false;

        [Required]
		//Add Range
		[Comment("The current Book's pages count")]
		public int Pages { get; set; }

		[Comment("Current Book's comments")]
		public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
	}
}
