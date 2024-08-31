using GymGenius.BO;
using GymGenius.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TrainingLogController : ControllerBase
{
    private readonly TrainingLogManagement _trainingLogManagement;

    public TrainingLogController(TrainingLogManagement trainingLogManagement)
    {
        _trainingLogManagement = trainingLogManagement;
    }

    [HttpPost("log_training")]
    public async Task<IActionResult> LogTraining([FromBody] TrainingLog trainingLog)
    {
        await _trainingLogManagement.LogTraining(trainingLog);
        return Ok();
    }

    [HttpGet("get_logs")]
    public async Task<ActionResult<IEnumerable<TrainingLog>>> GetLogs()
    {
        return Ok(await _trainingLogManagement.GetLogs());
    }

    [HttpGet("get_logs_by_user/{userName}")]
    public async Task<ActionResult<IEnumerable<TrainingLog>>> GetLogsByUser(string userName)
    {
        return Ok(await _trainingLogManagement.GetLogsByUser(userName));
    }
    [HttpGet("get_logs_by_id/{id}")]
    public async Task<ActionResult<IEnumerable<TrainingLog>>> GetLogsByUser(int id)
    {
	    return Ok(await _trainingLogManagement.GetExerciseLogsByTrainingLogId(id));
    }
}