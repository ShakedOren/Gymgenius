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
using Gymgenius.dal;
using GymGenius.BO;

namespace GymGenius.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly DapperContext _dapperContext;

        public AuthController(IConfiguration configuration, IUserRepository userRepository, DapperContext dapperContext)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _dapperContext = dapperContext;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(User userSignupDto)
        {
            await _userRepository.AddUser(userSignupDto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin userLoginDto)
        {
            var user = await _userRepository.GetUserByUsername(userLoginDto.UserName);
            if (user == null || !VerifyPassword(userLoginDto.Password, user.Password))
            {
                return Unauthorized();
            }

            // Generate JWT token (implement JWT token generation logic)
            var token = GenerateJwtToken(user.UserName, user.RoleId);
            return Ok(token);
            
        }

        [HttpGet("user-role/{username}")]
        public async Task<IActionResult> GetUserRole(string username)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = "SELECT r.RoleName FROM Users u INNER JOIN Roles r ON u.RoleId = r.RoleId WHERE u.Username = @Username";
            var roleName = await connection.QuerySingleOrDefaultAsync<string>(query, new { Username = username });
            return Ok(roleName );
            
        }
        //TODO: need to make it in some other place
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

        private string GenerateJwtToken(string username, int roleId)
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
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, roleId.ToString())
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