using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public class TrainingProgramMemoryRepository : ITrainingProgramRepository
    {
        private List<TrainingProgram> _programs= [];

        public Task AddTrainingProgram(TrainingProgram trainingProgram)
        {
            _programs.Add(trainingProgram);
            return Task.CompletedTask;
        }

        public async Task DeleteTrainingProgram(string trainingProgramName)
        {
            _programs.Remove(await GetTrainingProgramByName(trainingProgramName));
        }

        public Task<List<TrainingProgram>> GetAllTrainingPrograms()
        {
            return Task.FromResult(_programs);
        }

        public Task<TrainingProgram> GetTrainingProgramByName(string trainingProgramName)
        {
            return Task.FromResult(_programs.Find(u => u.Name == trainingProgramName) ?? throw new Exception("Program Not Found"));
        }

        public Task<bool> IsTrainingProgramExists(string trainingProgramName)
        {
            return Task.FromResult(_programs.Any(u => u.Name == trainingProgramName));
        }
    }
}
