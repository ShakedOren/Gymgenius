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
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            try
            {
                return await _userManagment.GetAllUsers();
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("get_user/{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            try
            {
                return await _userManagment.GetUserById(username);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add_user")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                await _userManagment.AddUser(user);
                return CreatedAtAction(nameof(GetUser), new { userName = user.UserName}, user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete_user/{username}")]
        public async Task<ActionResult> DeleteUser(string username)
        {
            try
            {
                await _userManagment.DeleteUser(username);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        // add function to update user role
        [HttpPost("change_user_role/{username}/{roleId}")]
        public async Task<ActionResult> ChangeUserRole(string username, int roleId)
        {
            try
            {
                await _userManagment.ChangeUserRole(username, roleId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
