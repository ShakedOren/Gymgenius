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
            await connection.ExecuteAsync("INSERT INTO UserToTrainingProgram (TrainingProgramName, UserName) VALUES (@ProgramName, @UserName)", new { ProgramName = program.Name, UserName = user.UserName });
        }

        public async Task<TrainingProgram?> GetUserProgram(User user)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.QueryFirstOrDefaultAsync<TrainingProgram>("SELECT t.* FROM UserToTrainingProgram uttp JOIN TrainingPrograms t on t.Name = uttp.TrainingProgramName WHERE uttp.UserName=@UserName", new { UserName = user.UserName });
        }

        public async Task<bool> IsUserHasProgram(User user)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM UserToTrainingProgram WHERE UserName=@UserName) THEN 1 else 0 END;", new { UserName = user.UserName});
        }

        public async Task RemoveProgramFromUser(User user)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            await connection.ExecuteAsync("DELETE FROM UserToTrainingProgram WHERE UserName=@UserName", new { UserName = user.UserName});
        }
    }
}
