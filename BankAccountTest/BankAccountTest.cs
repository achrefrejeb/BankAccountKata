using System;
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
        [TestCase(100, ExpectedResult = 100)]
        [TestCase(200, ExpectedResult = 200)]
        [TestCase(0, ExpectedResult = 0)]
        public decimal ShouldRetuenTheSameBalanceAmount(decimal balance)
        {
            BankAccount account = new BankAccount(balance);
            return account.Balance;
        }

        [TestMethod]
        public void ShouldReturnListOfTransactionsWhenNeeded()
        {
            decimal amount = 100;
            BankAccount account = new BankAccount(0);
            new DepositTransaction(account, amount).DoOperation();
            new WithdrawalTransaction(account, amount).DoOperation();
            var list = FormatHelper.GetFormattedTransactionsHistory(account);
            Check.That(list).Equals(string.Format("Account History\n---------------------------\nOperation: Deposit\r\nDate: {0}\r\nAmount: 100\r\nAccount Balance: 0\r\n---------------------------\r\nOperation: Withdrawal\r\nDate: {0}\r\nAmount: 100\r\nAccount Balance: 0\r\n---------------------------\r\n", DateTime.Now.Date.ToString("d")));
        }
    }
}
