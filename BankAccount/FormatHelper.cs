using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountKata
{
    public static class FormatHelper
    {
        public static string GetFormattedTransactionsHistory(BankAccount bankAccount)
        {
            var transactionsHistory = new StringBuilder("Account History\n---------------------------\n");
            foreach (var operation in bankAccount.Operations)
            {
                transactionsHistory.Append(operation);
                transactionsHistory.AppendLine("---------------------------");
            }

            return transactionsHistory.ToString();
        }
    }
}
