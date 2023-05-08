

using Bank.API.Data.Models;

namespace BankTest
{
    [TestClass]
    public class BankLoginRequestTest
    {
        [TestMethod]
        public void DepositNotNullTest()
        {
            var user = new LoginRequest()
            {
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f"
            };

            Assert.IsNotNull(user);
        }


        [TestMethod]
        public void UsernameTest()
        {
            var user = new LoginRequest()
            {
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f"
            };

            var expected = "ioanagabor";
            Assert.AreEqual(expected, user.Username);
        }

        [TestMethod]
        public void PasswordTest()
        {
            var user = new LoginRequest()
            {
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f"
            };

            var expected = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f";
            Assert.AreEqual(expected, user.Password);
        }



        [TestMethod]
        public void UserDataNullValidTest()
        {
            var user = new LoginRequest()
            {
                Username = "",
                Password = ""
            };

            var expected = true;

            if (string.IsNullOrEmpty(user.Username) && string.IsNullOrEmpty(user.Password))
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void UserDataLengthValidTest()
        {
            var user = new LoginRequest()
            {
                Username = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Eligendi, enim totam! Dolorum autem totam sunt assumenda nam sequi accusantium, quidem consectetur suscipit laboriosam unde placeat adipisci ad reprehenderit! Nostrum error vel odit officiis, dolore nisi repellendus iure unde libero? Laborum minima quia impedit harum eveniet quidem ab magnam, ea in dolorum dolores necessitatibus molestiae, earum pariatur, repellat esse. Aspernatur, provident?",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f"
            };

            var expected = true;

            if (user.Username.Length > 50)
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void PasswordLenghtValidTest()
        {
            var user = new LoginRequest()
            {
                Username = "ioanagabor",
                Password = "ef7"
            };

            var expected = true;

            if (user.Password.Length < 8)
                expected = false;

            Assert.IsFalse(expected);
        }
    }
}
