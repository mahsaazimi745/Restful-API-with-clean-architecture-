using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.ApplicationLayer.Dtos;
using WebTestApI.ApplicationLayer.Interface;
using WebTestApI.CoreLayer.Entity;
using WebTestApI.CoreLayer.Interface;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterAsync(UserRegisterDto dto)
        {
            // بررسی تکراری نبودن شماره یا ایمیل
            var existingByPhone = await _userRepository.GetByPhoneNumberAsync(dto.PhoneNumber);
            if (existingByPhone != null)
                throw new Exception("شماره تلفن قبلاً ثبت شده است.");

            var existingByEmail = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingByEmail != null)
                throw new Exception("ایمیل قبلاً ثبت شده است.");

            // ساخت پسورد هش‌شده
            /* var password = Password.Create(dto.Password, _passwordHasher);*/
            
            var password = Password.Create(dto.Password, _passwordHasher);

            // ساخت کاربر جدید
            var user = new User(
                firstName: dto.FirstName,
                lastName: dto.LastName,
                fatherName: dto.FatherName,
                age: dto.Age,
                nationalCode: dto.NationalCode,
                phoneNumber: dto.PhoneNumber,
                email: dto.Email,
                password: password
            );

            // اضافه کردن کاربر به دیتابیس
            await _userRepository.AddAsync(user);
            return await _userRepository.SaveChangesAsync();
        }
    }
}


