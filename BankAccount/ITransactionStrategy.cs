namespace BankAccountKata
{
    public interface ITransactionStrategy
    {
        void DoOperation(BankAccount account, decimal amount);
    }
}
