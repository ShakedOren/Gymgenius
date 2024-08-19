using Gymgenius.bll;
using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.BLL;
using GymGenius.BO;
using GymGenius.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserToProgramController : ControllerBase
    {
        private readonly UserToProgramManagment _userToProgramManagment;

        public UserToProgramController(UserToProgramManagment userToProgramManagment)
        {
            _userToProgramManagment = userToProgramManagment;
        }

        [HttpGet("get_user_program/{username}")]
        public async Task<ActionResult<TrainingProgram>> GetUserProgram(string username)
        {
            var response = await _userToProgramManagment.GetUserProgram(username);
            if (response != null)
            {
                return response;
            }

            return NotFound();
         }

        [HttpPost("add_program_to_user/{username}/{program_name}")]
        public async Task<ActionResult> AddProgramToUser(string username, string program_name)
        {
            try
            {
                await _userToProgramManagment.AddProgramToUser(username, program_name);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("remove_program_from_user/{username}")]
        public async Task<ActionResult> RemoveProgramFromUser(string username)
        {
            try
            {
                await _userToProgramManagment.RemoveProgramFromUser(username);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("is_user_has_program/{username}")]
        public async Task<ActionResult<bool>> IsUserHasProgram(string username)
        {
            try
            {
                return await _userToProgramManagment.IsUserHasProgram(username);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
    }
}