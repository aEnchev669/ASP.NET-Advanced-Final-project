using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TheReader.Infrastructure.Data.Models.Account;
using static TheReader.Infrastructure.Constants.ApplicaitonConstants;

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



		//public static async Task SeedAdministratorAsync(this IApplicationBuilder app)
		//{
		//	using var scopedServices = app.ApplicationServices.CreateScope();

		//	var userManager = scopedServices.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
		//	var roleManager = scopedServices.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

		//	string email = "Admin@gmail.com";


		//	if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
		//	{
		//		var role = new IdentityRole(AdminRole);
		//		await roleManager.CreateAsync(role);

		//		var admin = await userManager.FindByEmailAsync(email);

		//		if (admin != null)
		//		{
		//			await userManager.AddToRoleAsync(admin, AdminRole);
		//		}
		//	}
		//}
	}
}
