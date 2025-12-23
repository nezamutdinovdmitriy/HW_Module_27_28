using System;

public class Currency
{
    public event Action AmountChanged;

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
        {
            Amount += value;
            AmountChanged?.Invoke();
        }
    }
    public void Spend(int value)
    {
        if (value > 0 && value <= Amount)
        {
            Amount -= value;
            AmountChanged?.Invoke();
        }
    }
}
