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

        public async Task AddExerciseToProgram(string exerciseName, string trainingProgramName)
        {
            Exercise exercise = await _exercise.GetExerciseByName(exerciseName);
            TrainingProgram program = await _training.GetTrainingProgramByName(trainingProgramName);

            if (await _exerciseToProgram.IsExerciseExistsInProgram(exercise, program))
            {
                throw new Exception("Exercise already in program.");
            }

            await _exerciseToProgram.AddExerciseToProgram(exercise, program);
        }

        public async Task DeleteExerciseFromProgram(string exerciseName, string trainingProgramName)
        {
            Exercise exercise = await _exercise.GetExerciseByName(exerciseName);
            TrainingProgram program = await _training.GetTrainingProgramByName(trainingProgramName);

            if (!await _exerciseToProgram.IsExerciseExistsInProgram(exercise, program))
            {
                throw new Exception("Exercise not in program.");
            }

            await _exerciseToProgram.DeleteExerciseFromProgram(exercise, program);
        }

        public async Task<List<Exercise>> GetAllExerciseOfProgram(string trainingProgramName)
        {
            if (!await _training.IsTrainingProgramExists(trainingProgramName))
            {
                throw new Exception("No program found.");
            }

            return await _exerciseToProgram.GetAllExerciseOfProgram(await _training.GetTrainingProgramByName(trainingProgramName));
        }

        public async Task<bool> IsExerciseExistsInProgram(Exercise exercise, TrainingProgram program)
        {
            return await _exerciseToProgram.IsExerciseExistsInProgram(exercise, program);
        }
    }
}
