using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.dal;
using GymGenius.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gymgenius.bo
{
    public class RoleManagement
    {
        private readonly IRoleRepository _roles;

        public RoleManagement(IRoleRepository roles)
        {
            _roles = roles;
        }

        public async Task<Role> GetRoleByName(string name)
        {
            var role = await _roles.GetRoleByName(name);
            if (role == null)
            {
                throw new Exception("No role found.");
            }

            return role;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _roles.GetAllRoles();
        }
    }
}

