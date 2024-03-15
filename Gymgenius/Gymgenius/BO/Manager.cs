using Gymgenius.dal;

namespace Gymgenius.bo
{
    public class Manager
    {
        private readonly IUserRepository _users;
        private readonly IExerciseRepository _exercises;

        public Manager(IUserRepository users, IExerciseRepository exercises)
        {
            _users = users;
            _exercises = exercises;
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

        public Exercise GetExerciseByName(string name)
        {
            return _exercises.GetExerciseByName(name);
        }

        public List<Exercise> GetAllExercises()
        {
            return _exercises.GetAllExercises();
        }

        public void AddExercise(Exercise exercise)
        {
            _exercises.AddExercise(exercise);
        }

        public void DeleteExercise(string name)
        {
            _exercises.DeleteExercise(name);
        }

        public bool IsExerciseExists(string name)
        {
            return _exercises.IsExerciseExists(name);
        }
    }
}
