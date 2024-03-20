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

        public async Task DeleteUser(int userId)
        {
            if (!await _users.IsUserExists(userId))
            {
                throw new Exception("No users found.");
            }

            await _users.DeleteUser(userId);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _users.GetAllUsers();
        }

        public async Task<User> GetUserById(int userId)
        {
            if (!await _users.IsUserExists(userId))
            {
                throw new Exception("No users found.");
            }

            return await _users.GetUserById(userId);
        }

        public async Task<bool> IsUserExists(int userId)
        {
            return await _users.IsUserExists(userId);
        }
    }
}