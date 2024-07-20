using Dapper;
using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public class ExerciseToProgramMSSQLRepository : IExerciseToProgramRepository
    {
        private readonly DapperContext _dapperContext;

        public ExerciseToProgramMSSQLRepository(DapperContext dapperContext)
        {
            this._dapperContext = dapperContext;
        }
        public async Task AddExerciseToProgram(Exercise exercise, TrainingProgram program)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("INSERT INTO ExerciseToTrainingProgram (TrainingProgramName, ExerciseName) VALUES (@ProgramName, @ExerciseName)", new { ProgramName = program.Name, ExerciseName = exercise.Name});
        }

        public async Task DeleteExerciseFromProgram(Exercise exercise, TrainingProgram program)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("DELETE FROM ExerciseToTrainingProgram WHERE TrainingProgramName=@ProgramName AND ExerciseName=@ExerciseName", new { ProgramName = program.Name, ExerciseName = exercise.Name });
        }

        public async Task<List<Exercise>> GetAllExerciseOfProgram(TrainingProgram program)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return (await connection.QueryAsync<Exercise>("SELECT e.* FROM ExerciseToTrainingProgram ettp JOIN Exercises e on e.Name = ettp.ExerciseName WHERE TrainingProgramName = @ProgramName", new { ProgramName = program.Name })).ToList();
        }

        public async Task<bool> IsExerciseExistsInProgram(Exercise exercise, TrainingProgram program)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM ExerciseToTrainingProgram WHERE TrainingProgramName=@ProgramName AND ExerciseName=@ExerciseName) THEN 1 ELSE 0 END", new { ProgramName = program.Name, ExerciseName = exercise.Name });
        }
    }
}
