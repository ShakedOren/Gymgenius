using Gymgenius.bo;

namespace Gymgenius.dal
{
    public interface IExerciseRepository
    { 
        Task<Exercise> GetExerciseByName(string name);
        Task<List<Exercise>> GetAllExercises();
        Task AddExercise(Exercise exercise);
        Task DeleteExercise(string name);
        Task<bool> IsExerciseExists(string name);
    }
}