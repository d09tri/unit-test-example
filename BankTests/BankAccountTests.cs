using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankProject;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void DebitTesting()
        {
            // Arrange
            double currentBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.45;
            BankAccount account = new BankAccount("test-debit", "123", currentBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.2, "Debit failed");
        }

        [TestMethod]
        public void CreditTesting()
        {
            // Arrange
            double currentBalance = 10.0;
            double creditAmount = 1.0;
            double expected = 11.0;
            BankAccount account = new BankAccount("test-credit", "123", currentBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.AreEqual(expected, account.Balance, 0.001, "Credit failed");
        }
    }
}
