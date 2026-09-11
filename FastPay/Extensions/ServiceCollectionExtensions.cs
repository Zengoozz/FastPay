using FastPay.Data;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register your FastPay services here
            // Example: services.AddScoped<IMyService, MyService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection repos)
        {
            return repos;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<CustomConfigurations>(configuration.GetSection("CustomConfigurations"));
            return services;
        }

        public static IServiceCollection AddWebApi(this IServiceCollection apis)
        {
            return apis;
        }

        public static IServiceCollection AddAll(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();
            services.AddRepositories();
            services.AddDatabase(configuration);
            services.AddConfigurations(configuration);
            services.AddWebApi();

            return services;   
        }
    }
}
