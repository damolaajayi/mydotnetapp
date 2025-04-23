using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyDotNetApp.Application.Interfaces.Repositories;
using MyDotNetApp.Application.Interfaces.Services;
using MyDotNetApp.Application.Services;
using MyDotNetApp.Infrastructure.Data.DbContexts;
using MyDotNetApp.Infrastructure.Repositories;
using MyDotNetApp.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordService, PasswordService>();

            return services;
        }
    }
}
