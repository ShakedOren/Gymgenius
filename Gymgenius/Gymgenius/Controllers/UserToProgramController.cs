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

        [HttpGet("get_user_program/{id}")]
        public ActionResult<TrainingProgram> GetUserProgram(int id)
        {
            try
            {
                return _userToProgramManagment.GetUserProgram(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("add_program_to_user/{user_id}/{program_id}")]
        public ActionResult AddProgramToUser(int user_id, int program_id)
        {
            try
            {
                _userToProgramManagment.AddProgramToUser(user_id, program_id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("remove_program_from_user/{user_id}")]
        public ActionResult RemoveProgramFromUser(int user_id)
        {
            try
            {
                _userToProgramManagment.RemoveProgramFromUser(user_id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}