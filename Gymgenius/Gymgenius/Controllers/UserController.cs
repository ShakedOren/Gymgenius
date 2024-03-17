using Gymgenius.bll;
using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManagment userManagment;

        public UserController(IUserRepository userDAL)
        {
            userManagment = new UserManagment(userDAL);
        }

        [HttpGet("list_users")]
        public ActionResult<IEnumerable<User>> GetAllUser()
        {
            return userManagment.GetAllUsers();
        }

        [HttpGet("get_user/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            if (!userManagment.IsUserExists(id))
            {
                return NotFound("No users found.");
            }

            return userManagment.GetUserById(id);
        }

        [HttpPost("add_user")]
        public ActionResult<User> AddUser(User user)
        {
            userManagment.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpDelete("delete_user/{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (!userManagment.IsUserExists(id))
            {
                return NotFound("No users found.");
            }

            userManagment.DeleteUser(id);
            return NoContent();
        }
    }
}
