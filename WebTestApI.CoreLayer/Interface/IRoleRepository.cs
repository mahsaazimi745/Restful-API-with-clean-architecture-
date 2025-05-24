using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Entity;

namespace WebTestApI.CoreLayer.Interface
{
  public interface IRoleRepository
    {
        Task<Role> GetByNameAsync(string roleName);
    }
}
