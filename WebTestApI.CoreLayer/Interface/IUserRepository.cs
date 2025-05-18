using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Entity;

namespace WebTestApI.CoreLayer.Interface
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

    }
}
