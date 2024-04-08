using BookshopTheReader.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

using TheReader.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Bookshop___The_Reader.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TheReaderDbContextConnection") ?? throw new InvalidOperationException("Connection string 'TheReaderDbContextConnection' not found.");

builder.Services.AddDbContext<TheReaderDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	//.AddEntityFrameworkStores<TheReaderOneDbContext>();

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews();



builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");

	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
	
app.MapRazorPages();

//await app.CreateAdminRoleAsync();

await app.RunAsync();