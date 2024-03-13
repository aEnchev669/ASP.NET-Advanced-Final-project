using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TheReader.Infrastructure.Data.Models;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;
using TheReader.Infrastructure.Data.Models.Carts;
using TheReader.Infrastructure.Data.Models.Orders;
using TheReader.Infrastructure.Data.Models.Review;
using TheReader.Infrastructure.Data.SeedDb.Configuration;

namespace BookshopTheReader.Infrastructure.Data
{
	public class TheReaderDbContext : IdentityDbContext
	{
		public TheReaderDbContext(DbContextOptions<TheReaderDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new UserProductConfiguration());
			builder.ApplyConfiguration(new BookConfiguration());
			builder.ApplyConfiguration(new BookCartConfiguration());
			builder.ApplyConfiguration(new GenreConfiguration());
			builder.ApplyConfiguration(new OrderConfiguration());

			base.OnModelCreating(builder);
		}

		public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
		public DbSet<Book> Books { get; set; } = null!;
		public DbSet<Genre> Genres { get; set; } = null!;
		public DbSet<Cart> Carts { get; set; } = null!;
		public DbSet<Comment> Comments { get; set; } = null!;
		public DbSet<Order> Orders { get; set; } = null!;
		public DbSet<BookCart> BooksCarts { get; set; } = null!;
		public DbSet<UserProduct> UsersProducts { get; set; } = null!;
	}
}