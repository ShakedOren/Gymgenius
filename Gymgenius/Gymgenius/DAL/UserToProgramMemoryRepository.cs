using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public class UserToProgramMemoryRepository : IUserToProgramRepository
    {
        private Dictionary<User, TrainingProgram> userToProgram = [];

        public Task AddProgramToUser(User user, TrainingProgram program)
        {
            userToProgram.Add(user, program);
            return Task.CompletedTask;
        }

        public Task<TrainingProgram> GetUserProgram(User user)
        {
            return Task.FromResult(userToProgram[user]);
        }

        public Task<bool> IsUserHasProgram(User user)
        {
            return Task.FromResult(userToProgram.ContainsKey(user));
        }

        public Task RemoveProgramFromUser(User user)
        {
            userToProgram.Remove(user);
            return Task.CompletedTask;
        }
    }
}
