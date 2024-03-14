using Gymgenius.dal;

namespace Gymgenius.bo
{
    public class Manager
    {
        private readonly IUserDAL _users;

        public Manager(IUserDAL users)
        { 
            _users = users; 
        }

        public void AddUser(User user)
        {
            _users.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            _users.DeleteUser(userId);
        }
        public List<User> GetAllUsers()
        {
            return _users.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            return _users.GetUserById(userId);
        }
        public bool IsUserExists(int userId)
        {
            return _users.IsUserExists(userId);
        }
    }
}
