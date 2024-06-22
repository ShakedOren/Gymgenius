using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Gymgenius.bo;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace GymGenius.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(User userSignupDto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var passwordHash = HashPassword(userSignupDto.Password);
                var query = "INSERT INTO Users (Username, PasswordHash, RoleId) VALUES (@Username, @PasswordHash, @RoleId)";
                await connection.ExecuteAsync(query, new { userSignupDto.UserName, PasswordHash = passwordHash, userSignupDto.RoleId });
                return Ok();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User userLoginDto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Users WHERE Username = @Username";
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { userLoginDto.UserName });
                if (user == null || !VerifyPassword(userLoginDto.Password, user.Password))
                {
                    return Unauthorized();
                }

                // Generate JWT token (implement JWT token generation logic)
                var token = GenerateJwtToken(user.UserName);
                return Ok(token);
            }
        }

        [HttpGet("user-role/{username}")]
        public async Task<IActionResult> GetUserRole(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT r.RoleName FROM Users u INNER JOIN Roles r ON u.RoleId = r.RoleId WHERE u.Username = @Username";
                var roleName = await connection.QuerySingleOrDefaultAsync<string>(query, new { Username = username });
                return Ok(new { Role = roleName });
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash;
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresInMinutes"]));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Add other claims here if needed
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}