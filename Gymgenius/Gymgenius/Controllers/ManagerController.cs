using Gymgenius.bll;
using Gymgenius.bo;
using Gymgenius.dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly Manager _manager;
        
        public ManagerController(IUserRepository userDAL, IExerciseRepository exerciseDAL)
        {
            _manager = new Manager(userDAL, exerciseDAL);
        }

        [HttpGet("list_users")]
        public ActionResult<IEnumerable<User>> GetAllUser()
        {
            return _manager.GetAllUsers();
        }

        [HttpGet("get_user/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            if (!_manager.IsUserExists(id))
            {
                return NotFound("No users found.");
            }

            return _manager.GetUserById(id);
        }
        
        [HttpPost("add_user")]
        public ActionResult<User> AddUser(User user)
        {
            _manager.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpDelete("delete_user/{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (!_manager.IsUserExists(id))
            {
                return NotFound("No users found.");
            }

            _manager.DeleteUser(id);
            return NoContent();
        }

        [HttpGet("list_exercises")]
        public ActionResult<IEnumerable<Exercise>> GetAllExercises()
        {
            return _manager.GetAllExercises();
        }

        [HttpGet("get_exercise/{exercise}")]
        public ActionResult<Exercise> GetExercise(string exercise)
        {
            if (!_manager.IsExerciseExists(exercise))
            {
                return NotFound("No exercise found.");
            }

            return _manager.GetExerciseByName(exercise);
        }

        [HttpPost("add_exercise")]
        public ActionResult<Exercise> AddExercise(Exercise exercise)
        {
            _manager.AddExercise(exercise);
            return CreatedAtAction(nameof(GetExercise), new { exercise = exercise.Name}, exercise);
        }

        [HttpDelete("delete_exercise/{name}")]
        public ActionResult DeleteExercise(string name)
        {
            if (!_manager.IsExerciseExists(name))
            {
                return NotFound("No exercise found.");
            }

            _manager.DeleteExercise(name);
            return NoContent();
        }
    }
}
