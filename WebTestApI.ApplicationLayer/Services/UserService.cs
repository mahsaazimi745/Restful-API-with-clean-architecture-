using System;
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
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher,
            IUserRoleRepository userRoleRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> RegisterStudentAsync(StudentRegisterDto dto)
        {
            var password = Password.Create(dto.Password, _passwordHasher);

            var student = new Student(
                firstName: dto.FirstName,
                lastName: dto.LastName,
                fatherName: dto.FatherName,
                age: dto.Age,
                nationalCode: dto.NationalCode,
                phoneNumber: dto.PhoneNumber,
                email: dto.Email,
                password: password,
               
                parentsPhoneNumber: dto.ParentsPhoneNumber
            );

            await _userRepository.AddAsync(student);

            var studentRole = await _roleRepository.GetByNameAsync("Student");
            await _userRoleRepository.AddAsync(new UserRole(student.Id, studentRole.Id));

            return await _userRepository.SaveChangesAsync();
        }

        public async Task<bool> RegisterCoachAsync(CoachRegisterDto dto)
        {
            var password = Password.Create(dto.Password, _passwordHasher);

            var coach = new Coach(
                firstName: dto.FirstName,
                lastName: dto.LastName,
                fatherName: dto.FatherName,
                age: dto.Age,
                nationalCode: dto.NationalCode,
                phoneNumber: dto.PhoneNumber,
                email: dto.Email,
                password: password,
                expertise: dto.Expertise
            );

            await _userRepository.AddAsync(coach);

            var coachRole = await _roleRepository.GetByNameAsync("Coach");
            await _userRoleRepository.AddAsync(new UserRole(coach.Id, coachRole.Id));

            return await _userRepository.SaveChangesAsync();
        }

        public async Task<bool> ApproveUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("کاربر یافت نشد.");

            // فرض: تأیید دستی (در اینجا فقط ذخیره می‌شه، ولی می‌تونی یک فلگ IsApproved هم به مدل اضافه کنی)
            // user.Approve();   ← در صورت وجود متد یا فیلد مربوط

            return await _userRepository.SaveChangesAsync();
        }
    }
}
