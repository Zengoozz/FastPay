namespace Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; } = "EGP";

        private Money() { }

        public Money(decimal amount, string currency = "EGP")
        {
            if(amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));

            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money money)
        {
            if(Currency != money.Currency)
                throw new InvalidOperationException("Cannot add amounts with different currencies.");

            return new Money(Amount + money.Amount, Currency);
        }

        public override string ToString() => $"{Amount} {Currency}";
    }
}
