using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public interface ITrainingProgramRepository
    {
        Task<TrainingProgram> GetTrainingProgramById(int trainingProgramId);
        Task<List<TrainingProgram>> GetAllTrainingPrograms();
        Task AddTrainingProgram(TrainingProgram trainingProgram);
        Task DeleteTrainingProgram(int trainingProgramId);
        Task<bool> IsTrainingProgramExists(int trainingProgramId);
    }
}
