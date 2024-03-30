

using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;

namespace Gymgenius.Tests
{
    [TestClass]
    public class TrainingProgramTest
    {
        private readonly ITrainingProgramRepository _trainingProgramRepository;
        public TrainingProgramTest()
        {
            _trainingProgramRepository = Helper.GetRequiredService<ITrainingProgramRepository>();
        }

        [TestMethod]
        public void TestAddTrainingProgram()
        {
            TrainingProgram t1 = new TrainingProgram("1");
            TrainingProgram t2 = new TrainingProgram("2");
            TrainingProgram t3 = new TrainingProgram("3");

            CollectionAssert.AreEqual(new List<TrainingProgram>(), _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.AddTrainingProgram(t1);
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1 }, _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.AddTrainingProgram(t2);
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1, t2 }, _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.AddTrainingProgram(t3);
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1, t2, t3 }, _trainingProgramRepository.GetAllTrainingPrograms().Result);
        }

        [TestMethod]
        public void TestIsTrainingProgramExists()
        {
            TrainingProgram t1 = new TrainingProgram("1");
            TrainingProgram t2 = new TrainingProgram("2");

            Assert.IsFalse(_trainingProgramRepository.IsTrainingProgramExists("1").Result);
            _trainingProgramRepository.AddTrainingProgram(t1);
            Assert.IsTrue(_trainingProgramRepository.IsTrainingProgramExists("1").Result);
            Assert.IsFalse(_trainingProgramRepository.IsTrainingProgramExists("2").Result);
            _trainingProgramRepository.AddTrainingProgram(t2);
            Assert.IsTrue(_trainingProgramRepository.IsTrainingProgramExists("1").Result);
            Assert.IsTrue(_trainingProgramRepository.IsTrainingProgramExists("2").Result);
        }

        [TestMethod]
        public void TestDeleteTrainingProgram()
        {
            TrainingProgram t1 = new TrainingProgram("1");
            TrainingProgram t2 = new TrainingProgram("2");
            
            _trainingProgramRepository.AddTrainingProgram(t1);
            _trainingProgramRepository.AddTrainingProgram(t2);
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1, t2 }, _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.DeleteTrainingProgram("2");
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1}, _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.DeleteTrainingProgram("1");
            CollectionAssert.AreEqual(new List<TrainingProgram>(), _trainingProgramRepository.GetAllTrainingPrograms().Result);
            Assert.ThrowsExceptionAsync<Exception>(() => _trainingProgramRepository.DeleteTrainingProgram("3"));
        }

        [TestMethod]
        public void TestGetAllTrainingPrograms()
        {
            TrainingProgram t1 = new TrainingProgram("1");
            TrainingProgram t2 = new TrainingProgram("2");
            TrainingProgram t3 = new TrainingProgram("3");

            CollectionAssert.AreEqual(new List<TrainingProgram>(), _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.AddTrainingProgram(t1);
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1 }, _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.AddTrainingProgram(t2);
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1, t2 }, _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.AddTrainingProgram(t3);
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1, t2, t3 }, _trainingProgramRepository.GetAllTrainingPrograms().Result);

            _trainingProgramRepository.DeleteTrainingProgram("3");
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1, t2 }, _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.DeleteTrainingProgram("2");
            CollectionAssert.AreEqual(new List<TrainingProgram>() { t1 }, _trainingProgramRepository.GetAllTrainingPrograms().Result);
            _trainingProgramRepository.DeleteTrainingProgram("1");
            CollectionAssert.AreEqual(new List<TrainingProgram>(), _trainingProgramRepository.GetAllTrainingPrograms().Result);
        }
    }
}