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

    }
}