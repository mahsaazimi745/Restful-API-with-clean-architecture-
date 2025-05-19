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

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var userId = await _userService.RegisterAsync(dto);
            return Ok(new { UserId = userId });
        }
    }
}
