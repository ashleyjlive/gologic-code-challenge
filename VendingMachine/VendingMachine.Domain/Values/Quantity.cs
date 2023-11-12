namespace VendingMachine.Domain.Values
{
    public record Quantity(uint Value)
    {
        public Quantity Increment()
        {
            return new Quantity(Value + 1);
        }

        public Quantity Decrement()
        {
            return new Quantity(Value - 1);
        }

        public static Quantity FromValue(uint value)
        {
            return new Quantity(value);
        }
    }
}
