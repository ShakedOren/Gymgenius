using Gymgenius.bll;
using Gymgenius.bo;
using Gymgenius.dal;
using Microsoft.AspNetCore.Mvc;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly Manager _manager;
        
        public ManagerController(IUserDAL userDAL)
        {
            _manager = new Manager(userDAL);

        }

        [HttpGet("list_users")]
        public ActionResult<IEnumerable<User>> GetAllUser()
        {
            return _manager.GetAllUsers();
        }

        [HttpGet("get_user/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            if (!_manager.IsUserExists(id))
            {
                return NotFound("No users found.");
            }

            return _manager.GetUserById(id);
        }
        
        [HttpPost("add_user")]
        public ActionResult<User> AddUser(User user)
        {
            _manager.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpDelete("delete_user/{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (!_manager.IsUserExists(id))
            {
                return NotFound("No users found.");
            }

            _manager.DeleteUser(id);
            return NoContent();
        }
    }
}
