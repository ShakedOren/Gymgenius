using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;

namespace GymGenius.BLL
{
    public class UserToProgramManagment
    {
        private readonly IUserToProgramRepository _userToProgramRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITrainingProgramRepository _trainingProgramRepository;
        public UserToProgramManagment(IUserToProgramRepository userToProgramRepository, IUserRepository userRepository, ITrainingProgramRepository rainingProgramRepository)
        {
            _userToProgramRepository = userToProgramRepository;
            _userRepository = userRepository;
            _trainingProgramRepository = rainingProgramRepository;
        }

        public void AddProgramToUser(int userId, int programId)
        {
            User user = _userRepository.GetUserById(userId);
            TrainingProgram program = _trainingProgramRepository.GetTrainingProgramById(programId);
            if (_userToProgramRepository.IsUserHaveProgram(user))
            {
                throw new Exception("User already have program.");
            }

            _userToProgramRepository.AddProgramToUser(user, program);
        }

        public TrainingProgram GetUserProgram(int userId)
        {
            return _userToProgramRepository.GetUserProgram(_userRepository.GetUserById(userId));
        }

        public void RemoveProgramFromUser(int userId)
        {
            User user = _userRepository.GetUserById(userId);
            if (!_userToProgramRepository.IsUserHaveProgram(user))
            {
                throw new Exception("No program found for user.");
            }

            _userToProgramRepository.RemoveProgramFromUser(user);
        }

        public bool IsUserHaveProgram(User user)
        {
            return _userToProgramRepository.IsUserHaveProgram(user);
        }
    }
}
