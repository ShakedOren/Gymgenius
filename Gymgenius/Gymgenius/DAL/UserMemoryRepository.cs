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

        public async Task DeleteUser(string userName)
        {
            _users.Remove(await GetUserById(userName));
        }
        public Task<List<User>> GetAllUsers()
        {
            return Task.FromResult(_users);
        }

        public Task<User> GetUserById(string userName)
        {
            return Task.FromResult(_users.Find(u => u.UserName == userName) ?? throw new Exception("User Not Found"));    
        }

        public Task<bool> IsUserExists(string userName)
        {
            return Task.FromResult(_users.Any(u => u.UserName == userName));
        }

        public async Task<bool> IsUserTrainer(string userName)
        {
            return (await GetUserById(userName)).IsTrainer;
        }
    }
}
