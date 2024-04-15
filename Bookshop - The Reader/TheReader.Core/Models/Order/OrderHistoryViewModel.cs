using System.ComponentModel.DataAnnotations;
using TheReader.Core.Models.Cart;

namespace TheReader.Core.Models.Order
{
	public class OrderHistoryViewModel
	{
        [Required]
        public string Id { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public decimal TotalPrice { get; set; }

        public IEnumerable<CartBookViewModel> CartItems { get; set; } = new HashSet<CartBookViewModel>();
    }
}
