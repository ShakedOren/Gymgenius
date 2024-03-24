using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;

namespace Gymgenius.bo
{
    public class UserManagment
    {
        private readonly IUserRepository _users;

        public UserManagment(IUserRepository users)
        {
            _users = users;
        }

        public async Task AddUser(User user)
        {
            await _users.AddUser(user);
        }

        public async Task DeleteUser(string userName)
        {
            if (!await _users.IsUserExists(userName))
            {
                throw new Exception("No users found.");
            }

            await _users.DeleteUser(userName);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _users.GetAllUsers();
        }

        public async Task<User> GetUserById(string userName)
        {
            if (!await _users.IsUserExists(userName))
            {
                throw new Exception("No users found.");
            }

            return await _users.GetUserById(userName);
        }

        public async Task<bool> IsUserExists(string userName)
        {
            return await _users.IsUserExists(userName);
        }
    }
}