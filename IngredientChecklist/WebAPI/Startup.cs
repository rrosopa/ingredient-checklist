using Core.Models;
using Data.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.Security.Claims;
using System.Text;

namespace WebAPI
{
	public class Startup
    {
		public IConfigurationRoot Configuration { get; set; }
	
		public Startup(IHostingEnvironment env)
        {
			var builder = new ConfigurationBuilder()
							.SetBasePath(env.ContentRootPath)
							.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddOptions();
			services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));

			var serviceProvider = services.BuildServiceProvider();
			var settingsOptions = serviceProvider.GetService<IOptions<AppConfig>>();
			var settings = settingsOptions?.Value ?? new AppConfig();
			
			// Database
			services.AddDbContext<AppDbContext>(
				options => options.UseSqlServer(settings.ConnectionString)			
			);
			services.AddScoped<IAppDbContext>(x => x.GetService<AppDbContext>());

			ConfigureAuthorizationSchemes(services, settings);
			ServiceConfiguration.ConfigureAppServices(services);
			services.AddHttpContextAccessor();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

		private void ConfigureAuthorizationSchemes(IServiceCollection services, AppConfig appConfig)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = appConfig.JWTIssuer,
						ValidAudience = appConfig.JWTIssuer,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appConfig.JWTKey))
					};
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

			app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
