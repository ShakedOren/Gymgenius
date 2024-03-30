using Dapper;
using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public class TrainingProgramMSSQLRepository : ITrainingProgramRepository
    {
        private readonly DapperContext _dapperContext;

        public TrainingProgramMSSQLRepository(DapperContext dapperContext)
        {
            this._dapperContext = dapperContext;
        }
        public async Task AddTrainingProgram(TrainingProgram trainingProgram)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("INSERT INTO TrainingPrograms (Name, Description) VALUES (@Name, @Description)", trainingProgram);
        }

        public async Task DeleteTrainingProgram(string trainingProgramName)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("DELETE FROM TrainingPrograms WHERE Name = @Name", new { Name = trainingProgramName });
        }

        public async Task<List<TrainingProgram>> GetAllTrainingPrograms()
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return (await connection.QueryAsync<TrainingProgram>("SELECT * FROM TrainingPrograms")).ToList();
        }

        public async Task<TrainingProgram> GetTrainingProgramByName(string trainingProgramName)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.QueryFirstAsync<TrainingProgram>("SELECT * FROM TrainingPrograms WHERE Name = @Name", new { Name = trainingProgramName });
        }

        public async Task<bool> IsTrainingProgramExists(string trainingProgramName)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM TrainingPrograms WHERE Name = @Name) THEN 1 ELSE 0 END", new { Name = trainingProgramName});

        }
    }
}
