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
        Task<Guid> RegisterAsync(UserRegisterDto dto);
    }
}
