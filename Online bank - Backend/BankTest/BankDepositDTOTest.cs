using Bank.API.Data.Models;

namespace BankTest
{
    [TestClass]
    public class BankDepositDTOTest
    {

        [TestMethod]
        public void DepositNotNullTest()
        {
            var deposit = new DepositDTO()
            {
                Id = 1,
                Name = "Nume Prenume",
                Period = 6,
                DepositSum = 2800
            };

            Assert.IsNotNull(deposit);
        }

        [TestMethod]
        public void IdTest()
        {
            var deposit = new DepositDTO()
            {
                Id = 1,
                Name = "Nume Prenume",
                Period = 6,
                DepositSum = 2800
            };

            var expected = 1;
            Assert.AreEqual(expected, deposit.Id);
        }

        [TestMethod]
        public void NameTest()
        {
            var deposit = new DepositDTO()
            {
                Id = 1,
                Name = "Nume Prenume",
                Period = 6,
                DepositSum = 2800
            };

            var expected = "Nume Prenume";

            Assert.AreEqual(expected, deposit.Name);
        }

        [TestMethod]
        public void PeriodTest()
        {
            var deposit = new DepositDTO()
            {
                Id = 1,
                Name = "Nume Prenume",
                DepositSum = 2800,
                Period = 6,
            };

            var expected = 6;

            Assert.AreEqual(expected, deposit.Period);
        }

        [TestMethod]
        public void DepositSumTest()
        {
            var deposit = new DepositDTO()
            {
                Id = 1,
                Name = "Nume Prenume",
                Period = 6,
                DepositSum = 2800
            };

            var expected = 2800;

            Assert.AreEqual(expected, deposit.DepositSum);
        }
    }
}
