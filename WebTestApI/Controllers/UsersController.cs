using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTestApI.ApplicationLayer.Dtos;
using WebTestApI.ApplicationLayer.Interface;

namespace WebTestApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // 🔹 ثبت‌نام دانش‌آموز
        [HttpPost("register-student")]
        public async Task<IActionResult> RegisterStudent(StudentRegisterDto dto)
        {
            try
            {
                await _userService.RegisterStudentAsync(dto);
                return Ok("ثبت‌نام دانش‌آموز انجام شد و منتظر تأیید مربی است.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 🔹 ثبت‌نام مربی
        [HttpPost("register-coach")]
        public async Task<IActionResult> RegisterCoach(CoachRegisterDto dto)
        {
            try
            {
                await _userService.RegisterCoachAsync(dto);
                return Ok("ثبت‌نام مربی انجام شد و منتظر تأیید ادمین است.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

