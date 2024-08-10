using Dapper;
using Gymgenius.bo;
using Gymgenius.dal;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;

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
        user.Password = HashPassword(user.Password);
        await connection.ExecuteAsync("INSERT INTO Users (UserName, FirstName, LastName, Password, Age, Email, RoleId) VALUES (@UserName, @FirstName, @LastName, @Password, @Age, @Email, @RoleId)", user);
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

    public async Task<User?> GetUserByUsername(string userName)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE UserName = @UserName", new { UserName = userName });
    }

    public async Task<bool> IsUserExists(string userName)
    {
        using var connection = _dapperContext.CreateConnection();
        connection.Open();
        return await connection.ExecuteScalarAsync<bool>("SELECT CASE WHEN EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName) THEN 1 ELSE 0 END", new { UserName = userName });
    }
	private string HashPassword(string password)
	{
		if (string.IsNullOrEmpty(password))
		{
			return null;
		}
		using (var sha256 = SHA256.Create())
		{
			var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
			return Convert.ToBase64String(bytes);
		}
	}
}