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
        connection.Open();
        await connection.ExecuteAsync("INSERT INTO Users (FirstName, LastName, Age, Email) VALUES (@FirstName, @LastName, @Age, @Email)", user);
    }

    public async Task DeleteUser(int userId)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync("DELETE FROM Users WHERE Id = @Id", new { Id = userId });
    }

    public async Task<List<User>> GetAllUsers()
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return (await connection.QueryAsync<User>("SELECT * FROM Users")).ToList();
    }

    public async Task<User> GetUserById(int userId)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return await connection.QueryFirstAsync<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = userId });

    }

    public async Task<bool> IsUserExists(int userId)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM Users WHERE Id = @Id) THEN 1 ELSE 0 END", new { Id = userId });
    }

    public async Task<bool> IsUserTrainer(int userId)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM Users WHERE Id = @Id and IsTrainer = 1) THEN 1 ELSE 0 END", new { Id = userId });
    }
}