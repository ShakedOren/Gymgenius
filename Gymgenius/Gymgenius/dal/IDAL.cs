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

    public interface IExerciseDAL
    { 
        Exercise GetExerciseByName(string name);
        List<Exercise> GetAllExercises();
        void AddExercise(Exercise exercise);
        void DeleteExercise(string name);
        bool IsExerciseExists(string name);
    }
}
