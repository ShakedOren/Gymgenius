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
    public class ManagerController : ControllerBase
    {
        private readonly UserManagment userManagment;
        private readonly ExerciseManagment exerciseManagment;
        private readonly TrainingProgramManagment trainingProgramManagment;
        
        public ManagerController(IUserRepository userDAL, IExerciseRepository exerciseDAL, ITrainingProgramRepository trainingDAL)
        {
            userManagment = new UserManagment(userDAL);
            exerciseManagment = new ExerciseManagment(exerciseDAL);
            trainingProgramManagment = new TrainingProgramManagment(trainingDAL);
        }

        [HttpGet("list_users")]
        public ActionResult<IEnumerable<User>> GetAllUser()
        {
            return userManagment.GetAllUsers();
        }

        [HttpGet("get_user/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            if (!userManagment.IsUserExists(id))
            {
                return NotFound("No users found.");
            }

            return userManagment.GetUserById(id);
        }
        
        [HttpPost("add_user")]
        public ActionResult<User> AddUser(User user)
        {
            userManagment.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpDelete("delete_user/{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (!userManagment.IsUserExists(id))
            {
                return NotFound("No users found.");
            }

            userManagment.DeleteUser(id);
            return NoContent();
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
            return CreatedAtAction(nameof(GetExercise), new { exercise = exercise.Name}, exercise);
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
