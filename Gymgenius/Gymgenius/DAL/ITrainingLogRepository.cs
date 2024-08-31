using GymGenius.BO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymGenius.DAL
{
    public interface ITrainingLogRepository
    {
        Task LogTraining(TrainingLog trainingLog);
        Task<IEnumerable<TrainingLog>> GetLogs();
        Task<IEnumerable<TrainingLog>> GetLogsByUser(string userName);
    }
}