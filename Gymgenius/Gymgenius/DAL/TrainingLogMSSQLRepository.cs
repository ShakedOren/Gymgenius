using Dapper;
using GymGenius.BO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GymGenius.DAL
{
    public class TrainingLogMSSQLRepository : ITrainingLogRepository
    {
        private readonly DapperContext _dapperContext;

        public TrainingLogMSSQLRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task LogTraining(TrainingLog trainingLog)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            var query = "INSERT INTO TrainingLogs (TrainingProgramName, UserName) OUTPUT Inserted.Id VALUES (@ProgramName, @UserName) ";
            trainingLog.Id = await connection.QuerySingleAsync<int>(query, new { trainingLog.ProgramName, trainingLog.UserName });
        }

        public async Task<IEnumerable<TrainingLog>> GetLogs()
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            var logs = await connection.QueryAsync<TrainingLog>("SELECT Id, TrainingProgramName AS ProgramName, UserName, DateCreated FROM TrainingLogs");
            foreach (var log in logs)
            {
                log.ExerciseLogs = (await connection.QueryAsync<ExerciseLog>("SELECT ExerciseName, Sets, Reps FROM ExerciseLogs WHERE TrainingLogId = @Id", new { log.Id})).ToList();
            }
            return logs;
        }

        public async Task<IEnumerable<TrainingLog>> GetLogsByUser(string userName)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            var logs = await connection.QueryAsync<TrainingLog>("SELECT Id, TrainingProgramName AS ProgramName, UserName, DateCreated FROM TrainingLogs WHERE UserName = @UserName", new { UserName = userName });
            foreach (var log in logs)
            {
                log.ExerciseLogs = (await connection.QueryAsync<ExerciseLog>("SELECT ExerciseName, Sets, Reps FROM ExerciseLogs WHERE TrainingLogId = @TrainingLogId", new { TrainingLogId = log.Id})).ToList();
            }
            return logs;
        }
    }
}
