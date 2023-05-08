using Bank.API.Data.Models;

namespace BankTest
{
    [TestClass]
    public class BankDepositCreationDTOTest
    {
        [TestClass]
        public class BankEntityDepositTest
        {
            [TestMethod]
            public void DepositNotNullTest()
            {
                var deposit = new DepositCreationDTO()
                {
                    Name = "Nume Prenume",
                    DepositSum = 2800
                };

                Assert.IsNotNull(deposit);
            }

            [TestMethod]
            public void NameTest()
            {
                var deposit = new DepositCreationDTO()
                {
                    Name = "Nume Prenume",
                    DepositSum = 2800
                };

                var expected = "Nume Prenume";

                Assert.AreEqual(expected, deposit.Name);
            }

            [TestMethod]
            public void PeriodTest()
            {
                var deposit = new DepositCreationDTO()
                {
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
                var deposit = new DepositCreationDTO()
                {
                    Name = "Nume Prenume",
                    DepositSum = 2800
                };

                var expected = 2800;

                Assert.AreEqual(expected, deposit.DepositSum);
            }

            [TestMethod]
            public void NameNullValidTest()
            {
                var deposit = new DepositCreationDTO()
                {
                    Name = "",
                    DepositSum = 2800
                };

                var expected = true;

                if (string.IsNullOrEmpty(deposit.Name))
                    expected = false;

                Assert.IsFalse(expected);
            }


            [TestMethod]
            public void NameLengthValidTest()
            {
                var deposit = new DepositCreationDTO()
                {
                    Name = "testtesttesttesttesttesttesttesttesttesttesttesttesttest",
                    DepositSum = 2800
                };

                var expected = true;

                if (deposit.Name.Length > 50)
                    expected = false;

                Assert.IsFalse(expected);
            }

            [TestMethod]
            public void PeriodValidTest()
            {
                var deposit = new DepositCreationDTO()
                {
                    Name = "Nume Prenume",
                    DepositSum = 2800,
                    Period = 2
                };

                var expected = true;

                if (deposit.Period != 1 || deposit.Period != 6 || deposit.Period != 12)
                    expected = false;

                Assert.IsFalse(expected);
            }

            [TestMethod]
            public void SumLowerValidTest()
            {
                var deposit = new DepositCreationDTO()
                {
                    Name = "Nume Prenume",
                    DepositSum = -2800
                };

                var expected = true;

                if (deposit.DepositSum < 0 || deposit.DepositSum > float.MaxValue)
                    expected = false;

                Assert.IsFalse(expected);
            }
        }
    }
}
