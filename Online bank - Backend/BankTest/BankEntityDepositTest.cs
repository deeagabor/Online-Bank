using Bank.API;
using Bank.API.Repository.Entities;

namespace BankTest
{
    [TestClass]
    public class BankEntityDepositTest
    {
        [TestMethod]
        public void DepositNotNullTest()
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "Nume Prenume",
                DepositSum = 2800,
                Period = 6,
                AccountId = 2
            };

            Assert.IsNotNull(deposit);
        }

        [TestMethod]
        public void IdTest()
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "Nume Prenume",
                DepositSum = 2800,
                Period = 6,
                AccountId = 2
            };

            var expected = 1;
            Assert.AreEqual(expected, deposit.Id);
        }

        [TestMethod]
        public void NameTest()
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "Nume Prenume",
                DepositSum = 2800,
                Period = 6,
                AccountId = 2
            };

            var expected = "Nume Prenume";

            Assert.AreEqual(expected, deposit.Name);
        }

        [TestMethod]
        public void PeriodTest()
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "Nume Prenume",
                DepositSum = 2800,
                Period = 6,
                AccountId = 2
            };

            var expected = 6;

            Assert.AreEqual(expected, deposit.Period);
        }

        [TestMethod]
        public void DepositSumTest() 
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "Nume Prenume",
                DepositSum = 2800,
                Period = 6,
                AccountId = 2
            };

            var expected = 2800;

            Assert.AreEqual(expected, deposit.DepositSum);  
        }

        [TestMethod]
        public void AccountIdTest()
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "Nume Prenume",
                DepositSum = 2800,
                Period = 6,
                AccountId = 2
            };

            var expected = 2;

            Assert.AreEqual(expected, deposit.AccountId);
        }

        [TestMethod]
        public void NameNullValidTest()
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "",
                DepositSum = 2800,
                Period = 6,
                AccountId = 2
            };

            var expected = true;

            if (string.IsNullOrEmpty(deposit.Name))
                expected = false;

            Assert.IsFalse(expected);
        }


        [TestMethod]
        public void NameLengthValidTest()
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "testtesttesttesttesttesttesttesttesttesttesttesttesttest",
                DepositSum = 2800,
                Period = 6,
                AccountId = 2
            };

            var expected = true;

            if (deposit.Name.Length > 50)
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void PeriodValidTest()
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "Nume Prenume",
                DepositSum = 2800,
                Period = 2,
                AccountId = 2
            };

            var expected = true;

            if (deposit.Period != 1 || deposit.Period != 6 || deposit.Period != 12)
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void SumLowerValidTest()
        {
            var deposit = new Deposit()
            {
                Id = 1,
                Name = "Nume Prenume",
                DepositSum = -2800,
                Period = 6,
                AccountId = 2
            };

            var expected = true;

            if (deposit.DepositSum < 0 || deposit.DepositSum > float.MaxValue)
                expected = false;

            Assert.IsFalse(expected);
        }
    }
}
