using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public class UserToProgramMemoryRepository : IUserToProgramRepository
    {
        private Dictionary<User, TrainingProgram> userToProgram = [];

        public void AddProgramToUser(User user, TrainingProgram program)
        {
            userToProgram.Add(user, program);
        }

        public TrainingProgram GetUserProgram(User user)
        {
            return userToProgram[user];
        }

        public bool IsUserHaveProgram(User user)
        {
            return userToProgram.ContainsKey(user);
        }

        public void RemoveProgramFromUser(User user)
        {
            userToProgram.Remove(user);
        }
    }
}
