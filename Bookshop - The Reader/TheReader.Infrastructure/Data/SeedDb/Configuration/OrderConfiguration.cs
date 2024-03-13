using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheReader.Infrastructure.Data.Models.Orders;

namespace TheReader.Infrastructure.Data.SeedDb.Configuration
{
	internal class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder
				.Property(o => o.TotalPrice)
				.HasPrecision(18, 2);
		}
	}
}
