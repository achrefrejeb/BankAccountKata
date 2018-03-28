using System;
using System.Text;

namespace BankAccountKata
{
    public abstract class Transaction
    {
        public BankAccount Account;
        public decimal Amount;
        public DateTime Date;
        public TransactionType TransactionType;
        public ITransactionStrategy TransactionStrategy;

        protected Transaction(BankAccount account ,decimal amount)
        {
            Account = account;
            Amount = amount;
        }

        public void DoOperation()
        {
            Date = DateTime.Now;
            TransactionStrategy.DoOperation(Account, Amount);
            Account.Operations.Add(this);
        }

        public override string ToString()
        {
            StringBuilder operationInformation = new StringBuilder();

            operationInformation.AppendLine(string.Format("Operation: {0}", TransactionType.ToString()));
            operationInformation.AppendLine(string.Format("Date: {0}", Date.ToString("d")));
            operationInformation.AppendLine(string.Format("Amount: {0}", Amount));
            operationInformation.AppendLine(string.Format("Account Balance: {0}", Account.Balance));

            return operationInformation.ToString();
        }
    }

    public class DepositTransaction : Transaction
    {
        public DepositTransaction(BankAccount account, decimal amount)
            : base(account, amount)
        {
            TransactionType = TransactionType.Deposit;
            TransactionStrategy = new DepositStrategy();
        }
    }

    public class WithdrawalTransaction : Transaction
    {
        public WithdrawalTransaction(BankAccount account, decimal amount)
            : base(account, amount)
        {
            TransactionType = TransactionType.Withdrawal;
            TransactionStrategy = new WithdrawalStrategy();
        }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
}