using Gymgenius.bll;
using Gymgenius.bo;
using Gymgenius.dal;
using Microsoft.AspNetCore.Mvc;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserDAL _users;
        public UserController(IUserDAL userDAL)
        {
            _users = userDAL;

        }
        [HttpGet("list_users")]
        public ActionResult<IEnumerable<User>> GetAllUser()
        {
            return _users.GetAllUsers();
        }

        [HttpGet("get_user/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            if (_users.IsUserExists(id))
            {
                return _users.GetUserById(id);
            }

            return NotFound("No users found.");
        }
        
        [HttpPost("add_user")]
        public ActionResult<User> AddUser(User user)
        {
            _users.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
    }
}
