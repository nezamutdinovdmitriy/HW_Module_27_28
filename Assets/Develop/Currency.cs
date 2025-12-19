public class Currency
{
    public Currency(CurrencyType type)
    {
        Type = type;

        Amount = default;
    }

    public CurrencyType Type { get; }

    public int Amount { get; private set; }

    public void Add(int value)
    {
        if (value > 0)
            Amount += value;
    }
    public void Spend(int value)
    {
        if (value > 0 && value <= Amount)
            Amount -= value;
    }
}
