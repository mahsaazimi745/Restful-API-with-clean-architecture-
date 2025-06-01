using WebTestApI.ApplicationLayer.Interface;
using WebTestApI.CoreLayer.Entity;
using WebTestApI.CoreLayer.Enums;
using WebTestApI.CoreLayer.Interface;

public class ApprovalService : IApprovalService
{
    private readonly IUserRepository _userRepository;

    public ApprovalService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task ApproveStudentByCoachAsync(Guid coachId, Guid studentId, StudentLevel level)
    {
        var coach = await _userRepository.GetByIdAsync(coachId);
        if (coach is not Coach coachEntity)
            throw new Exception("کاربر مورد نظر مربی نیست.");

        var student = await _userRepository.GetByIdAsync(studentId);
        if (student is not Student studentEntity)
            throw new Exception("کاربر مورد نظر دانش‌آموز نیست.");

        studentEntity.ApproveByCoach(coachId, coachEntity, level);
        await _userRepository.UpdateAsync(studentEntity);
    }

    public async Task ApproveCoachByAdminAsync(Guid adminId, Guid coachId)
    {
        var coach = await _userRepository.GetByIdAsync(coachId);
        if (coach is not Coach coachEntity)
            throw new Exception("کاربر مورد نظر مربی نیست.");

        coachEntity.ApproveByAdmin(adminId);
        await _userRepository.UpdateAsync(coachEntity);
    }

    public async Task RejectUserAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new Exception("کاربر یافت نشد.");

        user.Reject();
        await _userRepository.UpdateAsync(user);
    }
}
