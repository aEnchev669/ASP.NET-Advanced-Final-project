using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants;
namespace TheReader.Core.Models.Cart
{
	public class CartBookViewModel
	{
		public CartBookViewModel()
		{
			TotalPrice = Price * Quantity;
			Quantity = 0;
		}
		public int BookId { get; set; }

		public string Title { get; set; } = null!;

		public string? Image { get; set; }

		public decimal Price { get; set; }

		[Range(typeof(int), CartConstants.QuantityMinValue, CartConstants.QuantityMaxValue)]
		public int Quantity { get; set; }

		[Range(typeof(decimal), CartConstants.TotalPriceMinValue, CartConstants.TotalPriceMaxValue)]
		public decimal TotalPrice { get; set; }
	}
}
