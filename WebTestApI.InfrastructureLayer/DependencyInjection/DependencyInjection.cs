using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.ApplicationLayer.Interface;
using WebTestApI.ApplicationLayer.Services;
using WebTestApI.CoreLayer.Interface;
using WebTestApI.InfrastructureLayer.Data;
using WebTestApI.InfrastructureLayer.Repository;
using WebTestApI.InfrastructureLayer.Security;


namespace WebTestApI.InfrastructureLayer.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Defaultttt")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            // بقیه‌ی سرویس‌هات...

            return services;
        }


    }
}
