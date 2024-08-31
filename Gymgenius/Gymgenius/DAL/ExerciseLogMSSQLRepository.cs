using Dapper;
using GymGenius.BO;
using Gymgenius.dal;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GymGenius.DAL
{
	public class ExerciseLogMSSQLRepository : IExerciseLogRepository
	{
		private readonly DapperContext _dapperContext;

		public ExerciseLogMSSQLRepository(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
		}

		public async Task AddExerciseLog(ExerciseLog exerciseLog)
		{
			using var connection = _dapperContext.CreateConnection();
			var query = "INSERT INTO ExerciseLogs (TrainingLogId, ExerciseName, Sets, Reps) VALUES (@TrainingLogId, @ExerciseName, @Sets, @Reps)";
			await connection.ExecuteAsync(query, exerciseLog);
		}

		public async Task<IEnumerable<ExerciseLog>> GetExerciseLogsByTrainingLogId(int trainingLogId)
		{
			using var connection = _dapperContext.CreateConnection();
			var query = "SELECT * FROM ExerciseLogs WHERE TrainingLogId = @TrainingLogId";
			return await connection.QueryAsync<ExerciseLog>(query, new { TrainingLogId = trainingLogId });
		}
	}
}