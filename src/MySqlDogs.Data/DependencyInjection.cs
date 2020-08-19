using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlDogs.Application.Common.Interfaces;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace MySqlDogs.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPomeleoMySql(this IServiceCollection services, IConfiguration configuration)
        {
            // other service configurations go here

            services.AddDbContextPool<DogDbContext>(
                    options => MySqlDbContextOptionsExtensions.UseMySql(options,
                       configuration.GetConnectionString("DefaultConnection"), 
                       
                    mySqlOptions => mySqlOptions
                        // replace with your Server Version and Type
                        .ServerVersion(new Version(8, 0, 18), ServerType.MySql)
                     
                       ))
                ;

            services.AddScoped<IDogDbContext>(provider => provider.GetService<DogDbContext>());

            return services;
        }
    }
}