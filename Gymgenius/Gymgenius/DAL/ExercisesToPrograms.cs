using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public interface ExercisesToPrograms
    {
        void AddExerciseToProgram(Exercise exercise, TrainingProgram trainingProgram);
        void RemoveExerciseFromProgram(Exercise exercise, TrainingProgram trainingProgram);
    }
}
