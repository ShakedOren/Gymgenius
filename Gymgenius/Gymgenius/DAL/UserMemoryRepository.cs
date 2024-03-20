using Gymgenius.bo;
using Gymgenius.dal;

namespace Gymgenius.bll
{
    public class UserMemoryRepository : IUserRepository
    {
        private List<User> _users = [];
        public Task AddUser(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        public async Task DeleteUser(int userId)
        {
            _users.Remove(await GetUserById(userId));
        }
        public Task<List<User>> GetAllUsers()
        {
            return Task.FromResult(_users);
        }

        public Task<User> GetUserById(int userId)
        {
            return Task.FromResult(_users.Find(u => u.Id == userId) ?? throw new Exception("User Not Found"));    
        }

        public Task<bool> IsUserExists(int userId)
        {
            return Task.FromResult(_users.Any(u => u.Id == userId));
        }

        public async Task<bool> IsUserTrainer(int userId)
        {
            return (await GetUserById(userId)).IsTrainer;
        }
    }
}
