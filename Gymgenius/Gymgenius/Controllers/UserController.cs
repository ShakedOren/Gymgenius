using Gymgenius.bll;
using Gymgenius.bo;
using Microsoft.AspNetCore.Mvc;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserDataAccessMemory _users;

        public UserController()
        {
            _users = new UserDataAccessMemory();
        }

        [HttpGet("list_users")]
        public IEnumerable<User> GetAllUser()
        {
            return _users.GetAllUsers();
        }

        [HttpGet("get_first_user")]
        public User GetFirstUser()
        {
            return _users.GetUserById(0);
        }

        [HttpGet("get_user/{id}")]
        public User GetUser(int id)
        {
            return _users.GetUserById(id);
        }
        
        [HttpPost("add_user")]
        public void AddUser(User user)
        {
            _users.AddUser(user);
        }
    }
}
