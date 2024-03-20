using Dapper;
using Gymgenius.bo;
using Gymgenius.dal;
using System.Data.Common;

public class UserMSSQLRepository : IUserRepository
{
    readonly DapperContext _dapperContext;

    public UserMSSQLRepository(DapperContext dapperContext)
    {
        this._dapperContext = dapperContext;
    }

    public async Task AddUser(User user)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync("INSERT INTO Users (Id, FirstName, LastName, Age, Email) VALUES (@Id, @FirstName, @LastName, @Age, @Email)", user);
    }

    public async Task DeleteUser(int userId)
    {
        using var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync("DELETE FROM Users WHERE Id = @Id", new { Id = userId });
    }

    public Task<List<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUserExists(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUserTrainer(int userId)
    {
        throw new NotImplementedException();
    }
}