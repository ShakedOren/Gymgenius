using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;

namespace Gymgenius.Tests
{
    [TestClass]
    public class ExerciseToProgramTest
    {
        private readonly IExerciseToProgramRepository _exerciseToProgramRepository;
        public ExerciseToProgramTest()
        {
            _exerciseToProgramRepository = Helper.GetRequiredService<IExerciseToProgramRepository>();
        }

        [TestMethod]
        public void TestAddExerciseToProgram()
        {
            TrainingProgram t1 = new TrainingProgram();
            Exercise e1 = new Exercise("e1");
            Exercise e2 = new Exercise("e2");

            CollectionAssert.AreEqual(new List<Exercise>(), _exerciseToProgramRepository.GetAllExerciseOfProgram(t1).Result);
            _exerciseToProgramRepository.AddExerciseToProgram(e1, t1);
            CollectionAssert.AreEqual(new List<Exercise>() { e1 }, _exerciseToProgramRepository.GetAllExerciseOfProgram(t1).Result);
            _exerciseToProgramRepository.AddExerciseToProgram(e2, t1);
            CollectionAssert.AreEqual(new List<Exercise>() { e1, e2 }, _exerciseToProgramRepository.GetAllExerciseOfProgram(t1).Result);
        }

        [TestMethod]
        public void TestDeleteExerciseFromProgram()
        {
            TrainingProgram t1 = new TrainingProgram() { Name = "sa", Description = "ASD"};
            Exercise e1 = new Exercise("e1");
            Exercise e2 = new Exercise("e2");

            _exerciseToProgramRepository.AddExerciseToProgram(e1, t1);
            _exerciseToProgramRepository.AddExerciseToProgram(e2, t1);
            CollectionAssert.AreEqual(new List<Exercise>() { e1, e2 }, _exerciseToProgramRepository.GetAllExerciseOfProgram(t1).Result);
            _exerciseToProgramRepository.DeleteExerciseFromProgram(e2, t1);
            CollectionAssert.AreEqual(new List<Exercise>() { e1 }, _exerciseToProgramRepository.GetAllExerciseOfProgram(t1).Result);
            _exerciseToProgramRepository.DeleteExerciseFromProgram(e1, t1);
            CollectionAssert.AreEqual(new List<Exercise>(), _exerciseToProgramRepository.GetAllExerciseOfProgram(t1).Result);
            Assert.ThrowsException<Exception>(() => _exerciseToProgramRepository.DeleteExerciseFromProgram(e1, t1));
        }

        [TestMethod]
        public void TestIsExerciseExistsInProgram()
        {
            TrainingProgram t1 = new TrainingProgram() { Description = "asdsad", Name = "asdsa"};
            Exercise e1 = new Exercise("e1");
            Exercise e2 = new Exercise("e2");
            
            Assert.IsFalse(_exerciseToProgramRepository.IsExerciseExistsInProgram(e1, t1).Result);
            _exerciseToProgramRepository.AddExerciseToProgram(e1, t1);
            Assert.IsTrue(_exerciseToProgramRepository.IsExerciseExistsInProgram(e1, t1).Result);
            Assert.IsFalse(_exerciseToProgramRepository.IsExerciseExistsInProgram(e2, t1).Result);
            _exerciseToProgramRepository.AddExerciseToProgram(e2, t1);
            Assert.IsTrue(_exerciseToProgramRepository.IsExerciseExistsInProgram(e1, t1).Result);
            Assert.IsTrue(_exerciseToProgramRepository.IsExerciseExistsInProgram(e2, t1).Result);
        }
    }
}