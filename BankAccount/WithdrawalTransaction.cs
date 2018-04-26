namespace BankAccountKata
{
    public class WithdrawalTransaction : Transaction
    {
        public WithdrawalTransaction(BankAccount account, decimal amount)
            : base(account, amount)
        {
            TransactionType = TransactionType.Withdrawal;
            TransactionStrategy = new WithdrawalStrategy();
        }
    }
}