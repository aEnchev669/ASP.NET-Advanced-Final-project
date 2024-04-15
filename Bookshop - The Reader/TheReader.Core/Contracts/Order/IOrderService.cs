using TheReader.Core.Models.Order;

namespace TheReader.Core.Contracts.Order
{
    public interface IOrderService
    {
        Task<OrderFormViewModel?> GetOrderDetailsAsync(int cartId);

        Task<IEnumerable<OrderHistoryViewModel>> GetAllOrdersByUserIdAsync(string userId);

        Task CreateOrderAsync(OrderFormViewModel orderModel);

        Task<OrderFormViewModel?> GetLastOrderListByUserIdAsync(string userId);
    }
}
