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

        public void AddUser(User user)
        {
            _users.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            if (!_users.IsUserExists(userId))
            {
                throw new Exception("No users found.");
            }

            _users.DeleteUser(userId);
        }

        public List<User> GetAllUsers()
        {
            return _users.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            if (!_users.IsUserExists(userId))
            {
                throw new Exception("No users found.");
            }

            return _users.GetUserById(userId);
        }

        public bool IsUserExists(int userId)
        {
            return _users.IsUserExists(userId);
        }
    }
}