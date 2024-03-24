using Dapper;
using Gymgenius.bo;
using GymGenius.BO;
using System.Data.Common;

namespace GymGenius.DAL
{
    public class UserToProgramMSSQLRepository : IUserToProgramRepository
    {
        private readonly DapperContext _dapperContext;

        public UserToProgramMSSQLRepository(DapperContext dapperContext)
        {
            this._dapperContext = dapperContext;
        }
        public async Task AddProgramToUser(User user, TrainingProgram program)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("INSERT INTO UserToTrainingProgram (ProgramId, UserId) VALUES (@ProgramId, @UserId)", new { ProgramId = program.Id, UserId = user.Id });
        }

        public async Task<TrainingProgram> GetUserProgram(User user)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.QueryFirstAsync<TrainingProgram>("SELECT t.* FROM UserToTrainingProgram uttp JOIN TrainingPrograms t on t.id = uttp.ProgramId WHERE uttp.UserId=@UserId", new { UserId = user.Id});
        }

        public async Task<bool> IsUserHaveProgram(User user)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM UserToTrainingProgram WHERE UserId=@UserId", new { UserId = user.Id});
        }

        public async Task RemoveProgramFromUser(User user)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("DELETE FROM UserToTrainingProgram WHERE UserId=@UserId", new { UserId = user.Id});
        }
    }
}
