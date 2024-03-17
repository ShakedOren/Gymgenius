using Gymgenius.bo;
using GymGenius.BO;
using GymGenius.DAL;

namespace GymGenius.BLL
{
    public class UserToProgramManagment
    {
        private readonly IUserToProgramRepository _userToProgramRepository;

        public UserToProgramManagment(IUserToProgramRepository userToProgramRepository)
        {
            _userToProgramRepository = userToProgramRepository;
        }

        public void AddProgramToUser(User user, TrainingProgram program)
        {
            _userToProgramRepository.AddProgramToUser(user, program);
        }

        public TrainingProgram GetUserProgram(User user)
        {

            return _userToProgramRepository.GetUserProgram(user);
        }

        public void RemoveProgramFromUser(User user)
        {
            _userToProgramRepository.RemoveProgramFromUser(user);
        }

        public bool IsUserHaveProgram(User user)
        {
            return _userToProgramRepository.IsUserHaveProgram(user);
        }
    }
}
