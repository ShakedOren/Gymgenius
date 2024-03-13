using Gymgenius.bo;
using Gymgenius.dal;

namespace Gymgenius.bll
{
    public class UserDataAccessMemory : IDAL
    {
        private List<User> users = new List<User>();
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            users.Remove(GetUserById(userId));
        }
        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int userId)
        {
            return users.Find(u => u.Id == userId) ?? throw new Exception("User Not Found");    
        }

        public override string ToString()
        {
            return string.Join("\n", users);
        }
    }
}
