using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;

namespace Gymgenius.bo
{
    public class ExerciseManagment
    {
        private readonly IExerciseRepository _exercises;

        public ExerciseManagment(IExerciseRepository exercises)
        {
            _exercises = exercises;
        }

        public async Task<Exercise> GetExerciseByName(string name)
        {
            if (!await _exercises.IsExerciseExists(name))
            {
                throw new Exception("No exercise found.");
            }

            return await _exercises.GetExerciseByName(name);
        }

        public async Task<List<Exercise>> GetAllExercises()
        {
            return await _exercises.GetAllExercises();
        }

        public async Task AddExercise(Exercise exercise)
        {
            await _exercises.AddExercise(exercise);
        }

        public async Task DeleteExercise(string name)
        {

            if (!await _exercises.IsExerciseExists(name))
            {
                throw new Exception("No exercise found.");
            }

            await _exercises.DeleteExercise(name);
        }

        public async Task<bool> IsExerciseExists(string name)
        {
            return await _exercises.IsExerciseExists(name);
        }
    }
}