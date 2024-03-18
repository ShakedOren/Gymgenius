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
        private readonly UserManagment _userManagment;

        public UserController(UserManagment userManagment)
        {
            _userManagment = userManagment;
        }

        [HttpGet("list_users")]
        public ActionResult<IEnumerable<User>> GetAllUser()
        {
            try
            {
                return _userManagment.GetAllUsers();
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("get_user/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                return _userManagment.GetUserById(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add_user")]
        public ActionResult<User> AddUser(User user)
        {
            try
            {
                _userManagment.AddUser(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete_user/{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userManagment.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
