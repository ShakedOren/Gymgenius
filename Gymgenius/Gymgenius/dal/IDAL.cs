using Gymgenius.bo;

namespace Gymgenius.dal
{
    public interface IUserDAL
    {
        User GetUserById(int userId);
        List<User> GetAllUsers();
        void AddUser(User user);
        void DeleteUser(int userId);
        bool IsUserExists(int userId);
    }
}
