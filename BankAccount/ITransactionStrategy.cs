namespace BankAccountKata
{
    public interface ITransactionStrategy
    {
        void DoOperation(BankAccount account, decimal amount);
    }

    public class DepositStrategy : ITransactionStrategy
    {
        public void DoOperation(BankAccount account, decimal amount)
        {
            account.Balance += amount;
        }
    }

    public class WithdrawalStrategy : ITransactionStrategy
    {
        public void DoOperation(BankAccount account, decimal amount)
        {
            account.Balance -= amount;
        }
    }

}
