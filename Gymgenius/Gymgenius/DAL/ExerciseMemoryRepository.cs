using Gymgenius.bo;
using Gymgenius.dal;

namespace GymGenius.DAL
{
    public class ExerciseMemoryRepository : IExerciseRepository
    {
        private List<Exercise> _exercises = [];

        public Task AddExercise(Exercise exercise)
        {
            _exercises.Add(exercise);
            return Task.CompletedTask;
        }

        public async Task DeleteExercise(string name)
        {
            _exercises.Remove(await GetExerciseByName(name));
        }

        public Task<List<Exercise>> GetAllExercises()
        {
            return Task.FromResult(_exercises);
        }

        public Task<Exercise> GetExerciseByName(string name)
        {
            return Task.FromResult(_exercises.Find(u => u.Name == name) ?? throw new Exception("Exercise Not Found"));
        }

        public Task<bool> IsExerciseExists(string name)
        {
            return Task.FromResult(_exercises.Any(u => u.Name == name));
        }
    }
}
