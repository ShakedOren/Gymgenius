using Gymgenius.bll;
using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingProgramController : ControllerBase
    {
        private readonly TrainingProgramManagment trainingManagment;

        public TrainingProgramController(ITrainingProgramRepository trainingDAL)
        {
            trainingManagment = new TrainingProgramManagment(trainingDAL);
        }

        [HttpGet("list_programs")]
        public ActionResult<IEnumerable<TrainingProgram>> GetAllGetAllTrainingProgramsExercises()
        {
            return trainingManagment.GetAllTrainingPrograms();
        }

        [HttpGet("get_program/{id}")]
        public ActionResult<TrainingProgram> GetProgram(int id)
        {
            if (!trainingManagment.IsTrainingProgramExists(id))
            {
                return NotFound("No program found.");
            }

            return trainingManagment.GetTrainingProgramById(id);
        }

        [HttpPost("add_program")]
        public ActionResult<TrainingProgram> AddProgram(TrainingProgram trainingProgram)
        {
            trainingManagment.AddTrainingProgram(trainingProgram);
            return CreatedAtAction(nameof(GetProgram), new { id = trainingProgram.Id }, trainingProgram);
        }

        [HttpDelete("delete_program/{id}")]
        public ActionResult DeleteProgram(int id)
        {
            if (!trainingManagment.IsTrainingProgramExists(id))
            {
                return NotFound("No users found.");
            }

            trainingManagment.DeleteTrainingProgram(id);
            return NoContent();
        }
    }
}
