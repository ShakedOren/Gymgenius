using Gymgenius.bo;
using Gymgenius.dal;

namespace Gymgenius.bll
{
    public class ExerciseMemoryRepository : IExerciseRepository
    {
        private List<Exercise> _exercises = new List<Exercise>();

        public void AddExercise(Exercise exercise)
        {
            _exercises.Add(exercise);
        }

        public void DeleteExercise(string name)
        {
            _exercises.Remove(GetExerciseByName(name));
        }

        public List<Exercise> GetAllExercises()
        {
            return _exercises;
        }

        public Exercise GetExerciseByName(string name)
        {
            return _exercises.Find(u => u.Name == name) ?? throw new Exception("Exercise Not Found");
        }

        public bool IsExerciseExists(string name)
        {
            return _exercises.Any(u => u.Name == name);
        }
    }
}
