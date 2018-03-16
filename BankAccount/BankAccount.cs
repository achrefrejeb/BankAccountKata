using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountKata
{
    public class BankAccount
    {
        private double _balance;

        private List<Operation> _operations;

        public BankAccount(double balance)
        {
            this._balance = balance;
            this._operations = new List<Operation>();
        }

        public void Deposit(double value)
        {
            this._balance += value;
            this._operations.Add(new Operation(OpearationType.Deposit,DateTime.Now, value,this._balance));
        }

        public void Withdrawal(double value)
        {
            this._balance -= value;
            this._operations.Add(new Operation(OpearationType.Withdrawal, DateTime.Now, value, this._balance));
        }

        public double GetBalance()
        {
            return this._balance;
        }

        public string GetOperations()
        {
            StringBuilder operationResults = new StringBuilder("Account History\n---------------------------\n");
            foreach (Operation operation in _operations)
            {
                operationResults.AppendLine(string.Format("Operation: {0}",operation.OpearationType.ToString()));
                operationResults.AppendLine(string.Format("Date: {0}",operation.Date.ToString("d")));
                operationResults.AppendLine(string.Format("Amount: {0}",operation.Amount));
                operationResults.AppendLine(string.Format("Account Balance: {0}",operation.Balance));
                operationResults.AppendLine("---------------------------");
            }

            return operationResults.ToString();
        }
    }

    public class Operation
    {
        public OpearationType OpearationType;
        public DateTime Date;
        public double Amount;
        public double Balance;

        public Operation(OpearationType operationtype, DateTime date, double amount, double balance)
        {
            this.OpearationType = operationtype;
            this.Date = date;
            this.Amount = amount;
            this.Balance = balance;
        }
    }

    public enum OpearationType
    {
        Deposit,
        Withdrawal
    }
}
