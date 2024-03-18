using Gymgenius.bll;
using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.IO.Compression;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseManagment _exerciseManagment;

        public ExerciseController(ExerciseManagment exerciseManagment)
        {
            _exerciseManagment = exerciseManagment;
        }

        [HttpGet("list_exercises")]
        public ActionResult<IEnumerable<Exercise>> GetAllExercises()
        {
            try
            {
                return _exerciseManagment.GetAllExercises();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("get_exercise/{exercise}")]
        public ActionResult<Exercise> GetExercise(string exercise)
        {
            try
            {
                return _exerciseManagment.GetExerciseByName(exercise);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add_exercise")]
        public ActionResult<Exercise> AddExercise(Exercise exercise)
        {
            try
            {
                _exerciseManagment.AddExercise(exercise);
                return CreatedAtAction(nameof(GetExercise), new { exercise = exercise.Name }, exercise);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete_exercise/{name}")]
        public ActionResult DeleteExercise(string name)
        {
            try
            {
                _exerciseManagment.DeleteExercise(name);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
