using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTestApI.CoreLayer.Entity;
using WebTestApI.CoreLayer.ValueObjects;
using WebTestApI.CoreLayer.Interface;
using WebTestApI.InfrastructureLayer.Data;
using System;

namespace WebTestApI.InfrastructureLayer.Service
{
    public class AdminInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public AdminInitializer(ApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task InitializeAsync()
        {
            var adminEmail = "admin@example.com";

            var adminUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.Value == adminEmail);

            if (adminUser != null)
                return; // ادمین وجود دارد

            // ساخت پسورد هش شده با متد Create
            var hashedPassword = Password.Create("Admin@2025", _passwordHasher);

            /*  var admin = new Admin(
                  firstName: "Admin",
                  lastName: "Admini",
                  fatherName: "N/A",
                  age: 30,
                  nationalCode:  NationalCode.Create("1234567890"),
                  phoneNumber:  PhoneNumber.Create("09120000000"),
                  email:  Email.Create(adminEmail),
                  password: hashedPassword // پسورد هش‌شده را می‌دهیم
              );*/
            var admin = Admin.Create(
           firstName: "Admin",
              lastName: "Admini",
            fatherName: "ali",
              age: 30,
               nationalCode: NationalCode.Create("1090267703"),
                phoneNumber: PhoneNumber.Create("09138310671"),
                  email: Email.Create(adminEmail),
              plainTextPassword: "Admin@2025",
            passwordHasher: _passwordHasher);

            _context.Users.Add(admin);
            await _context.SaveChangesAsync();
        }
    }
}
