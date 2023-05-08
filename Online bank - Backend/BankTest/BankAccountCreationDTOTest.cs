using Bank.API.Data.Models;
using Bank.API.Repository.Entities;

namespace BankTest
{
    [TestClass]
    public class BankAccountCreationDTOTest
    {
        [TestMethod]
        public void AccountNotNullTest()
        {
            var account = new AccountCreationDTO()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                Sum = 2200
            };

            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void OwnerTest()
        {
            var account = new AccountCreationDTO()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                Sum = 2200
            };

            var expected1 = "First Name";
            var expected2 = "Last Name";

            Assert.AreEqual(expected1, account.FirstName);
            Assert.AreEqual(expected2, account.LastName);
        }

        [TestMethod]
        public void SumTest()
        {
            var account = new AccountCreationDTO()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                Sum = 2200
            };

            var expected = 2200;

            Assert.AreEqual(expected, account.Sum);
        }

        [TestMethod]
        public void OwnerNullValidTest()
        {
            var account = new AccountCreationDTO()
            {
                FirstName = "",
                LastName = "",
                Sum = 2200
            };

            var expected = true;

            if (string.IsNullOrEmpty(account.FirstName) && string.IsNullOrEmpty(account.LastName))
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void OwnerLengthValidTest()
        {
            var account = new AccountCreationDTO()
            {
                FirstName = "testtesttesttesttesttesttesttesttesttesttesttesttesttest",
                LastName = "testtesttesttesttesttesttesttesttesttesttesttesttesttest",
                Sum = 2200
            };

            var expected = true;

            if (account.LastName.Length > 50 && account.FirstName.Length > 50)
                expected = false;

            Assert.IsFalse(expected);
        }


        [TestMethod]
        public void SumLowerValidTest()
        {
            var account = new AccountCreationDTO()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                Sum = -2200
            };

            var expected = true;

            if (account.Sum < 0 || account.Sum > float.MaxValue)
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void UserIdTest()
        {
            var account = new AccountCreationDTO()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                Sum = -2200,
                UserId = 2
            };

            var expected = 2;

            Assert.AreEqual(expected, account.UserId);
        }
    }
}
