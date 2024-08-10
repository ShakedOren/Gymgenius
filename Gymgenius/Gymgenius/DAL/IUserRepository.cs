using Gymgenius.bo;

namespace Gymgenius.dal
{
    public interface IUserRepository
    { 
        Task<User> GetUserByUsername(string userName);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task DeleteUser(string userName);
        Task<bool> IsUserExists(string userName);
    }
}
