using NUnit.Framework;
using DataBase;
using DataBase.UserCommands;
using UnitTests.Support;

namespace UnitTests
{
    [TestFixture]
    internal class DBUserUserTests
    {
        static DBSupport sup = DBSupport.GetDBSupport();
        
        public void Register_Sucess()
        {
            Register reg = new();
            string awnser = reg.RegisterUser("testuser", "testpw");

            Assert.AreEqual("Register Successful!", awnser);
            sup.ResetUsers();
        }

        [Test]
        public void Register_NameTaken()
        {
            Register reg = new();
            reg.RegisterUser("testuser", "testpw");
            string awnser = reg.RegisterUser("testuser", "testpw");

            Assert.AreEqual("User already Exists", awnser);
            sup.ResetUsers();
        }

        [Test]
        public void SelectUser_Success()
        {
            UserData user = UserData.GetCheckUserData();
            Register reg = new();
            reg.RegisterUser("testuser", "testpw");
            string awnser = user.SelectUserByUSername("testuser");

            Assert.AreEqual("User Exists", awnser);
            sup.ResetUsers();
        }

        [Test]
        public void SelectUser_Faliure()
        {
            UserData user = UserData.GetCheckUserData();
            string awnser = user.SelectUserByUSername("failuser");

            Assert.IsNull(awnser);
            sup.ResetUsers();
        }

        [Test]
        public void CheckPassword_Sucess()
        {
            UserData user = UserData.GetCheckUserData();
            Register reg = new();
            reg.RegisterUser("testuser", "testpw");
            string awnser = user.CheckPassword("testuser","testpw");

            Assert.AreEqual("Correct Password submitted", awnser);
            sup.ResetUsers();
        }

        [Test]
        public void CheckPassword_Faliure()
        {
            UserData user = UserData.GetCheckUserData();
            string awnser = user.CheckPassword("testuser", "failpw");

            Assert.IsNull(awnser);
            sup.ResetUsers();
        }

        [Test]
        public void GetCoins_Success()
        {
            UserData user = UserData.GetCheckUserData();
            Register reg = new();
            reg.RegisterUser("testuser", "testpw");

            Assert.AreEqual(20, user.GetCoins("testuser"));
            sup.ResetUsers();
        }

        [Test]
        public void HasCoins_Success()
        {
            UserData user = UserData.GetCheckUserData();
            Register reg = new();
            reg.RegisterUser("testuser", "testpw");

            Assert.IsTrue(user.HasCoins("testuser", 5));
            sup.ResetUsers();
        }

        [Test]
        public void HasCoins_Failure()
        {
            UserData user = UserData.GetCheckUserData();
            Register reg = new();
            reg.RegisterUser("testuser", "testpw");

            Assert.IsFalse(user.HasCoins("testuser", 21));
            sup.ResetUsers();
        }

        [Test]
        public void SpendCoins_Success()
        {
            UserData user = UserData.GetCheckUserData();
            Register reg = new();
            reg.RegisterUser("testuser", "testpw");
            string awnser = user.SpendCoins("testuser", 5);

            Assert.AreEqual("Coins Spent", awnser);
            sup.ResetUsers();
        }

        [Test]
        public void SpendCoins_Failure()
        {
            UserData user = UserData.GetCheckUserData();
            Register reg = new();
            reg.RegisterUser("testuser", "testpw");
            string awnser = user.SpendCoins("testuser", 21);

            Assert.AreEqual("Not enough Coins", awnser);
            sup.ResetUsers();
        }
    }
}
