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

        public async Task AddProgramToUser(string userName, string programName)
        {
            var user = await _userRepository.GetUserByUsername(userName);
            var program = await _trainingProgramRepository.GetTrainingProgramByName(programName);
            if (await _userToProgramRepository.IsUserHasProgram(user))
            {
                throw new Exception("User already have program.");
            }

            await _userToProgramRepository.AddProgramToUser(user, program);
        }

        public async Task<TrainingProgram?> GetUserProgram(string userName)
        {
            return await _userToProgramRepository.GetUserProgram(await _userRepository.GetUserByUsername(userName));
        }

        public async Task RemoveProgramFromUser(string userName)
        {
            var user = await _userRepository.GetUserByUsername(userName);
            if (!await _userToProgramRepository.IsUserHasProgram(user))
            {
                throw new Exception("No program found for user.");
            }

            await _userToProgramRepository.RemoveProgramFromUser(user);
        }

        public async Task<bool> IsUserHasProgram(string userName)
        {
            var user = await _userRepository.GetUserByUsername(userName);
            return await _userToProgramRepository.IsUserHasProgram(user);
        }
    }
}
