using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTestApI.ApplicationLayer.Interface;

namespace WebTestApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController : ControllerBase
    {
        private readonly IApprovalService _approvalService;

        public ApprovalController(IApprovalService approvalService)
        {
            _approvalService = approvalService;
        }

        // مربی کاربر رو تأیید می‌کنه
        [HttpPut("approve/{userId}")]
            public async Task<IActionResult> ApproveUser(Guid userId)
            {
            await _approvalService.ApproveUserAsync(userId);
                return Ok("کاربر تأیید شد.");
            }

            // مربی کاربر رو رد می‌کنه
            [HttpPut("reject/{userId}")]
            public async Task<IActionResult> RejectUser(Guid userId)
            {
            await _approvalService.RejectUserAsync(userId);
                return Ok("کاربر رد شد.");
            }
        }
}
