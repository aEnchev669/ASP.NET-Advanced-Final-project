
using BookshopTheReader.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Contracts.Cart;
using TheReader.Core.Contracts.Event;
using TheReader.Core.Contracts.Genre;
using TheReader.Core.Contracts.Order;
using TheReader.Core.Contracts.User;
using TheReader.Core.Services;
using TheReader.Infrastructure.Data.Models.Account;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();


			return services;
        }
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<TheReaderDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TheReaderDbContext>();


            return services;
        }
    }
}
