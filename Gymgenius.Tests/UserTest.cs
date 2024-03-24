using Gymgenius.bo;
using Gymgenius.dal;

namespace Gymgenius.Tests
{
    [TestClass]
    public class UserTest
    {
        private readonly IUserRepository _userRepository;
        public UserTest()
        {
            _userRepository = Helper.GetRequiredService<IUserRepository>();
        }

        [TestMethod]
        public void TestAddUser()
        {
            User u1 = new User("0", "F1", "L1", 10, "aaa1@gmail.com", false);
            User u2 = new User("1", "F2", "L2", 10, "aaa2@gmail.com", false);
            User u3 = new User("2", "F3", "L3", 10, "aaa3@gmail.com", false);

            CollectionAssert.AreEqual(new List<User>(), _userRepository.GetAllUsers().Result);
            _userRepository.AddUser(u1);
            CollectionAssert.AreEqual(new List<User>() { u1 }, _userRepository.GetAllUsers().Result);
            _userRepository.AddUser(u2);
            CollectionAssert.AreEqual(new List<User>() { u1, u2}, _userRepository.GetAllUsers().Result);
            _userRepository.AddUser(u3);
            CollectionAssert.AreEqual(new List<User>() { u1, u2, u3}, _userRepository.GetAllUsers().Result);
        }

        [TestMethod]
        public void TestIsUserExists()
        {
            User u1 = new User("0", "F1", "L1", 10, "aaa1@gmail.com", false);
            User u2 = new User("1", "F2", "L2", 10, "aaa2@gmail.com", false);

            Assert.IsFalse(_userRepository.IsUserExists("0").Result);
            _userRepository.AddUser(u1);
            Assert.IsTrue(_userRepository.IsUserExists("0").Result);
            Assert.IsFalse(_userRepository.IsUserExists("1").Result);
            _userRepository.AddUser(u2);
            Assert.IsTrue(_userRepository.IsUserExists("0").Result);
            Assert.IsTrue(_userRepository.IsUserExists("1").Result);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            User u1 = new User("0", "F1", "L1", 10, "aaa1@gmail.com", false);
            User u2 = new User("1", "F2", "L2", 10, "aaa2@gmail.com", false);

            _userRepository.AddUser(u1);
            _userRepository.AddUser(u2);
            CollectionAssert.AreEqual(new List<User>() { u1, u2 }, _userRepository.GetAllUsers().Result);
            _userRepository.DeleteUser("0");
            CollectionAssert.AreEqual(new List<User>() { u2 }, _userRepository.GetAllUsers().Result);
            _userRepository.DeleteUser("1");
            CollectionAssert.AreEqual(new List<User>(), _userRepository.GetAllUsers().Result);
            Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.DeleteUser("3"));
        }

        [TestMethod]
        public void TestGetAllUsers()
        {
            User u1 = new User("0", "F1", "L1", 10, "aaa1@gmail.com", false);
            User u2 = new User("1", "F2", "L2", 10, "aaa2@gmail.com", false);
            User u3 = new User("2", "F3", "L3", 10, "aaa3@gmail.com", false);

            CollectionAssert.AreEqual(new List<User>(), _userRepository.GetAllUsers().Result);
            _userRepository.AddUser(u1);
            CollectionAssert.AreEqual(new List<User>() { u1 }, _userRepository.GetAllUsers().Result);
            _userRepository.AddUser(u2);
            CollectionAssert.AreEqual(new List<User>() { u1, u2 }, _userRepository.GetAllUsers().Result);
            _userRepository.AddUser(u3);
            CollectionAssert.AreEqual(new List<User>() { u1, u2, u3 }, _userRepository.GetAllUsers().Result);
            _userRepository.DeleteUser("2");
            CollectionAssert.AreEqual(new List<User>() { u1, u2 }, _userRepository.GetAllUsers().Result);
            _userRepository.DeleteUser("1");
            CollectionAssert.AreEqual(new List<User>() { u1 }, _userRepository.GetAllUsers().Result);
            _userRepository.DeleteUser("0");
            CollectionAssert.AreEqual(new List<User>(), _userRepository.GetAllUsers().Result);
        }
    }
}