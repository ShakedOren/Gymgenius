using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public class ExerciseToProgramMemoryRepository : IExerciseToProgramRepository
    {
        private List<KeyValuePair<TrainingProgram, Exercise>> _exerciseToProgram = [];

        public Task AddExerciseToProgram(Exercise exercise, TrainingProgram program)
        {
            _exerciseToProgram.Add(new KeyValuePair<TrainingProgram, Exercise> (program, exercise));
            return Task.CompletedTask;
        }

        public Task DeleteExerciseFromProgram(Exercise exercise, TrainingProgram program)
        {

            if (!IsExerciseExistsInProgram(exercise, program).Result)
            {
                throw new Exception("Excercise not in program");
            }

            var pairToRemove = _exerciseToProgram.Find(p =>
             p.Key.Name == program.Name && p.Value.Name == exercise.Name);

            _exerciseToProgram.Remove(pairToRemove);
            return Task.CompletedTask;
        }

        public Task<List<Exercise>> GetAllExerciseOfProgram(TrainingProgram program)
        {
            return Task.FromResult(_exerciseToProgram
                .Where(p => p.Key.Name == program.Name)
                .Select(p => p.Value)
                .ToList());
        }

        public Task<bool> IsExerciseExistsInProgram(Exercise exercise, TrainingProgram program)
        {
            return Task.FromResult(_exerciseToProgram.Any(p => p.Key.Name == program.Name && p.Value.Name == exercise.Name));
        }
    }
}
