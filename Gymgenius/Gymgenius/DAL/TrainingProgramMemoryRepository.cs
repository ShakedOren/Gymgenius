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

        public async Task DeleteTrainingProgram(int trainingProgramId)
        {
            _programs.Remove(await GetTrainingProgramById(trainingProgramId));
        }

        public Task<List<TrainingProgram>> GetAllTrainingPrograms()
        {
            return Task.FromResult(_programs);
        }

        public Task<TrainingProgram> GetTrainingProgramById(int trainingProgramId)
        {
            return Task.FromResult(_programs.Find(u => u.Id == trainingProgramId) ?? throw new Exception("Program Not Found"));
        }

        public Task<bool> IsTrainingProgramExists(int trainingProgramId)
        {
            return Task.FromResult(_programs.Any(u => u.Id == trainingProgramId));
        }
    }
}
