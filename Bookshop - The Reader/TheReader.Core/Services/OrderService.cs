using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Order;
using TheReader.Core.Models.Cart;
using TheReader.Core.Models.Order;
using TheReader.Infrastructure.Data.Models.Orders;

namespace TheReader.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly TheReaderDbContext dbContext;
        public OrderService(TheReaderDbContext _context)
        {
            dbContext = _context;
        }
        public async Task CreateOrderAsync(OrderFormViewModel orderModel)
        {
            int cartId = orderModel.CartId;
            string userId = orderModel.UserId;

            Order order = new Order()
            {
                FirstName = orderModel.FirstName,
                LastName = orderModel.LastName,
                Phone = orderModel.Phone,
                City = orderModel.City,
                PostalCode = orderModel.PostalCode,
                CartId = cartId,
                UserId = userId,
                TotalPrice = orderModel.TotalPrice
            };

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderHistoryViewModel>> GetAllOrdersByUserIdAsync(string userId)
        {
            var orders = await dbContext
                .Orders
                .Where(o => o.UserId.ToString() == userId)
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderHistoryViewModel()
                {
                    Id = o.Id.ToString(),
                    CreatedOn = o.CreatedOn,
                    TotalPrice = o.TotalPrice,
                    CartItems = o.Cart.BooksCarts.Select(ci => new CartBookViewModel()
                    {
                        BookId = ci.BookId,
                        Title = ci.Book.Title,
                        Image = ci.Book.ImageUrl,
                        Price = ci.Book.Price,
                        Quantity = ci.Quantity,
                        TotalPrice = ci.Quantity * ci.Book.Price
                    })
                    .ToArray()
                })
                .ToListAsync();

            return orders;
        }

        public async Task<OrderFormViewModel?> GetLastOrderListByUserIdAsync(string userId)
        {
            var orderList = await dbContext
               .Orders
               .Where(o => o.UserId.ToString() == userId)
               .Select(o => new OrderFormViewModel()
               {
                   Id = o.Id,
                   FirstName = o.FirstName!,
                   LastName = o.LastName!,
                   Phone = o.Phone,
                   City = o.City!,
                   PostalCode = o.PostalCode!,
                   CartId = o.CartId,
                   UserId = o.UserId.ToString(),
                   TotalPrice = o.TotalPrice
               })
               .ToListAsync();

            var lastOrder = orderList.LastOrDefault();

            return (lastOrder);
        }

        public async Task<OrderFormViewModel?> GetOrderDetailsAsync(int cartId)
        {
            var order = await dbContext
              .Orders
              .Where(o => o.CartId == cartId)
              .Select(o => new OrderFormViewModel()
              {
                  Id = o.Id,
                  FirstName = o.FirstName!,
                  LastName = o.LastName!,
                  Phone = o.Phone,
                  City = o.City!,
                  PostalCode = o.PostalCode!,
                  CartId = o.CartId,
                  UserId = o.UserId.ToString(),
                  TotalPrice = o.TotalPrice
              })
              .FirstOrDefaultAsync();

            return order;
        }
    }
}
