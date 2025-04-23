using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MyDotNetApp.Infrastructure.Data.DbContexts
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddAppDbContexts(this IServiceCollection services, IConfiguration config)
        {
            var connStr = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connStr));

            services.AddScoped<IDapperDbContext, DapperDbContext>();

            return services;
        }
    }
}
