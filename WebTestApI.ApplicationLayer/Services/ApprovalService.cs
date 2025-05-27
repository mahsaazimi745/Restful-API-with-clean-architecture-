using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.ApplicationLayer.Interface;
using WebTestApI.CoreLayer.Interface;

namespace WebTestApI.ApplicationLayer.Services
{
  public class ApprovalService : IApprovalService
    {
        private readonly IUserRepository _userRepository;
        public ApprovalService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task ApproveUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("کاربر یافت نشد.");

            user.Approve();
            await _userRepository.UpdateAsync(user);
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
}
