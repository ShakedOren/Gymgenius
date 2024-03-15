using Gymgenius.bo;

namespace Gymgenius.dal
{
    public interface IExerciseRepository
    { 
        Exercise GetExerciseByName(string name);
        List<Exercise> GetAllExercises();
        void AddExercise(Exercise exercise);
        void DeleteExercise(string name);
        bool IsExerciseExists(string name);
    }
}
