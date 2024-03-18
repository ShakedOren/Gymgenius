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
        private readonly IExerciseRepository _exercise;
        private readonly ITrainingProgramRepository _training;

        public ExerciseToProgramManagment(IExerciseToProgramRepository exerciseToProgramRepository, IExerciseRepository exerciseRepository, ITrainingProgramRepository trainingProgramRepository)
        {
            _exerciseToProgram = exerciseToProgramRepository;
            _exercise = exerciseRepository;
            _training = trainingProgramRepository;
        }

        public void AddExerciseToProgram(string exerciseName, int programId)
        {
            Exercise exercise = _exercise.GetExerciseByName(exerciseName);
            TrainingProgram program = _training.GetTrainingProgramById(programId);

            if (_exerciseToProgram.IsExerciseExistsInProgram(exercise, program))
            {
                throw new Exception("Exercise already in program.");
            }

            _exerciseToProgram.AddExerciseToProgram(exercise, program);
        }

        public void DeleteExerciseFromProgram(string exerciseName, int programId)
        {
            Exercise exercise = _exercise.GetExerciseByName(exerciseName);
            TrainingProgram program = _training.GetTrainingProgramById(programId);

            if (!_exerciseToProgram.IsExerciseExistsInProgram(exercise, program))
            {
                throw new Exception("Exercise not in program.");
            }

            _exerciseToProgram.DeleteExerciseFromProgram(exercise, program);
        }

        public List<Exercise> GetAllExerciseOfProgram(int programId)
        {
            if (!_training.IsTrainingProgramExists(programId))
            {
                throw new Exception("No program found.");
            }

            return _exerciseToProgram.GetAllExerciseOfProgram(_training.GetTrainingProgramById(programId));
        }

        public bool IsExerciseExistsInProgram(Exercise exercise, TrainingProgram program)
        {
            return _exerciseToProgram.IsExerciseExistsInProgram(exercise, program);
        }
    }
}
