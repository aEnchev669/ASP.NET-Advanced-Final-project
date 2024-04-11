using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants;
using static TheReader.Infrastructure.Constants.ErrorMessages;

namespace TheReader.Core.Models.Book
{
    public class BookFormViewModel
    {


        [Required]
        public long ISBN { get; set; }

        [Required]
        [StringLength(BookConstants.TitleMaxLength, MinimumLength = BookConstants.TitleMinLength, ErrorMessage = BookErrorMessages.InvalidTitle)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(BookConstants.AuthorMaxLength, MinimumLength = BookConstants.AuthorMinLength, ErrorMessage = BookErrorMessages.InvalidAuthorName)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(BookConstants.DescriptionMaxLength, MinimumLength = BookConstants.DescriptionMinLength, ErrorMessage = BookErrorMessages.InvalidDescription)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), BookConstants.PriceMinValue, BookConstants.PriceMaxValue, ErrorMessage = BookErrorMessages.InvalidPrice)]
        public decimal Price { get; set; }

        [Required]
        [Range(BookConstants.PublishedYearMinRange, BookConstants.PublishedYearMaxRange, ErrorMessage = BookErrorMessages.InvalidPublishedYear)]
        public int PublishedYear { get; set; }


        public int GenreId { get; set; }



        [Required]
        [StringLength(BookConstants.ImageUrlMaxLegnth, MinimumLength = BookConstants.ImageUrlMinLegnth, ErrorMessage = GeneralError.GeneralRequiredErrorMessage)]

        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [StringLength(BookConstants.LanguageMaxLength, MinimumLength = BookConstants.LanguageMinLength, ErrorMessage = BookErrorMessages.InvalidLanguage)]
        public string Language { get; set; } = string.Empty;

        [Required]
        [Range(typeof(double), BookConstants.WeightMinLength, BookConstants.WeightMaxLength, ErrorMessage = BookErrorMessages.InvalidWeight)]
        public double Weight { get; set; }

        [Required]
        [Range( BookConstants.PagesMinLength, BookConstants.PagesMaxLength, ErrorMessage = BookErrorMessages.InvalidPages)]
        public int Pages { get; set; }
    }
}
