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
        private readonly ExerciseToProgramManagment exerciseToProgramManagment;
        private readonly ExerciseManagment exerciseManagment;
        private readonly TrainingProgramManagment trainingManagment;

        public ExerciseToProgramController(IExerciseToProgramRepository exerciseToProgramDAL, IExerciseRepository exerciseDAL, ITrainingProgramRepository trainingProgramDAL)
        {
            exerciseToProgramManagment = new ExerciseToProgramManagment(exerciseToProgramDAL);
            exerciseManagment = new ExerciseManagment(exerciseDAL);
            trainingManagment = new TrainingProgramManagment(trainingProgramDAL);
        }

        [HttpGet("list_exercises/{id}")]
        public ActionResult<IEnumerable<Exercise>> GetAllExerciseOfProgram(int id)
        {
            if (!trainingManagment.IsTrainingProgramExists(id))
            {
                return NotFound("No program found.");
            }

            return exerciseToProgramManagment.GetAllExerciseOfProgram(trainingManagment.GetTrainingProgramById(id));
        }

        [HttpGet("add_exercise_to_program/{exercise_name}/{program_id}")]
        public ActionResult AddExerciseToProgram(string exercise_name, int program_id)
        {
            if (!exerciseManagment.IsExerciseExists(exercise_name))
            {
                return NotFound("No exercise found.");
            }

            if (!trainingManagment.IsTrainingProgramExists(program_id))
            {
                return NotFound("No program found.");
            }

            Exercise exercise = exerciseManagment.GetExerciseByName(exercise_name);
            TrainingProgram program = trainingManagment.GetTrainingProgramById(program_id);
            if (exerciseToProgramManagment.IsExerciseExistsInProgram(exercise, program))
            {
                return NotFound("Exercise already in program.");
            }

            exerciseToProgramManagment.AddExerciseToProgram(exercise, program);
            return NoContent();
        }

        [HttpDelete("delete_exercise_from_program/{exercise_name}/{program_id}")]
        public ActionResult DeleteExerciseFromProgram(string exercise_name, int program_id)
        {
            if (!exerciseManagment.IsExerciseExists(exercise_name))
            {
                return NotFound("No exercise found.");
            }

            if (!trainingManagment.IsTrainingProgramExists(program_id))
            {
                return NotFound("No program found.");
            }

            Exercise exercise = exerciseManagment.GetExerciseByName(exercise_name);
            TrainingProgram program = trainingManagment.GetTrainingProgramById(program_id);
            if (!exerciseToProgramManagment.IsExerciseExistsInProgram(exercise, program))
            {
                return NotFound("Exercise not in program.");
            }

            exerciseToProgramManagment.DeleteExerciseFromProgram(exercise, program);
            return NoContent();
        }
    }
}
