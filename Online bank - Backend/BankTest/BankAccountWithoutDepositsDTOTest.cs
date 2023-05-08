using Bank.API.Data.Models;
using Bank.API.Repository.Entities;

namespace BankTest
{
    [TestClass]
    public class BankAccountWithoutDepositsDTOTest
    {
        [TestMethod]
        public void AccountNotNullTest()
        {
            var account = new AccountWithoutDepositsDTO()
            {
                Id = 3,
                FirstName = "First Name",
                LastName = "Last Name",
                Sum = 2200
            };

            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void IdTest()
        {
            var account = new AccountWithoutDepositsDTO()
            {
                Id = 3,
                FirstName = "First Name",
                LastName = "Last Name",
                Sum = -2200
            };

            var expected = 3;
            Assert.AreEqual(expected, account.Id);
        }

        [TestMethod]
        public void OwnerTest()
        {
            var account = new AccountWithoutDepositsDTO()
            {
                Id = 3,
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
            var account = new AccountWithoutDepositsDTO()
            {
                Id = 3,
                FirstName = "First Name",
                LastName = "Last Name",
                Sum = 2200
            };

            var expected = 2200;

            Assert.AreEqual(expected, account.Sum);
        }

        [TestMethod]
        public void UserIdTest()
        {
            var account = new AccountWithoutDepositsDTO()
            {
                Id = 3,
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
