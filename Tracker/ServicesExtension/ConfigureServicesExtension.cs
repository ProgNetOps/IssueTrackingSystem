using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Tracker.Entity;
using Tracker.Mappings;
using Tracker.Persistence;
using Tracker.Services.Implementations;
using Tracker.Services.Services;

namespace Tracker.ServicesExtension
{
	public static class ConfigureServicesExtension
	{
		/// <summary>
		/// Extension method where the services are added to declutter the program.cs file
		/// </summary>
		/// <param name="services"></param>
		public static IServiceCollection ConfigureServices(this IServiceCollection services, ConfigurationManager configuration)
		{
			// Add MVC services
			services.AddControllersWithViews(options =>
			{
				var policy = new AuthorizationPolicyBuilder().
				RequireAuthenticatedUser().Build();
				options.Filters.Add(new AuthorizeFilter(policy));
			});

			//Add DbContext Services 
			services.AddDbContextPool<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Add Identity Services
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				//configure password complexity rules 
				options.Password.RequiredLength = 8;
				options.Password.RequireDigit = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
			}).AddEntityFrameworkStores<AppDbContext>();

            //Add BTS Service
            services.AddScoped<IBaseStationService, BaseStationService>();

			//Add Client Service
			services.AddScoped<IClientService, ClientService>();

            //Add Circuit Service
            services.AddScoped<ICircuitService, CircuitService>();

            //Add DCNRouter Service
            services.AddScoped<IDCNRouterService, DCNRouterService>();

            //Add MPLSPoP Service
            services.AddScoped<IMPLSPoPService, MPLSPoPService>();

			//Add Employee Service
			services.AddScoped<IEmployeeService, EmployeeService>();

			//Add NetworkSwitch Service
			services.AddScoped<INetworkSwitchService, NetworkSwitchService>();

			//Add IPPoP Service
			services.AddScoped<IIPPoPService, IPPoPService>();

			//Automapper 
			services.AddAutoMapper(typeof(AutoMapperProfiles));

			return services;
		}
	}
}
