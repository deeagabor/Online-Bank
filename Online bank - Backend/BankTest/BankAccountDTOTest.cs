using Bank.API;
using Bank.API.Data.Models;
using Bank.API.Repository.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest
{
    [TestClass]
    public class BankAccountDTOTest
    {
        [TestMethod]
        public void AccountNotNullTest()
        {
            var account = new AccountDTO()
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
            var account = new AccountDTO()
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
            var account = new AccountDTO()
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
            var account = new AccountDTO()
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
        public void NumberOfDepositsTest()
        {
            var account = new AccountDTO()
            {
                Id = 2,
                FirstName = "Carmen",
                LastName = "Pavel",
                Sum = 3200,
                Deposits = new List<DepositDTO>()
                    {
                        new DepositDTO()
                        {
                            Id = 3,
                            Name = "Deposit 1",
                            DepositSum = 2200
                        },

                        new DepositDTO()
                        {
                            Id = 4,
                            Name = "Deposit 2",
                            DepositSum = 1000
                        }
                    }
            };

            var expected = 2;

            Assert.AreEqual(expected, account.NumberOfDeposits);
        }

        [TestMethod]
        public void UserIdTest()
        {
            var account = new AccountDTO()
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
