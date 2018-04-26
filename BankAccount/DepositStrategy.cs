namespace BankAccountKata
{
    public class DepositStrategy : ITransactionStrategy
    {
        public void DoOperation(BankAccount account, decimal amount)
        {
            account.Balance += amount;
        }
    }
}