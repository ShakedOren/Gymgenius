using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public class ExerciseToProgramMemoryRepository : IExerciseToProgramRepository
    {
        private List<KeyValuePair<TrainingProgram, Exercise>> _exerciseToProgram = [];

        public void AddExerciseToProgram(Exercise exercise, TrainingProgram program)
        {
            _exerciseToProgram.Add(new KeyValuePair<TrainingProgram, Exercise> (program, exercise));
        }

        public void DeleteExerciseFromProgram(Exercise exercise, TrainingProgram program)
        {

            if (!IsExerciseExistsInProgram(exercise, program))
            {
                throw new Exception("Excercise not in program");
            }

            var pairToRemove = _exerciseToProgram.Find(p =>
             p.Key.Id == program.Id && p.Value.Name == exercise.Name);

            _exerciseToProgram.Remove(pairToRemove);
        }

        public List<Exercise> GetAllExerciseOfProgram(TrainingProgram program)
        {
            return _exerciseToProgram
                .Where(p => p.Key.Id == program.Id)
                .Select(p => p.Value)
                .ToList();
        }

        public bool IsExerciseExistsInProgram(Exercise exercise, TrainingProgram program)
        {
            return _exerciseToProgram.Any(p => p.Key.Id == program.Id && p.Value.Name == exercise.Name);
        }
    }
}
