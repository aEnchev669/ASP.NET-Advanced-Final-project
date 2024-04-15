using TheReader.Core.Models.Cart;

namespace TheReader.Core.Contracts.Cart
{
    public interface ICartService
    {
        Task<CartFormViewModel?> GetCurrCartByUserIdAsync(string userId);

        Task<CartFormViewModel> GetCartByOrderIdAsync(int orderId);

        Task CreateCartAsync(string userId);

        Task AddBookToCartAsync(int bookId, int cartId, string userId);

        Task RemoveBookFromCartAsync(int bookId, int cartId);

        Task IncreaseBookCountAsync(int bookId, int cartId);

        Task DecreaseBookCountAsync(int bookId, int cartId);
    }
}
