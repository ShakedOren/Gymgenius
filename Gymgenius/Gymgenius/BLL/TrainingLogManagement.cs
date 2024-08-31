using GymGenius.BO;
using GymGenius.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymGenius.Services
{
	public class TrainingLogManagement
	{
		private readonly ITrainingLogRepository _trainingLogRepository;
		private readonly IExerciseLogRepository _exerciseLogRepository;

		public TrainingLogManagement(ITrainingLogRepository trainingLogRepository, IExerciseLogRepository exerciseLogRepository)
		{
			_trainingLogRepository = trainingLogRepository;
			_exerciseLogRepository = exerciseLogRepository;
		}

		public async Task LogTraining(TrainingLog trainingLog)
		{
			await _trainingLogRepository.LogTraining(trainingLog);
			foreach (var exerciseLog in trainingLog.ExerciseLogs)
			{
				exerciseLog.TrainingLogId = trainingLog.Id;
				await _exerciseLogRepository.AddExerciseLog(exerciseLog);
			}
		}

		public async Task<IEnumerable<TrainingLog>> GetLogs()
		{
			return await _trainingLogRepository.GetLogs();
		}

		public async Task<IEnumerable<TrainingLog>> GetLogsByUser(string userName)
		{
			return await _trainingLogRepository.GetLogsByUser(userName);
		}

		public async Task<IEnumerable<ExerciseLog>> GetExerciseLogsByTrainingLogId(int trainingLogId)
		{
			return await _exerciseLogRepository.GetExerciseLogsByTrainingLogId(trainingLogId);
		}
	}
}