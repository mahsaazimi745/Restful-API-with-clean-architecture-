using AutoMapper;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Entity;
using WebTestApI.CoreLayer.Interface;

namespace WebTestApI.InfrastructureLayer.Security
{
    public class BCryptPasswordHasher:IPasswordHasher
    {
        public string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("رمز عبور نمی‌تواند خالی باشد.");

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hashedPassword))
                throw new ArgumentException("رمز عبور یا مقدار هش نمی‌تواند خالی باشد.");

            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}


   
