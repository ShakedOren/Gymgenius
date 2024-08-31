using GymGenius.BO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymGenius.DAL
{
	public interface IExerciseLogRepository
	{
		Task AddExerciseLog(ExerciseLog exerciseLog);
		Task<IEnumerable<ExerciseLog>> GetExerciseLogsByTrainingLogId(int trainingLogId);
	}
}