using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookshopTheReader.Infrastructure.Data
{
	public class TheReaderDbContext : IdentityDbContext
	{
		public TheReaderDbContext(DbContextOptions<TheReaderDbContext> options)
			: base(options)
		{
		}
	}
}