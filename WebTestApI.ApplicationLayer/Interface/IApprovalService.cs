using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Enums;

namespace WebTestApI.ApplicationLayer.Interface
{
    public interface IApprovalService
    {
        //Task ApproveUserAsync(Guid userId);
        //Task RejectUserAsync(Guid userId);
        /*    Task ApproveStudentByCoachAsync(Guid coachId, Guid studentId);
            Task ApproveCoachByAdminAsync(Guid adminId, Guid coachId);
            Task RejectUserAsync(Guid userId);*/
        Task ApproveStudentByCoachAsync(Guid coachId, Guid studentId, StudentLevel level);
        Task ApproveCoachByAdminAsync(Guid adminId, Guid coachId);
        Task RejectUserAsync(Guid userId);

    }
}
