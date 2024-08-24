using Dapper;
using GymGenius.BO;
using Gymgenius.dal;
using System.Data.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using GymGenius.dal;
using Microsoft.AspNetCore.Mvc;

namespace GymGenius.DAL
{
    public class RoleMSSQLRepository : IRoleRepository
    {
        private readonly DapperContext _dapperContext;

        public RoleMSSQLRepository(DapperContext dapperContext)
        {
            this._dapperContext = dapperContext;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return (await connection.QueryAsync<Role>("SELECT * FROM Roles")).ToList();
        }

        public async Task<Role> GetRoleByName(string name)
        {
            using var connection = _dapperContext.CreateConnection();
            connection.Open();
            return await connection.QueryFirstAsync<Role>("SELECT * FROM Roles WHERE RoleName = @RoleName", new { RoleName = name });
        }
        public async Task<Role> GetUserRole(string username)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "SELECT r.RoleName FROM Users u INNER JOIN Roles r ON u.RoleId = r.RoleId WHERE u.Username = @Username";
            return await connection.QueryFirstAsync<Role>(query, new { Username = username });
        }
    }
}