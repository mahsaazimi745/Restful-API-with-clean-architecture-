using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Entity;
using WebTestApI.CoreLayer.Interface;
using WebTestApI.CoreLayer.ValueObjects;
using WebTestApI.InfrastructureLayer.Data;

namespace WebTestApI.InfrastructureLayer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<User?> GetByEmailAsync(Email email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email.Value == email.Value);
        }

        /*public async Task<User?> GetByPhoneNumberAsync(PhoneNumber phoneNumber)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }*/
        /* public async Task<User?> GetByPhoneNumberAsync(PhoneNumber phoneNumber)
         {
             return await _context.Users
                 .AnyAsync(u => u.PhoneNumber.Value == phoneNumber.Value);
         }*/
        public async Task<User?> GetByPhoneNumberAsync(PhoneNumber phoneNumber)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber.Value == phoneNumber.Value);
        }


        /*  public async Task<User?> GetByNationalCodeAsync(NationalCode nationalCode)
          {
              return await _context.Users
                  .FirstOrDefaultAsync(u => u.NationalCode == nationalCode);
          }*/
        public async Task<User?> GetByNationalCodeAsync(NationalCode national)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.NationalCode.Value == national.Value);
        }

        public async Task<bool> IsEmailExistsAsync(Email email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email.Value == email.Value);
        }

        //public async Task<bool> IsPhoneNumberExistsAsync(PhoneNumber phoneNumber)
        //{
        //    return await _context.Users
        //        .AnyAsync(u => u.PhoneNumber == phoneNumber);
        //}
        public async Task<bool> IsPhoneNumberExistsAsync(PhoneNumber phoneNumber)
        {
            return await _context.Users
                .AnyAsync(u => u.PhoneNumber.Value == phoneNumber.Value);
        }


        public async Task<bool> IsNationalCodeExistsAsync(NationalCode nationalCode)
        {
            return await _context.Users
                .AnyAsync(u => u.NationalCode.Value == nationalCode.Value);
        }






        public async Task<User?> GetByCredentialsAsync(Email email, Password passwordHash)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);
        }
    }
}





