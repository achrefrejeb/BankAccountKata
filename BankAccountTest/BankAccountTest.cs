using System;
using System.Windows.Markup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using BankAccountKata;
using NUnit.Framework;

namespace BankAccountTest
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        [TestCase(0d, 100d, ExpectedResult = 100d)]
        [TestCase(100d, 100d, ExpectedResult = 200d)]
        [TestCase(0d, 200d, ExpectedResult = 200d)]
        [TestCase(200d, 100d, ExpectedResult = 300d)]
        public double ShouldReturnGratherSumWhenMakeDeposit(double balance, double value)
        {
            BankAccount account = new BankAccount(balance);
            account.Deposit(value);
            return account.GetBalance();
        }

        [TestMethod]
        [TestCase(100d, 100d, ExpectedResult = 0d)]
        [TestCase(200d, 100d, ExpectedResult = 100d)]
        [TestCase(100d, 0d, ExpectedResult = 100d)]
        [TestCase(300d, 100d, ExpectedResult = 200d)]
        public double ShouldReturnLowerSumWhenMakeWithdrawal(double balance, double value)
        {
            BankAccount account = new BankAccount(balance);
            account.Withdrawal(value);
            return account.GetBalance();
        }

        [TestMethod]
        public void ShouldReturnListOfOperationsWhenNeeded(  )
        {
            double value = 100d;
            BankAccount account = new BankAccount(0d);
            account.Deposit(value);
            account.Withdrawal(value);
            var list = account.GetOperations();
            Check.That(list).Equals(string.Format("Account History\n---------------------------\nOperation: Deposit\r\nDate: {0}\r\nAmount: 100\r\nAccount Balance: 100\r\n---------------------------\r\nOperation: Withdrawal\r\nDate: {0}\r\nAmount: 100\r\nAccount Balance: 0\r\n---------------------------\r\n", DateTime.Now.Date.ToString("d")));
        }
    }
}
