using Gymgenius.bo;
using GymGenius.BO;
using Gymgenius.dal;

namespace GymGenius.DAL
{
    public class UserMemoryRepository : IUserRepository
    {
        private List<User> _users = [];
        public Task AddUser(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        public async Task ChangeUserRole(string username, int roleId)
        {
            _users.Find(u => u.UserName == username).RoleId = roleId;
        }

        public async Task DeleteUser(string userName)
        {
            _users.Remove(await GetUserByUsername(userName));
        }
        public Task<List<User>> GetAllUsers()
        {
            return Task.FromResult(_users);
        }

        public Task<User> GetUserByUsername(string userName)
        {
            return Task.FromResult(_users.Find(u => u.UserName == userName) ?? throw new Exception("User Not Found"));    
        }

        public Task<bool> IsUserExists(string userName)
        {
            return Task.FromResult(_users.Any(u => u.UserName == userName));
        }
    }
}
