using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants;
using static TheReader.Infrastructure.Constants.ErrorMessages;
namespace TheReader.Core.Models.Genre
{
	public class NewGenreViewModel
	{
        [Required]
        [StringLength(GenreConstants.NameMaxLength, MinimumLength = GenreConstants.NameMinLength, ErrorMessage = GeneralError.GeneralRequiredErrorMessage)]
        public string Name { get; set; } = null!;
    }
}
