using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Interface;
using WebTestApI.InfrastructureLayer.Data;
using WebTestApI.InfrastructureLayer.Service;

namespace WebTestApI.InfrastructureLayer.DependencyInjection
{
    public static class DependencyInjection
    {
            public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("Defaultttt")));

                services.AddScoped<IUserRepository, UserRepository>();
                // بقیه‌ی سرویس‌هات...

                return services;
            }
        }
}
