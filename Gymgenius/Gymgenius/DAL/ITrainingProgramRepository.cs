using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public interface ITrainingProgramRepository
    {
        TrainingProgram GetTrainingProgramById(int trainingProgramId);
        List<TrainingProgram> GetAllTrainingPrograms();
        void AddTrainingProgram(TrainingProgram trainingProgram);
        void DeleteTrainingProgram(int trainingProgramId);
        bool IsTrainingProgramExists(int trainingProgramId);
    }
}
