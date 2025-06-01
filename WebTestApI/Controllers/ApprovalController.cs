using Microsoft.AspNetCore.Mvc;
using WebTestApI.ApplicationLayer.Interface;
using WebTestApI.CoreLayer.Enums;
using System;
using System.Threading.Tasks;

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

        // DTO برای دریافت coachId و studentLevel در بدنه درخواست
        public class ApproveStudentRequest
        {
            public Guid CoachId { get; set; }
            public StudentLevel Level { get; set; }
        }

        // مربی دانش‌آموز را تأیید می‌کند
        [HttpPut("approve/student/{studentId}")]
        public async Task<IActionResult> ApproveStudent(Guid studentId, [FromBody] ApproveStudentRequest request)
        {
            await _approvalService.ApproveStudentByCoachAsync(request.CoachId, studentId, request.Level);
            return Ok("دانش‌آموز تأیید شد.");
        }

        // ادمین مربی را تأیید می‌کند
        [HttpPut("approve/coach/{coachId}")]
        public async Task<IActionResult> ApproveCoach(Guid coachId, [FromBody] Guid adminId)
        {
            await _approvalService.ApproveCoachByAdminAsync(adminId, coachId);
            return Ok("مربی تأیید شد.");
        }

        // رد کردن هر کاربر
        [HttpPut("reject/{userId}")]
        public async Task<IActionResult> RejectUser(Guid userId)
        {
            await _approvalService.RejectUserAsync(userId);
            return Ok("کاربر رد شد.");
        }
    }
}
