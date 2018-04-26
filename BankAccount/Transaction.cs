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

        protected Transaction(BankAccount account, decimal amount)
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

            operationInformation.AppendLine(string.Format(string.Format(@"Operation: {0}
Date: {1}
Amount: {2}
Account Balance: {3}"
                , TransactionType.ToString(), Date.ToString("d"), Amount, Account.Balance)));

            return operationInformation.ToString();


            


        }
    }
}