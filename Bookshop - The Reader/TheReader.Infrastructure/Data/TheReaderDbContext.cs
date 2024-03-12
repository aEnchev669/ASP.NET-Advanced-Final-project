using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TheReader.Infrastructure.Data.Models;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;
using TheReader.Infrastructure.Data.Models.Carts;
using TheReader.Infrastructure.Data.Models.Orders;
using TheReader.Infrastructure.Data.Models.Review;

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
			builder.Entity<BookCart>()
				.HasKey(bc => new { bc.BookId, bc.CartId });

			builder.Entity<UserProduct>()
				.HasKey(up => new { up.ApplicationUserId, up.BookId });

			builder
				.Entity<Book>()
				.HasMany(b => b.Comments)
				.WithOne(b => b.Book)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Book>()
				.Property(b => b.Price)
				.HasPrecision(18, 2);

			builder.Entity<Order>()
				.Property(o => o.TotalPrice)
				.HasPrecision(18, 2);

			builder.Entity<Book>()
				.Property(b => b.Weight)
				.HasPrecision(18, 2);

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