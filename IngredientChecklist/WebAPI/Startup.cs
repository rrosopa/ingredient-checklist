using Core.Models;
using Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Services;

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
				options => options
					.UseLazyLoadingProxies()
					.UseSqlServer(settings.ConnectionString)			
			);
			services.AddScoped<IAppDbContext>(x => x.GetService<AppDbContext>());

			ServiceConfiguration.ConfigureAppServices(services);
			services.AddHttpContextAccessor();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
