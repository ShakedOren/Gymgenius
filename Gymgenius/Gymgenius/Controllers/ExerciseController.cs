using Gymgenius.bll;
using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseManagment exerciseManagment;

        public ExerciseController(IExerciseRepository exerciseDAL)
        {
            exerciseManagment = new ExerciseManagment(exerciseDAL);
        }

        [HttpGet("list_exercises")]
        public ActionResult<IEnumerable<Exercise>> GetAllExercises()
        {
            return exerciseManagment.GetAllExercises();
        }

        [HttpGet("get_exercise/{exercise}")]
        public ActionResult<Exercise> GetExercise(string exercise)
        {
            if (!exerciseManagment.IsExerciseExists(exercise))
            {
                return NotFound("No exercise found.");
            }

            return exerciseManagment.GetExerciseByName(exercise);
        }

        [HttpPost("add_exercise")]
        public ActionResult<Exercise> AddExercise(Exercise exercise)
        {
            exerciseManagment.AddExercise(exercise);
            return CreatedAtAction(nameof(GetExercise), new { exercise = exercise.Name }, exercise);
        }

        [HttpDelete("delete_exercise/{name}")]
        public ActionResult DeleteExercise(string name)
        {
            if (!exerciseManagment.IsExerciseExists(name))
            {
                return NotFound("No exercise found.");
            }

            exerciseManagment.DeleteExercise(name);
            return NoContent();
        }
    }
}
