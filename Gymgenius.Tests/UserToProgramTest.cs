using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;

namespace Gymgenius.Tests
{
    [TestClass]
    public class UserToProgramTest
    {
        private readonly IUserToProgramRepository _userToProgramRepository;
        public UserToProgramTest()
        {
            _userToProgramRepository= Helper.GetRequiredService<IUserToProgramRepository>();
        }

        [TestMethod]
        public void TestAddProgramToUser()
        {
            User u1 = new User("0", "F1", "L1", 10, "aaa1@gmail.com", false);
            TrainingProgram t1 = new TrainingProgram("1");
            TrainingProgram t2 = new TrainingProgram("2");

            _userToProgramRepository.AddProgramToUser(u1, t1);
            Assert.AreEqual(t1, _userToProgramRepository.GetUserProgram(u1).Result);
            Assert.ThrowsException<ArgumentException>(() => _userToProgramRepository.AddProgramToUser(u1, t2));
        }

        [TestMethod]
        public void TestRemoveProgramFromUser()
        {
            User u1 = new User("0", "F1", "L1", 10, "aaa1@gmail.com", false);
            TrainingProgram t1 = new TrainingProgram("1");
            TrainingProgram t2 = new TrainingProgram("2");

            _userToProgramRepository.AddProgramToUser(u1, t1);
            Assert.AreEqual(t1, _userToProgramRepository.GetUserProgram(u1).Result);
            _userToProgramRepository.RemoveProgramFromUser(u1);
            Assert.ThrowsException<KeyNotFoundException>(() => _userToProgramRepository.GetUserProgram(u1));
        }

        [TestMethod]
        public void TestIsUserHaveProgram()
        {
            User u1 = new User("0", "F1", "L1", 10, "aaa1@gmail.com", false);
            TrainingProgram t1 = new TrainingProgram("1");
            
            Assert.IsFalse(_userToProgramRepository.IsUserHaveProgram(u1).Result);
            _userToProgramRepository.AddProgramToUser(u1, t1);
            Assert.IsTrue(_userToProgramRepository.IsUserHaveProgram(u1).Result);
            _userToProgramRepository.RemoveProgramFromUser(u1);
            Assert.IsFalse(_userToProgramRepository.IsUserHaveProgram(u1).Result);
        }


        [TestMethod]
        public void GetUserProgram()
        {
            User u1 = new User("0", "F1", "L1", 10, "aaa1@gmail.com", false);
            User u2 = new User("1", "F2", "L2", 10, "aaa2@gmail.com", false);
            TrainingProgram t1 = new TrainingProgram("1");

            _userToProgramRepository.AddProgramToUser(u1, t1);
            Assert.AreEqual(t1, _userToProgramRepository.GetUserProgram(u1).Result);
            Assert.ThrowsException<KeyNotFoundException>(() => _userToProgramRepository.GetUserProgram(u2));
        }
    }
}