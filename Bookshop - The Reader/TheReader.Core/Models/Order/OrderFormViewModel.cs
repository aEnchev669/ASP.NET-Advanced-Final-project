using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants.OrderConstants;
using static TheReader.Infrastructure.Constants.ErrorMessages.OrderErrorMessages;

namespace TheReader.Core.Models.Order
{
	public class OrderFormViewModel
	{
		public int? Id { get; set; }

		[Required]
		[StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = InvalidFirstName)]
		[Display(Name = "First Name")]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = InvalidLastName)]
		[Display(Name = "Last Name")]
		public string LastName { get; set; } = string.Empty;

		[Required]
		[StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength, ErrorMessage = InvalidPhoneNumber)]
		public string Phone { get; set; } = string.Empty;

		[Required]
		[StringLength(CityMaxLength, MinimumLength = CityMinLength, ErrorMessage = InvalidCity)]
		public string City { get; set; } = string.Empty;

		[Required]
		[StringLength(PostalCodeMaxLength, MinimumLength = PostalCodeMinLength, ErrorMessage = InvalidPostCode)]
		public string PostalCode { get; set; } = string.Empty;

		[Required]
		public decimal TotalPrice { get; set; }

		public string UserId { get; set; } = string.Empty;

		public int CartId { get; set; }
	}
}
