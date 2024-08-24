using GymGenius.BO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymGenius.dal;

namespace GymGenius.DAL
{
    public class RoleToProgramMemoryRepository : IRoleRepository
    {
        private List<Role> _roles = new List<Role>();

        public Task<List<Role>> GetAllRoles()
        {
            return Task.FromResult(_roles);
        }

        public Task<Role> GetUserRole(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRoleByName(string name)
        {
            var role = _roles.FirstOrDefault(r => r.RoleName == name);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            return Task.FromResult(role);
        }
    }
}