using Bank.API.Data.Models;

namespace BankTest
{
    [TestClass]
    public class BankUserDTOTest
    {
        [TestMethod]
        public void DepositNotNullTest()
        {
            var user = new UserDTO()
            {
                Id = 1,
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
        public void IdTest()
        {
            var user = new UserDTO()
            {
                Id = 1,
                FirstName = "Ioana",
                LastName = "Gabor",
                Email = "ioanagabor@gmail.com",
                Username = "ioanagabor",
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                Admin = false
            };

            var expected = 1;
            Assert.AreEqual(expected, user.Id);
        }


        [TestMethod]
        public void OwnerTest()
        {
            var user = new UserDTO()
            {
                Id = 1,
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
            var user = new UserDTO()
            {
                Id = 1,
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
            var user = new UserDTO()
            {
                Id = 1,
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
            var user = new UserDTO()
            {
                Id = 1,
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
            var user = new UserDTO()
            {
                Id = 1,
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
    }
}
