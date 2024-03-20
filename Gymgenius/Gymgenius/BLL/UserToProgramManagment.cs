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

        public async Task AddProgramToUser(int userId, int programId)
        {
            var user = await _userRepository.GetUserById(userId);
            var program = await _trainingProgramRepository.GetTrainingProgramById(programId);
            if (await _userToProgramRepository.IsUserHaveProgram(user))
            {
                throw new Exception("User already have program.");
            }

            await _userToProgramRepository.AddProgramToUser(user, program);
        }

        public async Task<TrainingProgram> GetUserProgram(int userId)
        {
            return await _userToProgramRepository.GetUserProgram(await _userRepository.GetUserById(userId));
        }

        public async Task RemoveProgramFromUser(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (!await _userToProgramRepository.IsUserHaveProgram(user))
            {
                throw new Exception("No program found for user.");
            }

            await _userToProgramRepository.RemoveProgramFromUser(user);
        }

        public async Task<bool> IsUserHaveProgram(User user)
        {
            return await _userToProgramRepository.IsUserHaveProgram(user);
        }
    }
}
