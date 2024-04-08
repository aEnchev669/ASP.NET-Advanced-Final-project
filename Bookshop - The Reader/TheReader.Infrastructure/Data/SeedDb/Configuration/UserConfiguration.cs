using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheReader.Infrastructure.Data.Models.Account;

namespace TheReader.Infrastructure.Data.SeedDb.Configuration
{
	internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			var data = new SeedData();

			builder.HasData(new ApplicationUser[] {data.AdminUser, data.GuestUser});

		}
	}
}
