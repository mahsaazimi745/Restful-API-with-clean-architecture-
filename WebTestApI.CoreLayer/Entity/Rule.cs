using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestApI.CoreLayer.Entity
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RuleName { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; }

        private Role() { }

        public Role(string ruleName)
        {
            Id = Guid.NewGuid();
            RuleName = ruleName ?? throw new ArgumentNullException(nameof(ruleName));
            UserRoles = new List<UserRole>();

        }

    }
}
