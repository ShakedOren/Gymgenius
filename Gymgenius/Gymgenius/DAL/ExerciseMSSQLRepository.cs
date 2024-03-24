using Dapper;
using Gymgenius.bo;
using Gymgenius.dal;
using System.Data.Common;

namespace GymGenius.DAL
{
    public class ExerciseMSSQLRepository : IExerciseRepository
    {
        private readonly DapperContext _dapperContext;

        public ExerciseMSSQLRepository(DapperContext dapperContext)
        {
            this._dapperContext = dapperContext;
        }
        public async Task AddExercise(Exercise exercise)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("INSERT INTO Exercises (Name) VALUES (@Name)", exercise);
        }

        public async Task DeleteExercise(string name)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("DELETE FROM Exercises WHERE Name = @Name", new { Name = name });

        }

        public async Task<List<Exercise>> GetAllExercises()
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return (await connection.QueryAsync<Exercise>("SELECT * FROM Exercises")).ToList();

        }

        public async Task<Exercise> GetExerciseByName(string name)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.QueryFirstAsync<Exercise>("SELECT * FROM Exercises WHERE Name = @Name", new { Name = name });

        }

        public async Task<bool> IsExerciseExists(string name)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM Exercises WHERE Name = @Name) THEN 1 ELSE 0 END", new { Name = name});
        }
    }
}
