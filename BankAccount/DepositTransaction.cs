namespace BankAccountKata
{
    public class DepositTransaction : Transaction
    {
        public DepositTransaction(BankAccount account, decimal amount)
            : base(account, amount)
        {
            TransactionType = TransactionType.Deposit;
            TransactionStrategy = new DepositStrategy();
        }
    }
}