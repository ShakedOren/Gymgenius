using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public interface IExerciseToProgramRepository
    {
        void AddExerciseToProgram(Exercise exercise, TrainingProgram program);
        void DeleteExerciseFromProgram(Exercise exercise, TrainingProgram program);
        bool IsExerciseExistsInProgram(Exercise exercise, TrainingProgram program);
        List<Exercise> GetAllExerciseOfProgram(TrainingProgram program);
    }
}
