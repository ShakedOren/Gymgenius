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
        public async Task<ActionResult<IEnumerable<TrainingProgram>>> GetAllGetAllTrainingProgramsExercises()
        {
            try
            {
                return await _trainingManagment.GetAllTrainingPrograms();
            }
            catch (Exception ex) 
            { 
                return NotFound(ex.Message); 
            }
        }

        [HttpGet("get_program/{program_name}")]
        public async Task<ActionResult<TrainingProgram>> GetProgram(string program_name)
        {
            try
            {
                return await _trainingManagment.GetTrainingProgramByName(program_name);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add_program")]
        public async Task<ActionResult<TrainingProgram>> AddProgram(TrainingProgram trainingProgram)
        {
            try
            {
                await _trainingManagment.AddTrainingProgram(trainingProgram);
                return CreatedAtAction(nameof(GetProgram), new { program_name = trainingProgram.Name }, trainingProgram);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete_program/{program_name}")]
        public async Task<ActionResult> DeleteProgram(string program_name)
        {
            try
            {
                await _trainingManagment.DeleteTrainingProgram(program_name);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
