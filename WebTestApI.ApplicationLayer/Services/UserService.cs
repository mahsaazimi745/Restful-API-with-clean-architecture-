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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> RegisterAsync(UserRegisterDto dto)
        {


            var user = new User(
      dto.FirstName,
      dto.LastName,
      dto.FatherName,
      dto.Age,
      NationalCode.Create(dto.NationalCode),
      PhoneNumber.Create(dto.PhoneNumber),
      Email.Create(dto.Email),
      new Password(dto.Password)



  );

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
