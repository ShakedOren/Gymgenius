using Gymgenius.bo;

namespace Gymgenius.dal
{
    public interface IUserRepository
    { 
        Task<User> GetUserById(int userId);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task DeleteUser(int userId);
        Task<bool> IsUserExists(int userId);
        Task<bool> IsUserTrainer(int userId);
    }
}
