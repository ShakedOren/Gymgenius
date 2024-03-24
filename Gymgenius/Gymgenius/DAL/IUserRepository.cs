using Gymgenius.bo;

namespace Gymgenius.dal
{
    public interface IUserRepository
    { 
        Task<User> GetUserById(string userName);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task DeleteUser(string userName);
        Task<bool> IsUserExists(string userName);
        Task<bool> IsUserTrainer(string userName);
    }
}
