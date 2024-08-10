using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public interface IUserToProgramRepository
    {
        Task AddProgramToUser(User user, TrainingProgram program);
        Task RemoveProgramFromUser(User user);
        Task<TrainingProgram?> GetUserProgram(User user);
        Task<bool> IsUserHasProgram(User user);
    }
}
