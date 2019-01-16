using Microsoft.Extensions.DependencyInjection;
using Services.Auth;
using Services.Recipes;
using Services.Users;

namespace Services
{
	public static class ServiceConfiguration
    {
		public static void ConfigureAppServices(this IServiceCollection services)
		{
			services.AddScoped<IAuthenticationService, AuthenticationService>();
			services.AddScoped<IClaimsService, ClaimsService>();

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IRecipeService, RecipeService>();
		}
	}
}
