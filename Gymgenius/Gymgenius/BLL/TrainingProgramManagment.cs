using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;

namespace Gymgenius.bo
{
    public class TrainingProgramManagment
    {
        private readonly ITrainingProgramRepository _programs;

        public TrainingProgramManagment(ITrainingProgramRepository programs)
        {
            _programs = programs;
        }

        public TrainingProgram GetTrainingProgramById(int trainingProgramId)
        {

            if (!_programs.IsTrainingProgramExists(trainingProgramId))
            {
                throw new Exception("No program found.");
            }

            return _programs.GetTrainingProgramById(trainingProgramId);
        }

        public List<TrainingProgram> GetAllTrainingPrograms()
        {
            return _programs.GetAllTrainingPrograms();
        }

        public void AddTrainingProgram(TrainingProgram trainingProgram)
        {
            _programs.AddTrainingProgram(trainingProgram);
        }

        public void DeleteTrainingProgram(int trainingProgramId)
        {
            if (!_programs.IsTrainingProgramExists(trainingProgramId))
            {
                throw new Exception("No program found.");
            }

            _programs.DeleteTrainingProgram(trainingProgramId);
        }

        public bool IsTrainingProgramExists(int trainingProgramId) 
        {
            return _programs.IsTrainingProgramExists(trainingProgramId);
        }
    }
}