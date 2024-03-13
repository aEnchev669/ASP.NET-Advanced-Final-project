using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TheReader.Infrastructure.Data.Models.Account;

namespace TheReader.Infrastructure.Extensions
{
	public static class WebApplicationBuiledExtension
	{
		public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
		{
			Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
			if (serviceAssembly == null)
			{
				throw new InvalidOperationException("Invalid service type provided!");
			}

			Type[] sType = serviceAssembly
				.GetTypes()
				.Where(st => st.Name.EndsWith("Service") && !st.IsInterface)
				.ToArray();

			foreach (Type st in sType)
			{
				var interfaceType = st
					.GetInterface($"I{st.Name}");

				if (interfaceType == null)
				{
					throw new InvalidOperationException($"No interface is provided for the service with name {st.Name}");
				}

				services.AddScoped(interfaceType, st);
			}

		}

		//public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
		//{
		//	using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

		//	var roleManager = scopedServices.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

		//	var roles = new[] { "Admin", "User" };

		//	Task.Run(async () =>
		//	{
		//		foreach (var role in roles)
		//		{
		//			if (!await roleManager.RoleExistsAsync(role))
		//			{
		//				await roleManager.CreateAsync(new IdentityRole<Guid>(role));
		//			}
		//		}
		//	})
		//	.GetAwaiter()
		//	.GetResult();

		//	return app;
		//}

		//public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app)
		//{
		//	using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

		//	var userManager = scopedServices.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

		//	string username = AdministratorUsername;
		//	string email = AdministratorEmail;
		//	string password = AdministratorPassword;
		//	string role = AdministratorRole;

		//	Task.Run(async () =>
		//	{
		//		if (await userManager.FindByEmailAsync(email) == null)
		//		{
		//			var user = new ApplicationUser();

		//			await userManager.SetUserNameAsync(user, username);
		//			await userManager.SetEmailAsync(user, email);

		//			await userManager.CreateAsync(user, password);

		//			await userManager.AddToRoleAsync(user, role);
		//		}
		//	})
		//	.GetAwaiter()
		//	.GetResult();

		//	return app;
		//}
	}
}
