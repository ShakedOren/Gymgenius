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
    public class ExerciseToProgramController : ControllerBase
    {
        private readonly ExerciseToProgramManagment _exerciseToProgramManagment;

        public ExerciseToProgramController(ExerciseToProgramManagment exerciseToProgramManagment)
        {
            _exerciseToProgramManagment = exerciseToProgramManagment;
        }

        [HttpGet("list_exercises/{id}")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetAllExerciseOfProgram(int id)
        {
            try
            {
                return await _exerciseToProgramManagment.GetAllExerciseOfProgram(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("add_exercise_to_program/{exercise_name}/{program_id}")]
        public async Task<ActionResult> AddExerciseToProgram(string exercise_name, int program_id)
        {
            try
            {
                await _exerciseToProgramManagment.AddExerciseToProgram(exercise_name, program_id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete_exercise_from_program/{exercise_name}/{program_id}")]
        public async Task<ActionResult> DeleteExerciseFromProgram(string exercise_name, int program_id)
        {
            try
            {
                await _exerciseToProgramManagment.DeleteExerciseFromProgram(exercise_name, program_id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
