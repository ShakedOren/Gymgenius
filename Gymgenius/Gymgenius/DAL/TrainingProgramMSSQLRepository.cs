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

        public async Task DeleteTrainingProgram(int trainingProgramId)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("DELETE FROM TrainingPrograms WHERE Id = @Id", new { Id = trainingProgramId});

        }

        public async Task<List<TrainingProgram>> GetAllTrainingPrograms()
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return (await connection.QueryAsync<TrainingProgram>("SELECT * FROM TrainingPrograms")).ToList();
        }

        public async Task<TrainingProgram> GetTrainingProgramById(int trainingProgramId)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.QueryFirstAsync<TrainingProgram>("SELECT * FROM TrainingPrograms WHERE Id = @Id", new { Id = trainingProgramId });
        }

        public async Task<bool> IsTrainingProgramExists(int trainingProgramId)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM TrainingPrograms WHERE Id = @Id) THEN 1 ELSE 0 END", new { Id = trainingProgramId});

        }
    }
}
