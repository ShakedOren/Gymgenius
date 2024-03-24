using Gymgenius.bo;
using Gymgenius.dal;

namespace Gymgenius.Tests
{
    [TestClass]
    public class ExerciseTest
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseTest()
        {
            _exerciseRepository = Helper.GetRequiredService<IExerciseRepository>();
        }

        [TestMethod]
        public void TestAddExercise()
        {
            Exercise e1 = new Exercise("e1");
            Exercise e2 = new Exercise("e2");
            Exercise e3 = new Exercise("e3");

            CollectionAssert.AreEqual(new List<Exercise>(), _exerciseRepository.GetAllExercises());
            _exerciseRepository.AddExercise(e1);
            CollectionAssert.AreEqual(new List<Exercise>() { e1 }, _exerciseRepository.GetAllExercises());
            _exerciseRepository.AddExercise(e2);
            CollectionAssert.AreEqual(new List<Exercise>() { e1, e2}, _exerciseRepository.GetAllExercises());
            _exerciseRepository.AddExercise(e3);
            CollectionAssert.AreEqual(new List<Exercise>() { e1, e2, e3}, _exerciseRepository.GetAllExercises());
        }

        [TestMethod]
        public void TestIsExerciseExists()
        {
            Exercise e1 = new Exercise("e1");
            Exercise e2 = new Exercise("e2");

            Assert.IsFalse(_exerciseRepository.IsExerciseExists("e1"));
            _exerciseRepository.AddExercise(e1);
            Assert.IsTrue(_exerciseRepository.IsExerciseExists("e1"));
            Assert.IsFalse(_exerciseRepository.IsExerciseExists("e2"));
            _exerciseRepository.AddExercise(e2);
            Assert.IsTrue(_exerciseRepository.IsExerciseExists("e1"));
            Assert.IsTrue(_exerciseRepository.IsExerciseExists("e2"));
        }

        [TestMethod]
        public void TestDeleteExercise()
        {
            Exercise e1 = new Exercise("e1");
            Exercise e2 = new Exercise("e2");

            _exerciseRepository.AddExercise(e1);
            _exerciseRepository.AddExercise(e2);
            CollectionAssert.AreEqual(new List<Exercise>() { e1, e2 }, _exerciseRepository.GetAllExercises());
            _exerciseRepository.DeleteExercise("e1");
            CollectionAssert.AreEqual(new List<Exercise>() { e2 }, _exerciseRepository.GetAllExercises());
            _exerciseRepository.DeleteExercise("e2");
            CollectionAssert.AreEqual(new List<Exercise>(), _exerciseRepository.GetAllExercises());
            Assert.ThrowsException<Exception>(() => _exerciseRepository.DeleteExercise("e3"));

        }

        [TestMethod]
        public void TestGetAllUsers()
        {
            Exercise e1 = new Exercise("e1");
            Exercise e2 = new Exercise("e2");
            Exercise e3 = new Exercise("e3");


            CollectionAssert.AreEqual(new List<Exercise>(), _exerciseRepository.GetAllExercises());
            _exerciseRepository.AddExercise(e1);
            CollectionAssert.AreEqual(new List<Exercise>() { e1 }, _exerciseRepository.GetAllExercises());
            _exerciseRepository.AddExercise(e2);
            CollectionAssert.AreEqual(new List<Exercise>() { e1, e2 }, _exerciseRepository.GetAllExercises());
            _exerciseRepository.AddExercise(e3);
            CollectionAssert.AreEqual(new List<Exercise>() { e1, e2, e3 }, _exerciseRepository.GetAllExercises());

            _exerciseRepository.DeleteExercise("e3");
            CollectionAssert.AreEqual(new List<Exercise>() { e1, e2 }, _exerciseRepository.GetAllExercises());
            _exerciseRepository.DeleteExercise("e2");
            CollectionAssert.AreEqual(new List<Exercise>() { e1 }, _exerciseRepository.GetAllExercises());
            _exerciseRepository.DeleteExercise("e1");
            CollectionAssert.AreEqual(new List<Exercise>(), _exerciseRepository.GetAllExercises());
        }
    }
}