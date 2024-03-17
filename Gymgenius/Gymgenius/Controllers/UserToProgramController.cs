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
        private readonly UserToProgramManagment userToProgramManagment;
        private readonly UserManagment userManagment;
        private readonly TrainingProgramManagment trainingManagment;

        public UserToProgramController(IUserToProgramRepository userToProgramRepository, IUserRepository userRepository, ITrainingProgramRepository trainingProgramRepository)
        {
            userToProgramManagment = new UserToProgramManagment(userToProgramRepository);
            userManagment = new UserManagment(userRepository);
            trainingManagment = new TrainingProgramManagment(trainingProgramRepository);
        }

        [HttpGet("get_user_program/{id}")]
        public ActionResult<TrainingProgram> GetUserProgram(int id)
        {
            if (!userManagment.IsUserExists(id))
            {
                return NotFound("No user found.");
            }

            return userToProgramManagment.GetUserProgram(userManagment.GetUserById(id));
        }

        [HttpGet("add_program_to_user/{user_id}/{program_id}")]
        public ActionResult AddProgramToUser(int user_id, int program_id)
        {
            if (!userManagment.IsUserExists(user_id))
            {
                return NotFound("No user found.");
            }

            if (!trainingManagment.IsTrainingProgramExists(program_id))
            {
                return NotFound("No program found.");
            }

            User user = userManagment.GetUserById(user_id);
            TrainingProgram program = trainingManagment.GetTrainingProgramById(program_id);
            if (userToProgramManagment.IsUserHaveProgram(user))
            {
                return NotFound("User already have program.");
            }

            userToProgramManagment.AddProgramToUser(user, program);
            return NoContent();
        }

        [HttpDelete("remove_program_from_user/{user_id}")]
        public ActionResult RemoveProgramFromUser(int user_id)
        {
            if (!userManagment.IsUserExists(user_id))
            {
                return NotFound("No user found.");
            }

            User user = userManagment.GetUserById(user_id);
            if (!userToProgramManagment.IsUserHaveProgram(user))
            {
                return NotFound("No program found for user.");
            }

            userToProgramManagment.RemoveProgramFromUser(user);
            return NoContent();
        }
    }
}