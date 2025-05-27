using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestApI.ApplicationLayer.Interface
{
    public interface IApprovalService
    {
        Task ApproveUserAsync(Guid userId);
        Task RejectUserAsync(Guid userId);
    }
}
