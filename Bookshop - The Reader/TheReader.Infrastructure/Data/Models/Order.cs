using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;
using static TheReader.Infrastructure.Constants.DataConstants;

namespace TheReader.Infrastructure.Data.Models
{
	[Comment("Order")]
	public class Order
	{
		[Key]
		[Comment("Current Order Identifier")]
		public int Id { get; set; }

		[Required]
		[MaxLength(OrderConstants.FirstNameMaxLength)]
		[Comment("First ame of the creator of the current order")]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[MaxLength(OrderConstants.LastNameMaxLength)]
		[Comment("Last name of the creator of the current order")]
		public string LastName { get; set; } = string.Empty;

		[Required]
		[MaxLength(OrderConstants.EmailMaxLength)]
		[Comment("Email of the creator of the current order")]
		public string Email { get; set; } = string.Empty;

		[Required]
		[MaxLength(OrderConstants.PhoneMaxLength)]
		[Comment("Phone number of the creator of the current order")]
		public string Phone { get; set; } = string.Empty;

		[Required]
		[MaxLength(OrderConstants.CityMaxLength)]
		[Comment("City of the creator of the current order")]
		public string City { get; set; } = string.Empty;

		[Required]
		[MaxLength(OrderConstants.PostalCodeMaxLength)]
		[Comment("PostalCode of the creator of the current order")]
		public string PostalCode { get; set; } = string.Empty;

		[Required]
		[MaxLength(OrderConstants.StreetMaxLength)]
		[Comment("Street of the creator of the current order")]
		public string Street { get; set; } = string.Empty;

		[Required]
		[Comment("Creation date of the current order")]
		public DateTime CreatedOn { get; set; } = DateTime.Now;

		[Required]
		[Comment("The total of the current order")]
		public decimal TotalPrice { get; set; }

		[Required]
		[Comment("The creator of the current order")]
		public ApplicationUser User { get; set; } = null!;

		[Required]
		[Comment("All items in the current order")]
		public ICollection<Book> OrderItems { get; set; } = new HashSet<Book>();
	}
}
