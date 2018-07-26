using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountKata;
using NUnit.Framework;

namespace BankAccountTest
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        [TestCase(0, 100, ExpectedResult = 100)]
        [TestCase(100, 100, ExpectedResult = 200)]
        [TestCase(0, 200, ExpectedResult = 200)]
        [TestCase(200, 100, ExpectedResult = 300)]
        [TestCase(120, 100, ExpectedResult = 220)]
        public decimal ShouldReturnGreaterSumWhenMakeDeposit(decimal balance, decimal amount)
        {
            //Arrange
            BankAccount account = new BankAccount(balance);
            //Act
            new DepositTransaction(account, amount).DoOperation();
            //Assert
            return account.Balance;
        }

        [TestMethod]
        [TestCase(100, 100, ExpectedResult = 0)]
        [TestCase(200, 100, ExpectedResult = 100)]
        [TestCase(100, 0, ExpectedResult = 100)]
        [TestCase(300, 100, ExpectedResult = 200)]
        public decimal ShouldReturnLowerSumWhenMakeWithdrawal(decimal balance, decimal amount)
        {
            BankAccount account = new BankAccount(balance);
            new WithdrawalTransaction(account, amount).DoOperation();
            return account.Balance;
        }
    }
}
