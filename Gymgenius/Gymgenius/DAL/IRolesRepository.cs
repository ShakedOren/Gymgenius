using GymGenius.BO;

namespace GymGenius.dal
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByName(string name);
        Task<List<Role>> GetAllRoles();
        Task<Role> GetUserRole(string username);
    }
}