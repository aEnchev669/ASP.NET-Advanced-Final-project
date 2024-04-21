using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Carts;
using static TheReader.Infrastructure.Constants.DataConstants;

namespace TheReader.Infrastructure.Data.Models.Orders
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
		[Comment("Creation date of the current order")]
		public DateTime CreatedOn { get; set; } = DateTime.Now;

		[Required]
		[Comment("The total of the current order")]
		public decimal TotalPrice { get; set; }

		[ForeignKey(nameof(User))]
		public string UserId { get; set; } = null!;

		[Required]
		[Comment("The creator of the current order")]
		public ApplicationUser User { get; set; } = null!;

		[Required]
		public Cart Cart { get; set; } = null!;

		[ForeignKey(nameof(Cart))]
		public int CartId { get; set; }
	}
}
