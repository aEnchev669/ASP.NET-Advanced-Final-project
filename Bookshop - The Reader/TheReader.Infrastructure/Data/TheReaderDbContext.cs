﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheReader.Infrastructure.Data.Models;
using TheReader.Infrastructure.Data.Models.Account;
using TheReader.Infrastructure.Data.Models.Books;
using TheReader.Infrastructure.Data.Models.Carts;
using TheReader.Infrastructure.Data.Models.Events;
using TheReader.Infrastructure.Data.Models.Orders;
using TheReader.Infrastructure.Data.SeedDb.Configuration;

namespace BookshopTheReader.Infrastructure.Data
{
    public class TheReaderDbContext : IdentityDbContext<ApplicationUser>
    {
        public TheReaderDbContext(DbContextOptions<TheReaderDbContext> options)
            : base(options)
        {
            if (!this.Database.IsRelational())
            {
                this.Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserProductConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new BookCartConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new EventCartConfiguration());
            builder.ApplyConfiguration(new EventParticipantConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());

			base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
		public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
		public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<BookCart> BooksCarts { get; set; } = null!;
        public DbSet<UserProduct> UsersProducts { get; set; } = null!;
        public DbSet<EventCart> EventsCarts { get; set; } = null!;
        public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;
    }
}