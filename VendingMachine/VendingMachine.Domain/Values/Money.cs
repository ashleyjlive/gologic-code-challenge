using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.Values
{
    public record Money
    {
        public static Money None => new(0);

        public decimal Amount { get; init; }

        public Money(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot have negative money");
            }
            Amount = amount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        /// <exception cref="InsufficientMoneyException"></exception>
        public Money Deduct(Money money)
        {
            if(money.Amount > Amount)
            {
                throw new InsufficientMoneyException();
            }
            return new Money(Amount - money.Amount);
        }

        public Money Add(Money money)
        {
            return new Money(Amount + money.Amount);
        }

        public static Money FromAmount(decimal amount)
        {
            return new Money(amount);
        }
    }
}