using Bank.API.Data.Models;
using Bank.API.Repository.Entities;

namespace BankTest
{
    [TestClass]
    public class BankUserCreationDTOTest
    {
        [TestMethod]
        public void DepositNotNullTest()
        {
            var user = new UserCreationDTO()
            {
                FirstName = "Ioana",
                LastName = "Gabor",
                Email = "ioanagabor@gmail.com",
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                Admin = false
            };

            Assert.IsNotNull(user);
        }


        [TestMethod]
        public void OwnerTest()
        {
            var user = new UserCreationDTO()
            {
                FirstName = "Ioana",
                LastName = "Gabor",
                Email = "ioanagabor@gmail.com",
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                Admin = false
            };

            var expected1 = "Ioana";
            var expected2 = "Gabor";

            Assert.AreEqual(expected1, user.FirstName);
            Assert.AreEqual(expected2, user.LastName);
        }


        [TestMethod]
        public void EmailTest()
        {
            var user = new UserCreationDTO()
            {
                FirstName = "Ioana",
                LastName = "Gabor",
                Email = "ioanagabor@gmail.com",
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                Admin = false
            };

            var expected = "ioanagabor@gmail.com";
            Assert.AreEqual(expected, user.Email);
        }



        [TestMethod]
        public void UsernameTest()
        {
            var user = new UserCreationDTO()
            {
                FirstName = "Ioana",
                LastName = "Gabor",
                Email = "ioanagabor@gmail.com",
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                Admin = false
            };

            var expected = "ioanagabor";
            Assert.AreEqual(expected, user.Username);
        }

        [TestMethod]
        public void PasswordTest()
        {
            var user = new UserCreationDTO()
            {
                FirstName = "Ioana",
                LastName = "Gabor",
                Email = "ioanagabor@gmail.com",
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                Admin = false
            };

            var expected = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f";
            Assert.AreEqual(expected, user.Password);
        }


        [TestMethod]
        public void AdminTest()
        {
            var user = new UserCreationDTO()
            {
                FirstName = "Ioana",
                LastName = "Gabor",
                Email = "ioanagabor@gmail.com",
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                Admin = false
            };

            var expected = false;
            Assert.AreEqual(expected, user.Admin);
        }

        [TestMethod]
        public void UserDataNullValidTest()
        {
            var user = new UserCreationDTO()
            {
                FirstName = "",
                LastName = "",
                Email = "",
                Username = "",
                Password = "",
                Admin = false
            };

            var expected = true;

            if (string.IsNullOrEmpty(user.FirstName) && string.IsNullOrEmpty(user.LastName) && string.IsNullOrEmpty(user.Username) && string.IsNullOrEmpty(user.Email) && string.IsNullOrEmpty(user.Password))
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void UserDataLengthValidTest()
        {
            var user = new UserCreationDTO()
            {
                FirstName = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Eligendi, enim totam! Dolorum autem totam sunt assumenda nam sequi accusantium, quidem consectetur suscipit laboriosam unde placeat adipisci ad reprehenderit! Nostrum error vel odit officiis, dolore nisi repellendus iure unde libero? Laborum minima quia impedit harum eveniet quidem ab magnam, ea in dolorum dolores necessitatibus molestiae, earum pariatur, repellat esse. Aspernatur, provident?",
                LastName = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Eligendi, enim totam! Dolorum autem totam sunt assumenda nam sequi accusantium, quidem consectetur suscipit laboriosam unde placeat adipisci ad reprehenderit! Nostrum error vel odit officiis, dolore nisi repellendus iure unde libero? Laborum minima quia impedit harum eveniet quidem ab magnam, ea in dolorum dolores necessitatibus molestiae, earum pariatur, repellat esse. Aspernatur, provident?",
                Email = "ioanagabor@gmail.com",
                Username = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Eligendi, enim totam! Dolorum autem totam sunt assumenda nam sequi accusantium, quidem consectetur suscipit laboriosam unde placeat adipisci ad reprehenderit! Nostrum error vel odit officiis, dolore nisi repellendus iure unde libero? Laborum minima quia impedit harum eveniet quidem ab magnam, ea in dolorum dolores necessitatibus molestiae, earum pariatur, repellat esse. Aspernatur, provident?",
                Password = "ef797c8",
                Admin = false
            };

            var expected = true;

            if (user.FirstName.Length > 50 && user.LastName.Length > 50 && user.Username.Length > 50)
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void PasswordLenghtValidTest()
        {
            var user = new UserCreationDTO()
            {
                FirstName = "Ioana",
                LastName = "Gabor",
                Email = "ioanagabor@gmail.com",
                Username = "ioanagabor",
                Password = "ef797",
                Admin = false
            };

            var expected = true;

            if (user.Password.Length < 8)
                expected = false;

            Assert.IsFalse(expected);
        }
    }
}
