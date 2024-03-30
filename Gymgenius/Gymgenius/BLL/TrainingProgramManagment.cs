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

        public async Task<TrainingProgram> GetTrainingProgramByName(string trainingProgramName)
        {

            if (!await _programs.IsTrainingProgramExists(trainingProgramName))
            {
                throw new Exception("No program found.");
            }

            return await _programs.GetTrainingProgramByName(trainingProgramName);
        }

        public async Task<List<TrainingProgram>> GetAllTrainingPrograms()
        {
            return await _programs.GetAllTrainingPrograms();
        }

        public async Task AddTrainingProgram(TrainingProgram trainingProgram)
        {
            await _programs.AddTrainingProgram(trainingProgram);
        }

        public async Task DeleteTrainingProgram(string trainingProgramName)
        {
            if (!await _programs.IsTrainingProgramExists(trainingProgramName))
            {
                throw new Exception("No program found.");
            }

            await _programs.DeleteTrainingProgram(trainingProgramName);
        }

        public async Task<bool> IsTrainingProgramExists(string trainingProgramName) 
        {
            return await _programs.IsTrainingProgramExists(trainingProgramName);
        }
    }
}