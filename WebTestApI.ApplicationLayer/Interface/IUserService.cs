using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.ApplicationLayer.Dtos;

namespace WebTestApI.ApplicationLayer.Interface
{
  public interface IUserService
    {
        Task<bool> RegisterStudentAsync(StudentRegisterDto dto);
        Task<bool> RegisterCoachAsync(CoachRegisterDto dto);
        Task<bool> ApproveUserAsync(Guid userId);  // تأیید توسط مربی یا ادمین
    }
}
