using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public interface IExerciseToProgramRepository
    {
        Task AddExerciseToProgram(Exercise exercise, TrainingProgram program);
        Task DeleteExerciseFromProgram(Exercise exercise, TrainingProgram program);
        Task<bool> IsExerciseExistsInProgram(Exercise exercise, TrainingProgram program);
        Task<List<Exercise>> GetAllExerciseOfProgram(TrainingProgram program);
    }
}
