using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants.BookConstants;
using static TheReader.Infrastructure.Constants.ErrorMessages.BookErrorMessages;

namespace TheReader.Core.Models.Book
{
	public class BookServiceModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = InvalidTitle)]
		[Display(Name = "Title")]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength, ErrorMessage = InvalidAuthorName)]
		[Display(Name = "Author")]
		public string Author { get; set; } = null!;

		[Required]
		[StringLength(ImageUrlMaxLegnth, MinimumLength = ImageUrlMinLegnth, ErrorMessage = InvalidImageURL)]
		[Display(Name = "Image URL")]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = InvalidPrice,
			ConvertValueInInvariantCulture = true)]

		[Display(Name = "Price")]
		public decimal Price { get; set; }
	}
}
