using System.Collections.Generic;
using System.Text;

namespace BankAccountKata
{
    public class BankAccount
    {
        public readonly List<Transaction> Operations;
        public decimal Balance;

        public BankAccount(decimal balance)
        {
            Balance = balance;
            Operations = new List<Transaction>();
        }

        public string GetFormattedTransactionsHistory()
        {
            var transactionsHistory = new StringBuilder("Account History\n---------------------------\n");
            foreach (var operation in Operations)
            {
                transactionsHistory.Append(operation);
                transactionsHistory.AppendLine("---------------------------");
            }

            return transactionsHistory.ToString();
        }
    }
}