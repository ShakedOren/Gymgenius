using Gymgenius.bo;
using Gymgenius.dal;

namespace Gymgenius.bll
{
    public class UserMemoryRepository : IUserRepository
    {
        private List<User> _users = new List<User>();
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            _users.Remove(GetUserById(userId));
        }
        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int userId)
        {
            return _users.Find(u => u.Id == userId) ?? throw new Exception("User Not Found");    
        }

        public bool IsUserExists(int userId)
        {
            return _users.Any(u => u.Id == userId);
        }

        public bool IsUserTrainer(int userId)
        {
            return GetUserById(userId).IsTrainer;
        }
    }
}
