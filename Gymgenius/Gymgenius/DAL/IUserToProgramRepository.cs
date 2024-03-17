using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public interface IUserToProgramRepository
    {
        void AddProgramToUser(User user, TrainingProgram program);
        void RemoveProgramFromUser(User user);
        TrainingProgram GetUserProgram(User user);
        bool IsUserHaveProgram(User user);
    }
}
