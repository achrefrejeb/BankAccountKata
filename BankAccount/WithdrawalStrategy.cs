namespace BankAccountKata
{
    public class WithdrawalStrategy : ITransactionStrategy
    {
        public void DoOperation(BankAccount account, decimal amount)
        {
            account.Balance -= amount;
        }
    }
}