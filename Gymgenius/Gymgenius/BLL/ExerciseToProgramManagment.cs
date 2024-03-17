using Azure.Core.Pipeline;
using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;
using System.Diagnostics.Eventing.Reader;

namespace GymGenius.BLL
{
    public class ExerciseToProgramManagment
    {
        private readonly IExerciseToProgramRepository _exerciseToProgram;

        public ExerciseToProgramManagment(IExerciseToProgramRepository exerciseToProgram)
        {
            _exerciseToProgram = exerciseToProgram;
        }

        public void AddExerciseToProgram(Exercise exercise, TrainingProgram program)
        {
            _exerciseToProgram.AddExerciseToProgram(exercise, program);
        }

        public void DeleteExerciseFromProgram(Exercise exercise, TrainingProgram program)
        {
            _exerciseToProgram.DeleteExerciseFromProgram(exercise, program);
        }

        public List<Exercise> GetAllExerciseOfProgram(TrainingProgram program)
        {
            return _exerciseToProgram.GetAllExerciseOfProgram(program);
        }

        public bool IsExerciseExistsInProgram(Exercise exercise, TrainingProgram program)
        {
            return _exerciseToProgram.IsExerciseExistsInProgram(exercise, program);
        }
    }
}
