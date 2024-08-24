using Gymgenius.bo;
using GymGenius.BO;

namespace Gymgenius.dal
{
    public interface IUserRepository
    { 
        Task<User> GetUserByUsername(string userName);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task ChangeUserRole(string username, int roleId);
        Task DeleteUser(string userName);
        Task<bool> IsUserExists(string userName);
    }
}
