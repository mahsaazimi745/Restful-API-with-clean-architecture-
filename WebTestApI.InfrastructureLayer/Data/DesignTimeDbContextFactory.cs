using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestApI.InfrastructureLayer.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // اتصال به دیتابیس خودت رو اینجا تنظیم کن
            optionsBuilder.UseSqlServer("Server=DESKTOP-GVN4LCQ;Database=Test.blog;User Id=sa;Password=0910373mahsa;Encrypt=True;TrustServerCertificate=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
