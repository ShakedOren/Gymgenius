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
        await connection.ExecuteAsync("INSERT INTO Users (UserName, FirstName, LastName, Age, Email) VALUES (@UserName, @FirstName, @LastName, @Age, @Email)", user);
    }

    public async Task DeleteUser(string userName)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync("DELETE FROM Users WHERE UserName = @UserName", new { UserName = userName });
    }

    public async Task<List<User>> GetAllUsers()
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return (await connection.QueryAsync<User>("SELECT * FROM Users")).ToList();
    }

    public async Task<User> GetUserByUsername(string userName)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return await connection.QueryFirstAsync<User>("SELECT * FROM Users WHERE UserName = @UserName", new { UserName = userName });
    }

    public async Task<bool> IsUserExists(string userName)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName) THEN 1 ELSE 0 END", new { UserName = userName });
    }

    public async Task<bool> IsUserTrainer(string userName)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName and IsTrainer = 1) THEN 1 ELSE 0 END", new { UserName = userName});
    }
}