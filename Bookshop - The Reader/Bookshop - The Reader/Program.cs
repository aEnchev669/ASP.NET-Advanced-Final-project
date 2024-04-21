using Bookshop___The_Reader.Extensions;
using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TheReaderDbContextConnection") ?? throw new InvalidOperationException("Connection string 'TheReaderDbContextConnection' not found.");

builder.Services.AddDbContext<TheReaderDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews();



builder.Services.AddApplicationServices();

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/User/Login";
    cfg.LogoutPath = "/User/Logout";
    cfg.AccessDeniedPath = "/Home/Error?statusCode=401";
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error?statusCode=500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Admin",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");


});

app.MapRazorPages();

await app.CreateAdminRoleAsync();
await app.CreateUserRoleAsync();

await app.RunAsync();