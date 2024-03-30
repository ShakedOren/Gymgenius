using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public interface ITrainingProgramRepository
    {
        Task<TrainingProgram> GetTrainingProgramByName(string trainingProgramName);
        Task<List<TrainingProgram>> GetAllTrainingPrograms();
        Task AddTrainingProgram(TrainingProgram trainingProgram);
        Task DeleteTrainingProgram(string trainingProgramName);
        Task<bool> IsTrainingProgramExists(string trainingProgramName);
    }
}
