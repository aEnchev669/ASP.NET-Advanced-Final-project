using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants;
namespace TheReader.Core.Models.Cart
{
	public class CartFormViewModel
	{
		public CartFormViewModel()
		{
			TotalPrice = 0;
		}
		public int Id { get; set; } 

		[Range(typeof(decimal), CartConstants.TotalPriceMinValue, CartConstants.TotalPriceMaxValue)]
		public decimal TotalPrice { get; set; }

		public IEnumerable<CartBookViewModel> Books { get; set; } = new HashSet<CartBookViewModel>();
	}
}
