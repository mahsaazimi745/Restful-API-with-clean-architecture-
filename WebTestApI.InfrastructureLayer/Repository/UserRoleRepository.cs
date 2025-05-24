using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Entity;
using WebTestApI.CoreLayer.Interface;
using WebTestApI.InfrastructureLayer.Data;

namespace WebTestApI.InfrastructureLayer.Repository
{
    public class UserRoleRepository:IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
        }
    }
}

