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
        private readonly TrainingProgramManagment _trainingManagment;

        public TrainingProgramController(TrainingProgramManagment trainingManagment)
        {
            _trainingManagment = trainingManagment;
        }

        [HttpGet("list_programs")]
        public ActionResult<IEnumerable<TrainingProgram>> GetAllGetAllTrainingProgramsExercises()
        {
            try
            {
                return _trainingManagment.GetAllTrainingPrograms();
            }
            catch (Exception ex) 
            { 
                return NotFound(ex.Message); 
            }
        }

        [HttpGet("get_program/{id}")]
        public ActionResult<TrainingProgram> GetProgram(int id)
        {
            try
            {
                return _trainingManagment.GetTrainingProgramById(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add_program")]
        public ActionResult<TrainingProgram> AddProgram(TrainingProgram trainingProgram)
        {
            try
            {
                _trainingManagment.AddTrainingProgram(trainingProgram);
                return CreatedAtAction(nameof(GetProgram), new { id = trainingProgram.Id }, trainingProgram);
            } 
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete_program/{id}")]
        public ActionResult DeleteProgram(int id)
        {
            try
            {
                _trainingManagment.DeleteTrainingProgram(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
