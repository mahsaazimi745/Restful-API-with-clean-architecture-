
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Entity;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.CoreLayer.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        /* Task<User> GetByEmailAsync(string email);
         Task<User> GetByPhoneNumberAsync(string phoneNumber);*/
        // گرفتن کاربر بر اساس ایمیل
        /* Task<User?> GetByEmailAsync(string email);

         // گرفتن کاربر بر اساس شماره موبایل
         Task<User?> GetByPhoneNumberAsync(string phoneNumber);

         // گرفتن کاربر بر اساس کدملی
         Task<User?> GetByNationalCodeAsync(string nationalCode);

         // بررسی وجود ایمیل تکراری (مثلاً در هنگام ثبت‌نام)
         Task<bool> IsEmailExistsAsync(string email);

         // بررسی وجود شماره تلفن تکراری
         Task<bool> IsPhoneNumberExistsAsync(string phoneNumber);

         // بررسی وجود کد ملی
         Task<bool> IsNationalCodeExistsAsync(string nationalCode);

         // گرفتن کاربر با ایمیل و پسورد (برای ورود)
         Task<User?> GetByCredentialsAsync(string email, string passwordHash);*/
        // گرفتن کاربر بر اساس ایمیل
        Task<User?> GetByEmailAsync(Email email);

        // گرفتن کاربر بر اساس شماره موبایل
        Task<User?> GetByPhoneNumberAsync(PhoneNumber phoneNumber);

        // گرفتن کاربر بر اساس کدملی
        Task<User?> GetByNationalCodeAsync(NationalCode nationalCode);

        // بررسی وجود ایمیل تکراری
        Task<bool> IsEmailExistsAsync(Email email);

        // بررسی وجود شماره تلفن تکراری
        Task<bool> IsPhoneNumberExistsAsync(PhoneNumber phoneNumber);

        // بررسی وجود کد ملی
        Task<bool> IsNationalCodeExistsAsync(NationalCode nationalCode);

        // گرفتن کاربر با ایمیل و پسورد (برای لاگین)
        Task<User?> GetByCredentialsAsync(Email email, Password password);

    }
}
