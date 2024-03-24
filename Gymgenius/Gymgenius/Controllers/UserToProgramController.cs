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
            try
            {
                return await _userToProgramManagment.GetUserProgram(username);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("add_program_to_user/{username}/{program_id}")]
        public async Task<ActionResult> AddProgramToUser(string username, int program_id)
        {
            try
            {
                await _userToProgramManagment.AddProgramToUser(username, program_id);
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
    }
}